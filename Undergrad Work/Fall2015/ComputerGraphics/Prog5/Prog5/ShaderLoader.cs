/// Program:   Program 5
/// Class:     CS3920
/// File:      ShaderLoader.cs: 
///            Loads shader files to be used with openGL. 
/// Authors:   Brianna Muleski, Lucas Gangstad
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;

/// <summary>
/// Loads and uses vertex and fragment shader files as a singelton. Loads and
/// unloads the shaders to be used in the program.
/// </summary>
public class ShaderLoader
{
   private string loadError = "";
   private int vertexHandle = 0;
   private int fragmentHandle = 0;
   private int programHandle = 0;

   private static ShaderLoader _instance = null;

   /// <summary>
   /// Creates an instance of ShaderLoader if one has not been created yet.
   /// </summary>
   public static ShaderLoader Instance
   {
      get
      {
         if (_instance == null)
            _instance = new ShaderLoader();
         return _instance;
      }
   }

   /// <summary>
   /// Empty Contructor. Restricts use of ShaderLoader to singleton.
   /// </summary>
   private ShaderLoader()
   {
      // An instance cannot be created outside of this class - Singleton!
   }
   
   /// <summary>
   /// Returns the program handle index.
   /// </summary>
   public int ProgramHandle
   {
      get { return programHandle; }
   }

   /// <summary>
   /// Attempts to load the given shader files. If the file is loaded
   /// correctly, then attaches the shaders to GL for use with the program.
   /// Catches any exceptions, unloads the shaders, and set loadError to that
   /// exception.
   /// </summary>
   /// <param name="vertexShaderFileName">the vertex shader file</param>
   /// <param name="fragmentShaderFileName">the fragment shader file</param>
   /// <returns>true if loaded successfully, false otherwise</returns>
   public bool Load (string vertexShaderFileName, string fragmentShaderFileName)
   {
      Unload();   // Unload just in case something was loaded

      vertexHandle = GL.CreateShader(ShaderType.VertexShader);
      fragmentHandle = GL.CreateShader(ShaderType.FragmentShader);

      if (vertexHandle == 0 || fragmentHandle == 0)
      {
         loadError = "CreateShader call failed";
         return false;
      }

      if (!LoadAndCompileShader(vertexShaderFileName, vertexHandle))
         return false;

      if (!LoadAndCompileShader(fragmentShaderFileName, fragmentHandle))
      {
         Unload();
         return false;
      }

      programHandle = GL.CreateProgram();
      if (programHandle == 0)
      {
         Unload();
         loadError = "CreateProgram call failed";
         return false;
      }

      try
      {
         GL.AttachShader(programHandle, vertexHandle);
         GL.AttachShader(programHandle, fragmentHandle);

         GL.LinkProgram(programHandle);

         GL.UseProgram(programHandle);

         GL.DetachShader(programHandle, vertexHandle);
         GL.DetachShader(programHandle, fragmentHandle);

         return true;
      }
      catch (Exception ex)
      {
         Unload();
         loadError = ex.Message;
         return false;
      }
   }

   /// <summary>
   /// Unloads the shaders from GL if they exist currently.
   /// </summary>
   public void Unload()
   {
      if (programHandle != 0)
      {
         GL.DeleteProgram(programHandle);
         programHandle = 0;
      }

      if (fragmentHandle != 0)
      {
         GL.DeleteShader(fragmentHandle);
         fragmentHandle = 0;
      }

      if (vertexHandle != 0)
      {
         GL.DeleteShader(vertexHandle);
         vertexHandle = 0;
      }
      loadError = "";
   }

   /// <summary>
   /// Returns the load error that occurred.
   /// </summary>
   public string LastLoadError
   {
      get { return loadError; }
   }

   /// <summary>
   /// Loads/Compiles a single shader file into the given handle.
   /// Catches any exception and sets the loadError to that exception.
   /// </summary>
   /// <param name="fileName">the shader file to be loaded</param>
   /// <param name="handle">the handle to use the shader</param>
   /// <returns>true if loaded and compiled correctly, false otherwise</returns>
   private bool LoadAndCompileShader(string fileName, int handle)
   {
      int status;
      string logInfo;

      try
      {
         StreamReader streamReader = new StreamReader(fileName);
         string shaderSource = streamReader.ReadToEnd();
         streamReader.Close();
         GL.ShaderSource(handle, shaderSource);
         GL.CompileShader(handle);
         GL.GetShaderInfoLog(handle, out logInfo);
         GL.GetShader(handle, ShaderParameter.CompileStatus, out status);
         if (status == 0)
         {
            GL.DeleteShader(handle);
            loadError = logInfo;
            return false;
         }
         return true;
      }
      catch (Exception ex)
      {
         loadError = ex.Message;
         return false;
      }
   }

}
