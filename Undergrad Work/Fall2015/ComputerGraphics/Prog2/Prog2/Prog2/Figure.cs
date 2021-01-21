using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Prog2
{

   /// <summary>
   /// 
   /// </summary>
   class Figure
   {
      private VertexData[] verts;
      private string name = null;
      private int vboHandle;
      private int vaoHandle;

      /// <summary>
      /// 
      /// </summary>
      /// <param name="fileName"></param>
      public Figure(String fileName)
      {
         name = new FileInfo(fileName).Name;
         name = name.Substring(0, name.IndexOf(".wrl"));

      }

      /// <summary>
      /// 
      /// </summary>
      public void Load()
      {
         //TODO: get array of vertices using VertexDataList
         VertexDataList vdl = new VertexDataList();
         bool correctFile = vdl.LoadDataFromVRML(name);
         if (!correctFile)
         {
            //show error message?
         }

         //TODO: might need to do something with VBO and VAO, I don't quite understand these
         GL.GenBuffers(1, out vboHandle);
         GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
         GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

         GL.GenVertexArrays(1, out vaoHandle);
         GL.BindVertexArray(vaoHandle);
      }

      /// <summary>
      /// 
      /// </summary>
      public void Show()
      {
         GL.BindVertexArray(vaoHandle);
         GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
         GL.BindVertexArray(0);
      }
   }
}
