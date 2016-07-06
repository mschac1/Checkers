using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Checkers;
namespace VCheckers
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private boardLabel [ , ] board = new boardLabel[8, 8];
		private Game game = new Game();
		private Position moveFrom;
		private Position moveTo;
		private bool moveFlag = false;
		private string player = "black";
		private string opponent = "red";
		private int players = 2;
		private int AIDepth = 0;
		private int maxAIDepth = 6;
		private System.Windows.Forms.MenuItem [] AILevel;

		private System.Windows.Forms.Label RedKing;
		private System.Windows.Forms.Label BlackPawn;
		private System.Windows.Forms.Label BlackKing;
		private System.Windows.Forms.Label RedPawn;
		private System.Windows.Forms.Label template;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuNewGame;
		private System.Windows.Forms.MenuItem mnuExit;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.Timer tmrCvsC;
		private System.Windows.Forms.MenuItem mnuPlayer2;
		private System.Windows.Forms.MenuItem mnuPlayer1;
		private System.Windows.Forms.MenuItem mnuPlayer0;
		private System.Windows.Forms.MenuItem mnuRed;
		private System.Windows.Forms.MenuItem mnuBlack;
		private System.Windows.Forms.Label StatusBar;
		private System.Windows.Forms.Label lblTurn;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.MenuItem mnuAI;
		private System.Windows.Forms.MenuItem mnuLevel;
		private System.ComponentModel .IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitializeMyComponents();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.RedKing = new System.Windows.Forms.Label();
			this.BlackPawn = new System.Windows.Forms.Label();
			this.BlackKing = new System.Windows.Forms.Label();
			this.RedPawn = new System.Windows.Forms.Label();
			this.template = new System.Windows.Forms.Label();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNewGame = new System.Windows.Forms.MenuItem();
			this.mnuExit = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuPlayer2 = new System.Windows.Forms.MenuItem();
			this.mnuPlayer1 = new System.Windows.Forms.MenuItem();
			this.mnuRed = new System.Windows.Forms.MenuItem();
			this.mnuBlack = new System.Windows.Forms.MenuItem();
			this.mnuPlayer0 = new System.Windows.Forms.MenuItem();
			this.tmrCvsC = new System.Windows.Forms.Timer(this.components);
			this.StatusBar = new System.Windows.Forms.Label();
			this.lblTurn = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.mnuAI = new System.Windows.Forms.MenuItem();
			this.mnuLevel = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// RedKing
			// 
			this.RedKing.Image = ((System.Drawing.Bitmap)(resources.GetObject("RedKing.Image")));
			this.RedKing.Location = new System.Drawing.Point(152, 8);
			this.RedKing.Name = "RedKing";
			this.RedKing.Size = new System.Drawing.Size(64, 64);
			this.RedKing.TabIndex = 0;
			this.RedKing.Visible = false;
			// 
			// BlackPawn
			// 
			this.BlackPawn.Image = ((System.Drawing.Bitmap)(resources.GetObject("BlackPawn.Image")));
			this.BlackPawn.Location = new System.Drawing.Point(80, 8);
			this.BlackPawn.Name = "BlackPawn";
			this.BlackPawn.Size = new System.Drawing.Size(64, 64);
			this.BlackPawn.TabIndex = 1;
			this.BlackPawn.Visible = false;
			// 
			// BlackKing
			// 
			this.BlackKing.Image = ((System.Drawing.Bitmap)(resources.GetObject("BlackKing.Image")));
			this.BlackKing.Location = new System.Drawing.Point(8, 8);
			this.BlackKing.Name = "BlackKing";
			this.BlackKing.Size = new System.Drawing.Size(64, 64);
			this.BlackKing.TabIndex = 2;
			this.BlackKing.Visible = false;
			// 
			// RedPawn
			// 
			this.RedPawn.Image = ((System.Drawing.Bitmap)(resources.GetObject("RedPawn.Image")));
			this.RedPawn.Location = new System.Drawing.Point(224, 8);
			this.RedPawn.Name = "RedPawn";
			this.RedPawn.Size = new System.Drawing.Size(64, 64);
			this.RedPawn.TabIndex = 3;
			this.RedPawn.Visible = false;
			// 
			// template
			// 
			this.template.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.template.Location = new System.Drawing.Point(8, 80);
			this.template.Name = "template";
			this.template.Size = new System.Drawing.Size(72, 72);
			this.template.TabIndex = 4;
			this.template.Visible = false;
			this.template.Click += new System.EventHandler(this.template_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.menuItem1,
																					  this.mnuAI});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNewGame,
																					this.mnuExit});
			this.mnuFile.Text = "&File";
			// 
			// mnuNewGame
			// 
			this.mnuNewGame.Index = 0;
			this.mnuNewGame.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.mnuNewGame.Text = "&New Game";
			this.mnuNewGame.Click += new System.EventHandler(this.newGame);
			// 
			// mnuExit
			// 
			this.mnuExit.Index = 1;
			this.mnuExit.Text = "E&xit";
			this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuPlayer2,
																					  this.mnuPlayer1,
																					  this.mnuPlayer0});
			this.menuItem1.Text = "&Players";
			// 
			// mnuPlayer2
			// 
			this.mnuPlayer2.Checked = true;
			this.mnuPlayer2.Index = 0;
			this.mnuPlayer2.Text = "Player vs Player";
			this.mnuPlayer2.Click += new System.EventHandler(this.mnuPlayer2_Click);
			// 
			// mnuPlayer1
			// 
			this.mnuPlayer1.Index = 1;
			this.mnuPlayer1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuRed,
																					   this.mnuBlack});
			this.mnuPlayer1.Text = "Player vs Comp";
			this.mnuPlayer1.Click += new System.EventHandler(this.mnuPlayer2_Click);
			// 
			// mnuRed
			// 
			this.mnuRed.Index = 0;
			this.mnuRed.Text = "Play as Red";
			this.mnuRed.Click += new System.EventHandler(this.mnuRed_Click);
			// 
			// mnuBlack
			// 
			this.mnuBlack.Index = 1;
			this.mnuBlack.Text = "Play as Black";
			this.mnuBlack.Click += new System.EventHandler(this.mnuBlack_Click);
			// 
			// mnuPlayer0
			// 
			this.mnuPlayer0.Index = 2;
			this.mnuPlayer0.Text = "Comp vs Comp";
			this.mnuPlayer0.Click += new System.EventHandler(this.mnuPlayer0_Click);
			// 
			// tmrCvsC
			// 
			this.tmrCvsC.Interval = 750;
			this.tmrCvsC.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// StatusBar
			// 
			this.StatusBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.StatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.StatusBar.Location = new System.Drawing.Point(0, 344);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(440, 40);
			this.StatusBar.TabIndex = 7;
			// 
			// lblTurn
			// 
			this.lblTurn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblTurn.Location = new System.Drawing.Point(16, 352);
			this.lblTurn.Name = "lblTurn";
			this.lblTurn.Size = new System.Drawing.Size(64, 24);
			this.lblTurn.TabIndex = 9;
			this.lblTurn.Text = "Turn: black";
			this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblStatus
			// 
			this.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblStatus.Location = new System.Drawing.Point(128, 352);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(216, 24);
			this.lblStatus.TabIndex = 8;
			this.lblStatus.Text = "Status";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mnuAI
			// 
			this.mnuAI.Index = 2;
			this.mnuAI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.mnuLevel});
			this.mnuAI.Text = "AI";
			// 
			// mnuLevel
			// 
			this.mnuLevel.Index = 0;
			this.mnuLevel.Text = "Level";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1028, 725);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblTurn,
																		  this.lblStatus,
																		  this.StatusBar,
																		  this.template,
																		  this.RedPawn,
																		  this.BlackKing,
																		  this.BlackPawn,
																		  this.RedKing});
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void InitializeMyComponents()
		{
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					board[i, j] = new boardLabel();

					board[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
					board[i, j].Location = new System.Drawing.Point(i * template.Width, (7 - j) * template.Height);
					board[i, j].Size = template.Size;
					board[i, j].TabStop = false;
					board[i, j].Visible = true;
					board[i, j].X = i;
					board[i, j].Y = j;
					board[i, j].Click += new System.EventHandler(this.template_Click);


					if ((i + j) % 2 == 1)
					{
						board[i, j].BackColor = System.Drawing.Color.Red;
						board[i, j].color = "Red";
					}
					else
					{
						board[i, j].BackColor = System.Drawing.Color.Black;
						board[i, j].color = "Black";
					}

					Controls.AddRange(new System.Windows.Forms.Control[] {board[i, j]});

				}

			}

			AILevel = new System.Windows.Forms.MenuItem[maxAIDepth + 1];
			for (int i = 0; i < maxAIDepth + 1; i++)
			{
				AILevel[i] = new System.Windows.Forms.MenuItem();
				AILevel[i].Text = Convert.ToString(i);
				AILevel[i].Click += new System.EventHandler(this.AILevel_Click); 
				this.mnuLevel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {AILevel[i]});
			}
			AILevel[0].Checked = true;
				
			//				Height = 8 * template.Height + lblStatus.Height + 32;
			//				Width = 8 * template.Width + 6;

			StatusBar.Top = template.Height *  8;// + 34;
			Height = StatusBar.Top + StatusBar.Height + 32;//lblTemplate.Height *  8 + 34;
			Width = template.Width * 8 + 6;
			StatusBar.Width = template.Width * 8;

			lblTurn.Top = StatusBar.Top + 8;
			lblStatus.Top = StatusBar.Top + 8;
			lblStatus.Left = (Width - lblStatus.Width) / 2;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void RefreshBoard()
		{
			if (game.gameOver == Checkers.Game.RED)
				lblStatus.Text = "RED WINS!!!";
			else if (game.gameOver == Checkers.Game.BLACK)
				lblStatus.Text = "BLACK WINS!!!";
			else if (game.gameOver == Checkers.Game.TIE)
				lblStatus.Text = "Tie game";

			if (game.Turn == "red")
				lblTurn.Text = "Turn: Red";
			else
				lblTurn.Text = "Turn: Black";

			Position current;
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					if (player == "black")
						current = new Position(i, j);
					else
						current = new Position(7 - i, 7 - j);

					if (game[current] == null)
						board[i, j].Image = null;
					else
					{
						if (game[current].Color == "black")
						{
							if (game[current].Rank == "pawn")
								board[i, j].Image = BlackPawn.Image;
							else
								board[i, j].Image = BlackKing.Image;
						}
						else 
						{
							if (game[current].Rank == "pawn")
								board[i, j].Image = RedPawn.Image;
							else
								board[i, j].Image = RedKing.Image;
						}
					}				
				}
			}
			// 1 player
			if (players == 1 && game.Turn == opponent && game.gameOver == Game.NONE)
			{
				this.Refresh();
				if (AIDepth < 5)
					System.Threading.Thread.Sleep(750);

				WMove m = (WMove) CheckersAI.AIMove(game, opponent, AIDepth);
				MovePiece(m.from, m.to);
				this.Text = m.weight.ToString();
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			newGame();
		}

		private void newGame(object sender, System.EventArgs e)
		{
			newGame();
		}

		private void mnuPlayer2_Click(object sender, System.EventArgs e)
		{
			mnuPlayer0.Checked = false;
			mnuPlayer2.Checked = true;
			mnuRed.Checked = false;
			mnuBlack.Checked = false;
			tmrCvsC.Enabled = false;
			players = 2;
			player = "black";
			opponent = "red";
			newGame();
		}

		private void mnuRed_Click(object sender, System.EventArgs e)
		{
			mnuPlayer0.Checked = false;
			mnuPlayer2.Checked = false;
			mnuRed.Checked = true;
			mnuBlack.Checked = false;
			tmrCvsC.Enabled = false;
			players = 1;
			player = "red";
			opponent = "black";
			newGame();
		}

		private void mnuBlack_Click(object sender, System.EventArgs e)
		{
			mnuPlayer0.Checked = false;
			mnuPlayer2.Checked = false;
			mnuRed.Checked = false;
			mnuBlack.Checked = true;
			tmrCvsC.Enabled = false;
			players = 1;
			player = "black";
			opponent = "red";
			newGame();
		}

		private void mnuPlayer0_Click(object sender, System.EventArgs e)
		{
			mnuPlayer0.Checked = true;
			mnuPlayer2.Checked = false;
			mnuRed.Checked = false;
			mnuBlack.Checked = false;
			tmrCvsC.Enabled = true;
			players = 0;
			player = "black";
			opponent = "red";
			newGame();
		}
		private void AILevel_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < maxAIDepth + 1; i++)
			{
				AILevel[i].Checked = false;
			}
			((System.Windows.Forms.MenuItem) sender).Checked = true;
			AIDepth = Convert.ToInt32(((System.Windows.Forms.MenuItem) sender).Text);
		}
			
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (game.gameOver == Game.NONE)
			{
				Move m = (Move) CheckersAI.AIMove(game, game.Turn, AIDepth);
				MovePiece(m.from, m.to);
			}
		}

		private void mnuExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit(); 
		}

		private void template_Click(object sender, System.EventArgs e)
		{
			if (players == 0 || (players == 1 && game.Turn == opponent))
				return;
			
			boardLabel lbl = (boardLabel) sender;
			// label1.Text = lbl.X + " " + lbl.Y;
			if (moveFlag == false && lbl.Image != null)
			{
				if (player == "black")
					moveFrom = new Position(lbl.X,lbl.Y);
				else
					moveFrom = new Position(7 - lbl.X,7 - lbl.Y);
				moveFlag = true;
				lblStatus.Text = "Moving: " + game[moveFrom].Color + " " + game[moveFrom].Rank;
			}
			else if (moveFlag == true)
			{
				if (player == "black")
					moveTo = new Position(lbl.X,lbl.Y);
				else
					moveTo = new Position(7 - lbl.X,7 - lbl.Y);
				moveFlag = false;
				MovePiece(moveFrom, moveTo);
			}
		}
		private void MovePiece (Position moveFrom, Position moveTo)
		{
			bool valid = game.MovePiece(moveFrom, moveTo);
			if (valid == false)
				lblStatus.Text = "Invalid Move";

			RefreshBoard();
		}

		private void newGame()
		{
			game.newGame();
			RefreshBoard();
			moveFlag = false;
		
		}

	}

	public class boardLabel : System.Windows.Forms.Label
	{
		public int X;
		public int Y;
		public string color;
	}

}
