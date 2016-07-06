using System;
using System.Collections;
namespace Checkers
{
	public class CheckersAI
	{
		public static WMove AIMove(Game iGame, string turn, int depth)
		{
			Game game = new Game(iGame);
			return BestMove(game, turn, depth);
		}

		private static WMove BestMove(Game game, string turn, int depth)
		{
			ArrayList moveList = new ArrayList();
			ArrayList finalList = new ArrayList();

			Random r = new Random();

			if (game.current != null)
			{
				moveList = GetJumps(game, game.current);
			}
			else
			{
				if (game.bestMove == 1)
				{
					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
							if (game[i, j] != null && game[i, j].Color == turn)
								moveList.AddRange(getAdvances(game, new Position(i, j)));
				}
				else //(game.bestMove == 2)
				{
					for (int i = 0; i < 8; i++)
						for (int j = 0; j < 8; j++)
							if (game[i, j] != null && game[i, j].Color == turn)
								moveList.AddRange(GetJumps(game, new Position(i, j)));
				}
			}

			for (int i = 0; i < moveList.Count; i++)
			{
				WMove move = (WMove) moveList[i];
				Game test = new Game(game);
				test.MovePiece(move.from, move.to);
				if (test.current != null)
					move.weight += BestMove(test, turn, depth).weight;
				else if (depth != 0)
					move.weight -= BestMove(test, test.turn, depth - 1).weight;
			}

			
			if (moveList.Count > 0)
			{
				finalList.Add(moveList[0]);
				for (int i = 1; i < moveList.Count; i++)
				{
					if (((WMove) moveList[i]).weight == ((WMove)finalList[0]).weight)
						finalList.Add(moveList[i]);
					else if (((WMove) moveList[i]).weight > ((WMove)finalList[0]).weight)
					{
						finalList.Clear();
						finalList.Add(moveList[i]);
					}
				}
				return (WMove) finalList[r.Next(0, finalList.Count)];
			}
			else
				return new WMove(new Position(-1, -1), new Position(-1, -1), -100);
		}
		private static ArrayList GetJumps(Game G, Position from)
		{
			ArrayList jumpList = new ArrayList(4);
			Position to;

			// Jump
			if ((G[from].Rank == "king" || G[from].Color == "red") && from.Y > 1)
			{
				to = new Position (from.X - 2, from.Y - 2);
				if (from.X > 1 && G[from.X - 1, from.Y - 1] != null &&
					G[from.X - 1, from.Y - 1].Color != G[from].Color &&
					G[to] == null)
					jumpList.Add(new WMove(from, to, 1));

				to = new Position (from.X + 2, from.Y - 2);
				if (from.X < 6 && G[from.X + 1, from.Y - 1] != null &&
					G[from.X + 1, from.Y - 1].Color != G[from].Color &&
					G[to] == null)
					jumpList.Add(new WMove(from, to, 1));
			}

			if ((G[from].Rank == "king" || G[from].Color == "black") && from.Y < 6)
			{
				to = new Position (from.X - 2, from.Y + 2);
				if (from.X > 1 && G[from.X - 1, from.Y + 1] != null &&
					G[from.X - 1, from.Y + 1].Color != G[from].Color &&
					G[to] == null)
					jumpList.Add(new WMove(from, to, 1));

				to = new Position (from.X + 2, from.Y + 2);
				if (from.X < 6 && G[from.X + 1, from.Y + 1] != null &&
					G[from.X + 1, from.Y + 1].Color != G[from].Color &&
					G[to] == null)
					jumpList.Add(new WMove(from, to, 1));
			}
			return jumpList;
		}
		private static ArrayList getAdvances(Game G, Position from)
		{
			ArrayList advanceList = new ArrayList(4);
			Position to;

			// Advance
			if ((G[from].Rank == "king" || G[from].Color == "red") && from.Y > 0)
			{
				to = new Position(from.X - 1, from.Y - 1);
				if (from.X > 0 && G[to] == null)
					advanceList.Add(new WMove(from, to, 0));

				to = new Position(from.X + 1, from.Y - 1);
				if	(from.X < 7 && G[to] == null)
					advanceList.Add(new WMove(from, to, 0));
			}

			if ((G[from].Rank == "king" || G[from].Color == "black") && from.Y < 7)
			{
				to = new Position(from.X - 1, from.Y + 1);
				if (from.X > 0 && G[to] == null)
					advanceList.Add(new WMove(from, to, 0));

				to = new Position(from.X + 1, from.Y + 1);
				if (from.X < 7 && G[to] == null)
					advanceList.Add(new WMove(from, to, 0));
			}
			return advanceList;

		}

	}
}
