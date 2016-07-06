using System;

namespace Checkers
{
	/// <summary>
	/// Summary description for Checkers.
	/// </summary>
	public class Game
	{
		#region Variables
		private  Checker [ , ] board;
		internal string turn;
		internal Position current;

		internal int bestMove;

		// Indexers used to get chess pieces
		public  Checker this [int i, int j]
		{
			get
			{
				return board[i, j];
			}
		}
	
		internal Checker this [Position pos]
		{
			get
			{
				return board[pos.X, pos.Y];
			}
			set
			{
				board[pos.X, pos.Y] = value;
			}
		}

		public string Turn
		{
			get
			{
				return turn;
			}
		}

		public const int NONE = 0;
		public const int RED = 1;
		public const int BLACK = 2;
		public const int TIE = -1;
		public int gameOver
		{
			get
			{
				if (bestMove > 0)
					return NONE;
				if (bestMove == -1)
					return TIE;
				// else if (bestMove == 0)
				if (turn == "red")
					return RED;
				else
					return BLACK;
			}
		}
		
		#endregion

		public Game()
		{
			newGame();
		}
		public Game(Game old)
		{
			board = new Checker[8,8];

			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					if (old[i, j] != null)
						board[i,j] = new Checker(old[i, j]);
			bestMove = old.bestMove;
			if (old.current != null)
				current = new Position(old.current);
			turn = old.turn;
		}
		public void newGame()
		{
			board = new Checker[8,8];
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					board[i, j] = null;

			for (int i = 1; i < 8; i +=2)
			{
				board[i, 1] = new Checker("pawn", "black");
				board[i, 5] = new Checker("pawn", "red");
				board[i, 7] = new Checker("pawn", "red");
			}
			for (int i = 0; i < 8; i +=2)
			{
				board[i, 0] = new Checker("pawn", "black");
				board[i, 2] = new Checker("pawn", "black");
				board[i, 6] = new Checker("pawn", "red");
			}
			current = null;
			turn = "black";
			bestMove = 1;
		}
		public void newGame2()
		{
			board = new Checker[8,8];
			for (int i = 0; i < 8; i++)
				for (int j = 0; j < 8; j++)
					board[i, j] = null;

			board[0, 2] = new Checker("pawn", "black");
			board[0, 4] = new Checker("pawn", "black");
			board[0, 6] = new Checker("king", "black");
			board[2, 2] = new Checker("pawn", "black");
			board[2, 6] = new Checker("pawn", "black");
			board[3, 1] = new Checker("pawn", "black");
			board[3, 5] = new Checker("pawn", "black");

			board[1, 3] = new Checker("pawn", "red");
			board[1, 5] = new Checker("pawn", "red");
			current = null;
			turn = "black";
			bestMove = 2;
		}
		public bool MovePiece(Position from, Position to)
		{
			if (bestMove < 1)
				return false;
			if (this[from] == null)
				return false;
			if (this[from].Color != turn)
				return false;
			if (this[to] != null)
				return false;
			if (current != null && current != from)
				return false;

			Position diff = new Position(to.X - from.X, to.Y - from.Y);
			if (Math.Abs(diff.Y) > 2 || diff.Y == 0)
				return false;
			if (Math.Abs(diff.X) > 2 || diff.X == 0)
				return false;
			if (Math.Abs(diff.X) != Math.Abs(diff.Y))
				return false;
			// Not jumping when a jump is avaliable
			if (bestMove == 2 && Math.Abs(diff.X) == 1)
				return false;

			if (this[from].Rank == "pawn")
			{
				if (this[from].Color == "red" && diff.Y > 0)
					return false;
				else if (this[from].Color == "black" && diff.Y < 0)
					return false;
			}

			//Advance
			if (Math.Abs(diff.X) == 1)
			{
				this[to] = this[from];
				this[from] = null;

				if (to.Y == 0 || to.Y == 7)
					this[to].rank = "king";
				current = null;
			}
			
			else //Jump
			{
				Position capture = new Position(from.X + diff.X / 2, from.Y + diff.Y / 2);
				if (this[capture] == null)
					return false;
				if (this[capture].Color == this[from].Color)
					return false;

				this[to] = this[from];
				this[from] = null;
				this[capture] = null;

				if (to.Y == 0 || to.Y == 7)
					this[to].rank = "king";
				if (CanMove(to) == 2)
				{
					current = to;
					bestMove = 2;
				}
				else
					current = null;
			}
			if (current == null)
			{
				bestMove = 0;

				for (int i = 0; i < 8; i++)
					for (int j = 0; j < 8; j++)
						if (this[i,j] != null && this[i, j].Color != turn)
							bestMove = Math.Max(bestMove, CanMove(new Position(i, j)));
				if (bestMove == 0)
				{
					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
							if (this[i,j] != null && this[i, j].Color == turn)
								bestMove = Math.Max(bestMove, CanMove(new Position(i, j)));

					if (bestMove == 0)
						bestMove = -1;
					else
						bestMove = 0;

				}
				if (bestMove > 0)				
					ToggleTurn();
			}
			return true;
		}
		int CanMove (Position from)
		{
			// Jump
			if ((this[from].Rank == "king" || this[from].Color == "red") && from.Y > 1)
			{
				if (from.X > 1 && this[from.X - 1, from.Y - 1] != null &&
					this[from.X - 1, from.Y - 1].Color != this[from].Color &&
					this[from.X - 2, from.Y - 2] == null)
					return 2;
				if (from.X < 6 && this[from.X + 1, from.Y - 1] != null &&
					this[from.X + 1, from.Y - 1].Color != this[from].Color &&
					this[from.X + 2, from.Y - 2] == null)
					return 2;
			}

			if ((this[from].Rank == "king" || this[from].Color == "black") && from.Y < 6)
			{
				if (from.X > 1 && this[from.X - 1, from.Y + 1] != null &&
					this[from.X - 1, from.Y + 1].Color != this[from].Color &&
					this[from.X - 2, from.Y + 2] == null)
					return 2;
				if (from.X < 6 && this[from.X + 1, from.Y + 1] != null &&
					this[from.X + 1, from.Y + 1].Color != this[from].Color &&
					this[from.X + 2, from.Y + 2] == null)
					return 2;
			}

			// Advance
			if ((this[from].Rank == "king" || this[from].Color == "red") && from.Y > 0)
			{
				if ((from.X > 0 && this[from.X - 1, from.Y - 1] == null) ||
					(from.X < 7 && this[from.X + 1, from.Y - 1] == null))
					return 1;
			}

			if ((this[from].Rank == "king" || this[from].Color == "black") && from.Y < 7)
			{
				if ((from.X > 0 && this[from.X - 1, from.Y + 1] == null) ||
					(from.X < 7 && this[from.X + 1, from.Y + 1] == null))
					return 1;
			}

			return 0;
		}
		private void ToggleTurn()
		{
			if (turn == "black")
				turn = "red";
			else
				turn = "black";

		}
		public override string ToString()
		{
			string output = "";
			for (int i = 7; i > -1; i--)
			{
				for (int j = 0; j < 8; j++)
				{
					if (this[j, i] == null)
						output += "  ";
					else if (this[j, i].Color == "red")
						output += "R ";
					else // if (this[i, j].Color == "black")
						output += "B ";
				}
				output += (char) 13;
			}
			return output;
		}
	}

