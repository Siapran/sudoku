﻿using System;
using System.Collections.Generic;

namespace sudoku
{

	public class SudokuGrid
	{
		const int GRID_SIZE = 9;
		const int SQUARE_SIZE = 3;

		static Random rng = new Random ();

		private int[,] _grid;

		public int[,] Grid {
			get {
				return this._grid;
			}
			set {
				_grid = value;
			}
		}

		public SudokuGrid ()
		{
			_grid = new int[GRID_SIZE, GRID_SIZE];
			for (int i = 0; i < GRID_SIZE; i++) {
				for (int j = 0; j < GRID_SIZE; j++) {
					_grid [i, j] = 0;
				}
			}
		}

		private bool IsInLine (int value, int line)
		{
			for (int i = 0; i < GRID_SIZE; ++i) {
				if (_grid [line, i] == value) {
					return true;
				}
			}
			return false;
		}

		private bool IsInColumn (int value, int column)
		{
			for (int i = 0; i < GRID_SIZE; ++i) {
				if (_grid [i, column] == value) {
					return true;
				}
			}
			return false;
		}

		private bool IsInSquare (int value, int line, int column)
		{
			line = line - (line % SQUARE_SIZE);
			column = column - (column % SQUARE_SIZE);
			for (int i = line; i < line + SQUARE_SIZE; ++i) {
				for (int j = column; j < column + SQUARE_SIZE; ++j) {
					if (_grid [i, j] == value) {
						return true;
					}
				}
			}
			return false;
		}

		public bool IsValid (int value, int line, int column)
		{
			return _grid [line, column] == 0
			&& !IsInLine (value, line)
			&& !IsInColumn (value, column)
			&& !IsInSquare (value, line, column);
		}

		public void GenerateGrid ()
		{
			GenerationWroker (0);
		}

		public static int[] Shuffle (int[] table)
		{
			for (int i = 0; i < table.Length; i++) {
				int k = rng.Next (i + 1);
				int v = table [k];
				table [k] = table [i];
				table [i] = v;
			}

			return table;
		}

		private bool GenerationWroker (int index)
		{
			if (index == GRID_SIZE * GRID_SIZE) {
				return true;
			}

			int i = index / GRID_SIZE;
			int j = index % GRID_SIZE;

			if (_grid [i, j] != 0) {
				return GenerationWroker (index + 1);
			}

			int[] nums = new int[9];
			for (int k = 0; k < nums.Length; k++) {
				nums [k] = k + 1;
			}
			Shuffle (nums);

			foreach (int num in nums) {
				if (IsValid (num, i, j)) {
					_grid [i, j] = num;

					if (GenerationWroker (index + 1)) {
						return true;
					}
				}
			}
			_grid [i, j] = 0;


			return false;
		}

		
	}
}
