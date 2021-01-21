using System;

using OpenTK;
using OpenTK.Graphics.OpenGL;

/// <summary>
/// A 3D representation of the axes that can be drawn.
/// Draws lines that represent each axis, red for x,
/// green for y, blue for z. Only one instance may exist
/// at any time, acquired through through the Instance
/// propety (it is a singleton).
/// </summary>
public class Axes
{
   private static Axes _instance = null;
   private int vboHandle;
   private int vaoHandle;

   /// <summary>
   /// The vertex pairs of 3 lines originating from 0, 0, 0
   /// and extending along each major axis.
   /// </summary>
   private VertexData[] verts =
   {
      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f)),
      new VertexData(new Vector3(200.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f)),

      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f)),
      new VertexData(new Vector3(0.0f, 200.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f)),

      new VertexData(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f)),
      new VertexData(new Vector3(0.0f, 0.0f, 200.0f), new Vector3(0.0f, 0.0f, 1.0f))
   };

   /// <summary>
   /// Provides the singleton. If one has not been instantiated
   /// it creates one and provides it.
   /// </summary>
   public static Axes Instance
   {
      get
      {
         if (_instance == null)
            _instance = new Axes();
         return _instance;
      }
   }

   /// <summary>
   /// The private constructor used to instantiate the singleton.
   /// This sets up the VBO and VAO the singleton will use to
   /// display the axes.
   /// </summary>
   private Axes()
   {
      GL.GenBuffers(1, out vboHandle);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vboHandle);
      GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(verts.Length * BlittableValueType.StrideOf(verts)), verts, BufferUsageHint.StaticDraw);

      GL.GenVertexArrays(1, out vaoHandle);
      GL.BindVertexArray(vaoHandle);

      GL.EnableClientState(ArrayCap.VertexArray);
      GL.EnableClientState(ArrayCap.ColorArray);

      GL.VertexPointer(3, VertexPointerType.Float, BlittableValueType.StrideOf(verts), new IntPtr(0));
      GL.ColorPointer(3, ColorPointerType.Float, BlittableValueType.StrideOf(verts), new IntPtr(12));

      GL.BindVertexArray(0);
   }

   /// <summary>
   /// Draws the axes according to their definition in verts.
   /// </summary>
   public void Show(Matrix4 look_at)
   {
      GL.MatrixMode(MatrixMode.Modelview);
      GL.LoadMatrix(ref look_at);
      GL.BindVertexArray(vaoHandle);
      GL.DrawArrays(PrimitiveType.Lines, 0, verts.Length);
      GL.BindVertexArray(0);
   }
}
