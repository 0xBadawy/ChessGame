using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Media;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Chess
{

    public partial class Chess : Form
    {
        public string VarPlayerName1 = ""; 
        public string VarPlayerName2 = "";
        public string Gametype = "Rapid";


        int secPlayer1 = 0;
        int minPlayer1 = 3;
        int secPlayer2 = 0;
        int minPlayer2 = 3;

        int secIncrement = 0;



        int numTurn = 0;
        enum Role { White, Gold }



        Color clr_celB = ColorTranslator.FromHtml("#604c37");
        Color clr_celW = ColorTranslator.FromHtml("#e0d8ce");
        Color clr_bac1k = ColorTranslator.FromHtml("#EFF5FB");
        Color clr_select = ColorTranslator.FromHtml("#c9a171");


        Color clr_White = ColorTranslator.FromHtml("#fffaf3");

        Color clr_Black = ColorTranslator.FromHtml("#3d2a12");


        private Button[,] board = new Button[8, 8];
        private int[,] boardValues = new int[8, 8], valuesCopy = new int[8, 8];

        private List<Bitmap> res = new List<Bitmap>
        {
            Properties.Resources._2Pawn,
            Properties.Resources._2Bishop,
            Properties.Resources._2Knight,
            Properties.Resources._2Rook,
            Properties.Resources._2Queen,
            Properties.Resources._2King,
            Properties.Resources.Pawn,
            Properties.Resources.Bishop,
            Properties.Resources.Knight,
            Properties.Resources.Rook,
            Properties.Resources.Queen,
            Properties.Resources.King
        };

        private List<Point> Moves = new List<Point>();

        private int[] dx = new int[4] { 1, -1, 0, 0 };
        private int[] dy = new int[4] { 0, 0, -1, 1 };

        private Point current = new Point(0, 0);

        private Role turn = Role.White;


        




        public Chess()
        {
            InitializeComponent();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    boardValues[i, j] = -1;
                    board[i, j] = new Button();
                    board[i, j].Size = new Size(90, 90);
                    board[i, j].Location = new Point(j * 90, i * 90);
                    board[i, j].Click += buttonClicked;
                    board[i, j].Cursor = Cursors.Hand;
                    board[i, j].FlatStyle = FlatStyle.Flat;
                    board[i, j].FlatAppearance.BorderSize = 1;
                    if ((i + j) % 2 == 0) board[i, j].BackColor = clr_celB;


                    else board[i, j].BackColor = clr_celW;
                    board[i, j].FlatAppearance.BorderColor = board[i, j].BackColor;
                    Controls.Add(board[i, j]);
                }
            }
            resize();
            place();
        }

        

        private bool safe(int row, int col){
            return row < 8 && col < 8 && row >= 0 && col >= 0;

        }
            

        private void buttonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int col = btn.Left / 90, row = btn.Top / 90;

            if (movePiece(btn, row, col)) return;

            if (!isRightTurn(row, col) && boardValues[row, col] != -1) return;


            resetBoard();

            current.X = col; current.Y = row;

            transition(row, col);

            for (int i = 0; i < Moves.Count; i++)
            {
                board[Moves[i].Y, Moves[i].X].BackColor = clr_select;
                board[Moves[i].Y, Moves[i].X].FlatAppearance.BorderColor
                    = clr_select;
            }
        }

        private void transition(int row, int col)
        {
            switch (boardValues[row, col])
            {
                case 0:
                    pawnGold(row, col);
                    break;
                case 6:
                    pawnWhite(row, col);
                    break;
                case 3:
                case 9:
                    rook(row, col);
                    break;
                case 1:
                case 7:
                    bishop(row, col);
                    break;
                case 2:
                case 8:
                    knight(row, col);
                    break;
                case 4:
                case 10:
                    queen(row, col);
                    break;
                case 5:
                case 11:
                    king(row, col);
                    break;
            }
        }

        private void pawnGold(int row, int col)
        {
            int fRow = boardValues[row + 1, col];
            if (fRow == -1)
                Moves.Add(new Point(col, row + 1));
            if (row == 1 && boardValues[row + 2, col] == -1 && fRow == -1)
                Moves.Add(new Point(col, row + 2));
            if (safe(row + 1, col + 1) && boardValues[row + 1, col + 1] > 5)
                Moves.Add(new Point(col + 1, row + 1));
            if (safe(row + 1, col - 1) && boardValues[row + 1, col - 1] > 5)
                Moves.Add(new Point(col - 1, row + 1));
        }

        private void pawnWhite(int row, int col)
        {
            int fRow = boardValues[row - 1, col];
            if (fRow == -1)
                Moves.Add(new Point(col, row - 1));
            if (row == 6 && boardValues[row - 2, col] == -1 && fRow == -1)
                Moves.Add(new Point(col, row - 2));
            if (safe(row - 1, col - 1) && boardValues[row - 1, col - 1] < 6
                && boardValues[row - 1, col - 1] != -1)
                Moves.Add(new Point(col - 1, row - 1));
            if (safe(row - 1, col + 1) && boardValues[row - 1, col + 1] < 6
                && boardValues[row - 1, col + 1] != -1)
                Moves.Add(new Point(col + 1, row - 1));
        }

        private void bishop(int row, int col)
        {
            int[] dk = new int[2] { 1, -1 };
            for (int i = 0; i < dk.Length; i++)
                for (int j = 0; j < dk.Length; j++)
                {
                    int cl = col, rw = row;
                    while (safe(cl + dk[i], rw + dk[j]))
                    {
                        if (boardValues[rw + dk[j], cl + dk[i]] != -1)
                        {
                            //last pick position
                            int cas = boardValues[row, col];
                            lastAdd(cas, rw + dk[j], cl + dk[i]);
                            break;
                        }
                        cl += dk[i]; rw += dk[j];
                        Moves.Add(new Point(cl, rw));
                    }
                }
        }

        private void knight(int row, int col)
        {
            int[] dh = new int[4] { -1, 1, -2, 2 };
            for (int i = 0; i < dh.Length; i++)
            {
                int comp = 3 - Math.Abs(dh[i]), cas = boardValues[row, col];
                if (safe(row + comp, col + dh[i])
                    && isEnemy(cas, row + comp, col + dh[i]))
                    Moves.Add(new Point(col + dh[i], row + comp));
                if (safe(row - comp, col + dh[i])
                    && isEnemy(cas, row - comp, col + dh[i]))
                    Moves.Add(new Point(col + dh[i], row - comp));
            }
        }

        private void rook(int row, int col)
        {
            for (int i = 0; i < dx.Length; i++)
            {
                int cl = col, rw = row;
                while (safe(cl + dx[i], rw + dy[i]))
                {
                    if (boardValues[rw + dy[i], cl + dx[i]] != -1)
                    {
                        int cas = boardValues[row, col];
                        lastAdd(cas, rw + dy[i], cl + dx[i]);
                        break;
                    }
                    cl += dx[i]; rw += dy[i];
                    Moves.Add(new Point(cl, rw));
                }
            }
        }

        private void queen(int row, int col)
        {
            rook(row, col);
            bishop(row, col);
        }

        private void king(int row, int col)
        {
            int[] dxking = { 0, 0, 1, 1, 1, -1, -1, -1 };
            int[] dyking = { 1, -1, 0, 1, -1, 1, -1, 0 };
            for (int i = 0; i < dxking.Length; i++)
                for (int j = 0; j < dyking.Length; j++)
                {
                    int cas = boardValues[row, col];
                    int cl = col + dxking[i], rw = row + dyking[j];
                    if (safe(cl, rw) && isEnemy(cas, rw, cl))
                        Moves.Add(new Point(cl, rw));
                }
        }

        private void resetBoard()
        {
            Moves.Clear();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    board[i, j].BackColor
                        = (i + j) % 2 == 0 ? clr_celB : clr_celW;
                    board[i, j].FlatAppearance.BorderColor = board[i, j].BackColor;
                }
        }

        private bool movePiece(Button btn, int row, int col)
        {
            if (Moves.Count == 0) return false;
            for (int i = 0; i < Moves.Count; i++)
            {
                if (Moves[i].X == col && Moves[i].Y == row)
                {
                    if (!isKingSafe(row, col, current.Y, current.X))
                    {
                        MessageBox.Show("not safe");
                        return false;
                    }
                    boardValues[row, col] = boardValues[current.Y, current.X];
                    board[row, col].Image = board[current.Y, current.X].Image;

                    boardValues[current.Y, current.X] = -1;
                    board[current.Y, current.X].Image = null;

                    turn = (turn == Role.White) ? Role.Gold : Role.White;

                    resetBoard();
                    playsound();
                    CheckPlayerName();

                    return true;
                }
            }
            resetBoard();
            return false;
        }

        private void CheckPlayerName()
        {
            numTurn++;
            if (numTurn % 2 == 0)
            {
                PlayerName1.Text = VarPlayerName1 ;
                PlayerName2.Text = VarPlayerName2;

                panelPlayer1.BackColor = clr_Black;
                panelPlayer2.BackColor = clr_White;


                label1.ForeColor =clr_White;
                PlayerName1.ForeColor = clr_Black;
                LableTimerPlayer2.ForeColor = clr_Black;


                label3.ForeColor =clr_White;
                PlayerName2.ForeColor =clr_White;
                LableTimerPlayer1.ForeColor =clr_White;

            }

            else
            {
                PlayerName1.Text = VarPlayerName1;
                PlayerName2.Text = VarPlayerName2;

                panelPlayer2.BackColor = clr_Black;
                panelPlayer1.BackColor = clr_White;



                label1.ForeColor = clr_White;
                PlayerName1.ForeColor =clr_White;
                LableTimerPlayer2.ForeColor =clr_White;


                label3.ForeColor = clr_White;
                PlayerName2.ForeColor = clr_Black;
                LableTimerPlayer1.ForeColor = clr_Black;








            }

        }

        bool isKingSafe(int row, int col, int currentRow, int currentCol)
        {
            int currentValue = boardValues[row, col];
            boardValues[row, col] = boardValues[currentRow, currentCol];
            boardValues[currentRow, currentCol] = -1;

            bool ans = true;
            int targetValue = turn == Role.Gold ? 5 : 11;

            for (int i = 0; i < boardValues.GetLength(0) && ans; i++)
                for (int j = 0; j < boardValues.GetLength(1) && ans; j++)
                {
                    Moves.Clear();
                    if (turn == Role.White && boardValues[i, j] == 6)
                        pawnWhite(i, j);
                    else if (turn == Role.Gold && boardValues[i, j] == 0)
                        pawnGold(i, j);
                    else if (boardValues[i, j] != -1) transition(i, j);
                    for (int x = 0; x < Moves.Count && ans; x++)
                        if (boardValues[Moves[x].Y, Moves[x].X] == targetValue)
                                ans = false;
                }

            boardValues[currentRow, currentCol] = boardValues[row, col];
            boardValues[row, col] = currentValue;
            return ans;
        }

        private bool isEnemy(int cas, int row, int col)
        {
            bool ans = boardValues[row, col] == -1;
            if (cas < 6 && boardValues[row, col] > 5) ans = true;
            else if (cas > 5 && boardValues[row, col] < 6) ans = true;
            return ans;
        }

        private void lastAdd(int cas, int row, int col)
        {
            if (cas > 5 && boardValues[row, col] < 6)
                Moves.Add(new Point(col, row));
            else if (cas < 6 && boardValues[row, col] > 5)
                Moves.Add(new Point(col, row));
        }

        private void place()
        {
            //Soliders
            for (int j = 0; j < board.GetLength(1); j++)
            {
                boardValues[1, j] = 0;
                board[1, j].Image = res[0];

                boardValues[6, j] = 6;
                board[6, j].Image = res[6];
            }

            //Rook
            board[0, 0].Image = board[0, 7].Image = res[3];
            boardValues[0, 0] = boardValues[0, 7] = 3;

            board[7, 0].Image = board[7, 7].Image = res[9];
            boardValues[7, 0] = boardValues[7, 7] = 9;

            //knight
            board[0, 1].Image = board[0, 6].Image = res[2];
            boardValues[0, 1] = boardValues[0, 6] = 2;

            board[7, 1].Image = board[7, 6].Image = res[8];
            boardValues[7, 1] = boardValues[7, 6] = 8;

            //bishop
            board[0, 2].Image = board[0, 5].Image = res[1];
            boardValues[0, 2] = boardValues[0, 5] = 1;

            board[7, 2].Image = board[7, 5].Image = res[7];
            boardValues[7, 2] = boardValues[7, 5] = 7;

            //Queen
            board[0, 3].Image = res[4];
            boardValues[0, 3] = 4;

            board[7, 3].Image = res[10];
            boardValues[7, 3] = 10;

            //King
            board[0, 4].Image = res[5];
            boardValues[0, 4] = 5;

            board[7, 4].Image = res[11];
            boardValues[7, 4] = 11;
        }

        private void resize()
        {
            Graphics graphic;
            for (int i = 0; i < res.Count; i++)
            {
                Bitmap bmp = new Bitmap(90, 90);
                graphic = Graphics.FromImage(bmp);
                graphic.DrawImage(res[i], 0, 0, 90, 90);
                graphic.Dispose();
                res[i] = bmp;
            }
        }

        private void playsound()
        {
            SoundPlayer sound = new SoundPlayer(Properties.Resources.sound);
            Thread th = new Thread(() =>
            {
                sound.Play();
            });
            th.Start();
        }

        bool isRightTurn(int row, int col)
        {
            return (turn == Role.White && boardValues[row, col] > 5)
                || (turn == Role.Gold && boardValues[row, col] < 6);
        }


        System.Timers .Timer timer = new System.Timers.Timer();

        public void Play()
        {

            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
               
               
                    GameBlitz();
                    

              






            }));

            throw new NotImplementedException();
        }

        private void GameBlitz()
        {
          

            if (numTurn % 2 == 0)
            {
                secPlayer1--;
                if (secPlayer1 < 0)
                {
                    secPlayer1 = 59;
                    minPlayer1--;

                }
                if (minPlayer1 == 0 && secPlayer1 == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Time is up");
                }
                LableTimerPlayer1.Text = minPlayer1.ToString() + ":" + secPlayer1.ToString();
            }
            else
            {
                secPlayer2--;
                if (secPlayer2 < 0)
                {
                    secPlayer2 = 59;
                    minPlayer2--;
                }
                if (minPlayer2 == 0 && secPlayer2 == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Time is up");
                }
                    LableTimerPlayer2.Text = minPlayer2.ToString() + ":" + secPlayer2.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LableTimerPlayer2_Click(object sender, EventArgs e)
        {

        }

        private void Chess_Load(object sender, EventArgs e)
        {
            Play();

            GameTypeLable.Text= Gametype;

            if (Gametype== "Blitz")
            {
                secPlayer1 = 0;
                minPlayer1 = 3;
                secPlayer2 = 0;
                minPlayer2 = 3;

                secIncrement+=2;
            }
            else if (Gametype == "Bullet")
            {
                secPlayer1 = 0;
                minPlayer1 = 1;
                secPlayer2 = 0;
                minPlayer2 = 1;



            }
            else if (Gametype == "Rapid")
            {
                secPlayer1 = 0;
                minPlayer1 = 10;
                secPlayer2 = 0;
                minPlayer2 = 10;

                secIncrement+=5;


            }
            else if (Gametype == "Classical")
            {

                secPlayer1 = 0;
                minPlayer1 = 30;
                secPlayer2 = 0;
                minPlayer2 = 30;
            }          
            else
            {
                secPlayer1 = 0;
                minPlayer1 = 3;
                secPlayer2 = 0;
                minPlayer2 = 3;
            }




            BackColor = clr_bac1k;
            CheckPlayerName();
        }

    }
}
