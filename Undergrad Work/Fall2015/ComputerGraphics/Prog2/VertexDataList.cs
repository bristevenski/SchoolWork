using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

using OpenTK;
using OpenTK.Graphics.OpenGL;


/// <summary>
/// Stores a single vertex including position, color, and normal.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct VertexData
{
   public Vector3 Position;
   public Vector3 Color;
   public Vector3 Normal;

   /// <summary>
   /// Creates a vertexdata including the normal.
   /// </summary>
   /// <param name="pos"></param>
   /// <param name="col"></param>
   /// <param name="norm"></param>
   public VertexData(Vector3 pos, Vector3 col, Vector3 norm)
   {
      Position = pos;
      Color = col;
      Normal = norm;
   }

   /// <summary>
   /// Creates a vertexdata with default normal.
   /// </summary>
   /// <param name="pos"></param>
   /// <param name="col"></param>
   public VertexData(Vector3 pos, Vector3 col)
   {
      Position = pos;
      Color = col;
      Normal = new Vector3(0.0F, 0.0F, 0.0F);
   }
}

// Assumes VRML file is good and everything is decomposed into triangles
/// <summary>
/// Creates a list of vertexdata based on a file.
/// </summary>
public class VertexDataList
{
   private List<VertexData> vertList = new List<VertexData>(100);
   private StreamReader infile;

   /// <summary>
   /// Loads data based on VRML file provided.
   /// </summary>
   /// <param name="fullPathFileName"></param>
   /// <returns></returns>
   public bool LoadDataFromVRML(string fullPathFileName)
   {
      vertList.Clear();
      try
      {
         infile = new StreamReader(fullPathFileName);
         if (infile == null)
            return false;

         bool done = false;
         while (!done)
         {
            if (!LookForInVMRL("coord Coordinate { point ["))
               done = true;
            else
            {
               ReadVertsForShapeInVRML();
            }
         }

         if (vertList.Count == 0)
            return false;
         return true;
      }
      catch
      {
         // File not in the expected format
         if (infile != null)
            infile.Close();
         return false;
      }
   }

   /// <summary>
   /// Returns an array representation of the vertexdata list.
   /// </summary>
   /// <returns></returns>
   public VertexData[] VertexArray()
   {
      return vertList.ToArray();
   }



   // Assumes file has everything right, else get bad results and/or an exception is thrown
   // Assumes read pointer is at the line after "coord Coordinate { point ["
   /// <summary>
   /// Reads in all the vertices and indices of the figure being loaded.
   /// </summary>
   private void ReadVertsForShapeInVRML()
   {
      List<Vector3> verts = new List<Vector3>();
      List<Vector3> colors = new List<Vector3>();
      List<ushort> vertIndices = new List<ushort>();
      List<ushort> colorIndices = new List<ushort>();

      ReadVectListFromVMRL(verts);
      LookForInVMRL("coordIndex [");
      ReadIndicesListFromVRML(vertIndices);

      LookForInVMRL("color Color { color [");
      ReadVectListFromVMRL(colors);
      LookForInVMRL("colorIndex [");
      ReadIndicesListFromVRML(colorIndices);

      for (int i = 0; i < vertIndices.Count; i++)
      {
         VertexData v = new VertexData(verts[vertIndices[i]], colors[colorIndices[i]]);
         vertList.Add(v);
      }

      CalculateNormals();
   }

   /// <summary>
   /// Not completed yet.
   /// </summary>
   private void CalculateNormals()
   {
      // This will be completed in a future program
      // I will explain then why we don't want to use the normals the Wings3d exports.
      // This assumes that Wings3d exports faces in CC order.

      // After we cover this, you should be able to write this in a small number of lines using Vector3 operations.
      // Hint:  Loop through, processing 3 verts at a time.
      // Note that in C#, you can't do: vertList[i + 2].Normal = normal;
      // You need to do something like: vertList[i + 2] = new VertexData(vertList[i + 2].Position, vertList[i + 2].Color, normal);

   }

   /// <summary>
   /// Looks for a string in the file and moves the position to that spot.
   /// </summary>
   /// <param name="s"></param>
   /// <returns></returns>
   private bool LookForInVMRL(string s)
   {
      string inLine;
      bool found = false;
      while (!found)
      {
         inLine = infile.ReadLine();
         if (inLine == null)     // returns null if EOF
            return false;
         if (inLine.IndexOf(s) >= 0)
            found = true;
      }
      return true;
   }

   /// <summary>
   /// Reads in vertex data from the current location and puts it in a list.
   /// </summary>
   /// <param name="vecList"></param>
   private void ReadVectListFromVMRL(List<Vector3> vecList)
   {
      string inLine;
      bool done = false;
      while (!done)
      {
         inLine = infile.ReadLine();
         Vector3 vect = new Vector3();
         string[] tokens = inLine.TrimStart().Split(new Char[] { ' ', ',' });
         for (int i = 0; i < 3; i++)
            vect[i] = float.Parse(tokens[i]);
         vecList.Add(vect);
         if (inLine.IndexOf(']') >= 0)
            done = true;
      }
   }

   // Assumes 3 indices per line, i.e., everything is decomposed into triangles
   /// <summary>
   /// Reads in indices from the current location ant puts it in a list.
   /// </summary>
   /// <param name="indexList"></param>
   private void ReadIndicesListFromVRML(List<ushort> indexList)
   {
      string inLine;
      bool done = false;
      while (!done)
      {
         inLine = infile.ReadLine();
         string[] tokens = inLine.TrimStart().Split(new Char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
         for (int i = 0; i < 3; i++)
            indexList.Add(ushort.Parse(tokens[i]));
         if (inLine.IndexOf(']') >= 0)
            done = true;
      }
   }
}