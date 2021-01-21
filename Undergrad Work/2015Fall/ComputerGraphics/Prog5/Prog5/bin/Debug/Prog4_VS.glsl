#version 400
	const float SPOT_CUTOFF = 10.0;
	const float SPOT_EXPONENT = 0.9;
	
	layout (location = 0) in vec3 VertexPosition;
	layout (location = 1) in vec3 VertexColor;
	layout (location = 2) in vec3 VertexNormal;
	
	out vec3 LightIntensity;
	
	uniform mat4 NormalMatrix;
	uniform mat4 ProjectionMatrix;
	uniform float Shininess;
	uniform float GlobalAmbient;
	uniform vec3 LightPosition;
	uniform vec3 LightColor;
	uniform mat4 ModelMatrix;
	uniform mat4 ViewMatrix;
	uniform vec3 SpotDirection;
	
	void getEyeSpace( out vec3 norm, out vec4 position )
	{
	  norm = normalize(vec3(NormalMatrix * vec4(VertexNormal, 0.0)));
	  position = (ViewMatrix * ModelMatrix) * vec4(VertexPosition,1.0);
	}
	
	vec3 phongModel( vec4 position, vec3 norm )
	{
	  vec3 s = normalize(vec3((ViewMatrix * vec4(LightPosition, 1.0)) - position));
	  vec3 v = normalize(-position.xyz);
	  vec3 r = reflect( -s, norm );
	  vec3 ambient = vec3(GlobalAmbient) * VertexColor;
	  float sDotN = max( dot(s,norm), 0.0 );
	  
	  vec3 spotDir = normalize(vec3(ViewMatrix * vec4(SpotDirection, 0.0))); // The spotlight direction converted to our reference frame.
	  float sDotSpotDir = max( dot(-s, spotDir), 0 ); // The cosine between the direction to the vertex and the direction of the light scaled by each, with a minimum of 0.
	  float cosSpotAngle = cos(radians(SPOT_CUTOFF)); // The cosine of the cutoff angle.
	  float spotEffect = 0.0; // Amount of light from the spotlight if the vertex is outside the cutoff.
	  if (sDotSpotDir >= cosSpotAngle) // Add light from the spotlight if the vertex is inside the cutoff.
		spotEffect = pow(sDotSpotDir, SPOT_EXPONENT); // The spotlight is the similarity (from sDotSpotDir) to some power.
	  
	  vec3 diffuse = LightColor * VertexColor * sDotN * spotEffect;
	  vec3 spec = vec3(0.0);
	  if( Shininess > 0 && sDotN > 0.0 )
		  spec = LightColor * VertexColor *
				 pow( max( dot(r,v), 0.0 ), Shininess ) * spotEffect;
	  return ambient + diffuse + spec;
	}
	
	void main()
	{
	  vec3 eyeNorm;
	  vec4 eyePosition;
	  // Get the position and normal in eye space
	  getEyeSpace(eyeNorm, eyePosition);
	  // Evaluate the lighting equation.
	  LightIntensity = phongModel( eyePosition, eyeNorm );
	  gl_Position = (ProjectionMatrix * ViewMatrix * ModelMatrix) * vec4(VertexPosition,1.0);
	}	