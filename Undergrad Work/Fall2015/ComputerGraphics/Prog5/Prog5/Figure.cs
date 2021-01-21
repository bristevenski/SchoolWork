/// Program:   Program 5
/// Class:     CS3920
/// File:      Figure.cs: 
///            Represents a 3D figure and the manipulations for the figure.
///            A figure can be translated, rotated, and scaled. This class 
///            allows reading a file containing a figure.
/// Authors:   Brianna Muleski, Lucas Gangstad
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Prog5
{

   /// <summary>
   /// Represents a figure that can be drawn from vertex data.
   /// Allows a figure to be generated from a VRML file.
   /// Allows the figure to be drawn.
   /// </summary>
   class Figure
   {
      private VertexData[] verts;
      private Matrix4 display;
      private Vector3 max;
      private Vector3 min;
      private Vector3 translate;
      private string name = null;
      private string fileString;
      private int vboHandle;
      private int vaoHandle;
      private float shininess;
      private long timeout;

      /// <summary>
      /// Creates a figure based on a file.
      /// </summary>
      /// <param name="fileName"> the file of the figure </param>
      public Figure(String fileName)
      {
         fileString = fileName;
         name = new FileInfo(fileName).Name;
         name = name.Substring(0, name.IndexOf(".wrl"));
      }

      /// <summary>
      /// Copy constructor.
      /// </summary>
      /// <param name="f"> figure to be copied</param>
      public Figure(Figure f)
      {
         this.fileString = f.fileString;
         this.name = f.name;
      }

      /// <summary>
      /// Returns the current center coordinates of the figure.
      /// </summary>
      public Vector3 CurrentCenter
      {
         get
         {
            return translate;
         }
      }

      /// <summary>
      /// Returns the name of the figure.
      /// </summary>
      public string Name
      {
         get
         {
            return name;
         }
      }

      /// <summary>
      /// Gets and sets the shininess of the figure.
      /// </summary>
      public float Shininess
      {
         get
         {
            return shininess;
         }
         set
         {
            shininess = value;
         }
      }

      /// <summary>
      /// Gets and sets the lifetime of the figure.
      /// </summary>
      public long Lifetime
      {
         get
         {
            if (timeout == 0)
               return 0;
            return timeout - DateTime.UtcNow.Ticks;
         }
         set
         {
            if (value == 0)
               timeout = 0;
            else
               timeout = DateTime.UtcNow.Ticks + value;
         }
      }

      /// <summary>
      /// Checks if the given object collides with the figure.
      /// </summary>
      /// <param name="OtherObjectMax"> the object's max </param>
      /// <param name="OtherObjectMin"> the object's min</param>
      /// <param name="OtherObjectPosition"> the object's position </param>
      /// <returns> true if a collision is detected, false otherwise. </returns>
      public bool CollidesWith(Vector3 OtherObjectMax, Vector3 OtherObjectMin,
                               Vector3 OtherObjectPosition)
      {
         for (int i = 0; i < 3; i++)
         {
            if ((max[i] + translate[i]) <
                (OtherObjectMin[i] + OtherObjectPosition[i]) ||
                (OtherObjectMax[i] + OtherObjectPosition[i]) <
                (min[i] + translate[i]))
               return false;
         }
         return true;
      }

      /// <summary>
      /// Checks if the given figure collides with the figure.
      /// </summary>
      /// <param name="f"> the other figure </param>
      /// <returns> true if a collision is detected, false otherwise. </returns>
      public bool CollidesWith(Figure f)
      {
         return CollidesWith(f.max, f.min, f.translate);
      }

      /// <summary>
      /// Creates vertex data based on the file provided. Sets up VBO and VAO.
      /// Throws exceptions if the file cannot be loaded or the VBO cannot be 
      /// created. Finds the bounds of the figure. Sets the figures
      /// coordinates to it's "restore" position.
      /// </summary>
      public void Load()
      {
         VertexDataList vdl = new VertexDataList();
         bool correctFile = vdl.LoadDataFromVRML(fileString);
         if (!correctFile)
            throw new Exception("Could not load data from file.");
         verts = vdl.VertexArray();

         GL.GenBuffers(1, out vboHandle);
         GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
         GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

         int size;
         GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
         if (verts.Length * BlittableValueType.StrideOf(verts) != size)
            throw new Exception("VBO creation failed.");

         GL.GenVertexArrays(1, out vaoHandle);
         GL.BindVertexArray(vaoHandle);

         int vertColorLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexColor");
         GL.EnableVertexAttribArray(vertColorLoc);
         GL.VertexAttribPointer(vertColorLoc, 3, VertexAttribPointerType.Float, true, 36, 12);

         int vertPosLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexPosition");
         GL.EnableVertexAttribArray(vertPosLoc);
         GL.VertexAttribPointer(vertPosLoc, 3, VertexAttribPointerType.Float, true, 36, 0);

         int vertNormLoc = GL.GetAttribLocation(ShaderLoader.Instance.ProgramHandle, "VertexNormal");
         GL.EnableVertexAttribArray(vertNormLoc);
         GL.VertexAttribPointer(vertNormLoc, 3, VertexAttribPointerType.Float, true, 36, 24);

         GL.BindVertexArray(0);

         FindBounds();

         Restore();
      }

      /// <summary>
      /// Finds the min and max bounds of the figure for each axis. Loops
      /// through the vertices in verts to find the min and max position of
      /// for each axis.
      /// </summary>
      private void FindBounds()
      {
         min = verts[0].Position;
         max = verts[0].Position;

         foreach (VertexData v in verts)
         {
            Vector3 pos = v.Position;

            if (pos.X < min.X)
               min.X = pos.X;
            else if (pos.X > max.X)
               max.X = pos.X;

            if (pos.Y < min.Y)
               min.Y = pos.Y;
            else if (pos.Y > max.Y)
               max.Y = pos.Y;

            if (pos.Z < min.Z)
               min.Z = pos.Z;
            else if (pos.Z > max.Z)
               max.Z = pos.Z;
         }
      }

      /// <summary>
      /// Draws the 3D figure. Loads the matrix based on the current display
      /// matrix * the original translation * the passed view matrix.
      /// </summary>
      public void Show(Matrix4 view)
      {
         Matrix4 show = display * Matrix4.CreateTranslation(translate);
         Matrix4 normal = (show * view).Inverted();
         normal.Transpose();

         GL.BindVertexArray(vaoHandle);

         int loc;
         loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "ModelMatrix");
         GL.UniformMatrix4(loc, false, ref show);
         loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "NormalMatrix");
         GL.UniformMatrix4(loc, false, ref normal);
         loc = GL.GetUniformLocation(ShaderLoader.Instance.ProgramHandle, "Shininess");
         GL.Uniform1(loc, shininess);

         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }

      /// <summary>
      /// Restores the figure to it's original position and resets the
      /// display matrix.
      /// </summary>
      public void Restore()
      {
         translate = (max + min) / 2;
         display = Matrix4.CreateTranslation(-translate);
      }

      /// <summary>
      /// Rotates the figure around the x-axis by the given rotation amount.
      /// </summary>
      /// <param name="r"> the rotation amount </param>
      public void RotateX(float r)
      {
         display *= Matrix4.CreateRotationX(r);
      }

      /// <summary>
      /// Rotates the figure around the y-axis by the given rotation amount.
      /// </summary>
      /// <param name="r"> the rotation amount </param>
      public void RotateY(float r)
      {
         display *= Matrix4.CreateRotationY(r);
      }

      /// <summary>
      /// Rotates the figure around the z-axis by the given rotation amount.
      /// </summary>
      /// <param name="r"> the rotation amount </param>
      public void RotateZ(float r)
      {
         display *= Matrix4.CreateRotationZ(r);
      }

      /// <summary>
      /// Scales the figure by the given amounts for each axis.
      /// </summary>
      /// <param name="d"> vector representing the scale amounts for each axis </param>
      public void Scale(Vector3 d)
      {
         display *= Matrix4.CreateScale(d);
      }

      /// <summary>
      /// Translates the figure by the given amounts for each axis
      /// </summary>
      /// <param name="d"> vector representing the translation amounts for each axis </param>
      public void Translate(Vector3 d)
      {
         translate += d;
      }
   }
}
