/// Program:   Program 4
/// Class:     CS3920
/// File:      Program.cs: 
///            Runs the program by opening the main form.
/// Authors:   Brianna Muleski, Lucas Gangstad
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog4
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new Form1());
      }
   }
}