	public class Checker
	{
		internal string rank;
		protected string color;

		public string Rank
		{
			get
			{
				return rank;
			}
		}
		public string Color
		{
			get
			{
				return color;
			}
		}
		internal Checker(string Irank, string Icolor)
		{
			rank = Irank;
			color = Icolor;
		}
		internal Checker (Checker C)
		{
			rank = C.rank;
			color = C.color;
		}
	}


	public class Position
	{
		internal int X;
		internal int Y;

		public Position()
		{}

		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
		public Position(Position P)
		{
			X = P.X;
			Y = P.Y;
		}
		public static bool operator== (Position lhs, Position rhs)
		{
			// Reference Compares
			if ((Object) lhs == null && (Object) rhs == null)
				return true;
			if ((Object) lhs == null || (Object) rhs == null)
				return false;

			if (lhs.X == rhs.X && lhs.Y == rhs.Y)
				return true;
			return false;
		}
		public static bool operator!= (Position lhs, Position rhs)
		{
			// Reference Compares
			if ((Object) lhs == null && (Object) rhs == null)
				return false;
			if ((Object) lhs == null || (Object) rhs == null)
				return true;

			if (lhs.X != rhs.X || lhs.Y != rhs.Y)
				return true;
			return false;
		}
		
		public override bool Equals(Object o)
		{
			Position P = (Position) o;
			if (X == P.X && Y == P.Y)
				return true;
			else
				return false;
		}

		public override int GetHashCode()
		{
			return X * Y;
		}
	}

	public class Move
	{
		public Position from;
		public Position to;

		public Move(Position from, Position to)
		{
			this.from = from;
			this.to = to;
		}
	}
	public class WMove : Move
	{
		public int weight;

		public WMove(Position from, Position to, int weight)
			:base(from, to)
		{
			this.weight = weight;
		}
	}

}
