using System;
using Gtk;

namespace sudoku
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			/*Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();*/

			SudokuGrid mygrid = new SudokuGrid ();
			mygrid.GenerateGrid ();
			mygrid.PrintGrid ();
		}

	}
}
