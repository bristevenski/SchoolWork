using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Prog3
{

   /// <summary>
   /// Represents a figure that can be drawn from vertex data.
   /// Allows a figure to be generated from a VRML file.
   /// Allows the figure to be drawn.
   /// </summary>
   class Figure
   {
      private VertexData[] verts;
      private string name = null;
      private string fileString;
      private int vboHandle;
      private int vaoHandle;

      /// <summary>
      /// Creates a figure based on a file.
      /// </summary>
      /// <param name="fileName"></param>
      public Figure(String fileName)
      {
         fileString = fileName;
         name = new FileInfo(fileName).Name;
         name = name.Substring(0, name.IndexOf(".wrl"));
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
      /// Creates vertex data based on the file provided.
      /// Sets up VBO and VAO. Throws exceptions if the
      /// file cannot be loaded or the VBO cannot be
      /// created.
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

         GL.EnableClientState(ArrayCap.VertexArray);
         GL.EnableClientState(ArrayCap.ColorArray);

         GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), new IntPtr(0));
         GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), new IntPtr(12));

         GL.BindVertexArray(0);
      }

      /// <summary>
      /// Draws the 3D figure.
      /// </summary>
      public void Show()
      {
         GL.BindVertexArray(vaoHandle);
         GL.DrawArrays(PrimitiveType.Triangles, 0, verts.Length);
         GL.BindVertexArray(0);
      }
   }
}
