using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class MainForm : Form
    {
        static class Direction
        {
            public const int UP = 0;
            public const int DOWN = 1;
            public const int LEFT = 2;
            public const int RIGHT = 3;
        }

        public struct MyPoint
        {
            public MyPoint(int y, int x)
            {
                Y = y;
                X = x;
            }
            public int Y { get; }
            public int X { get; }
        }

        private List<Cell> cells = new List<Cell>();
        private List<int[,]> solvingProc= new List<int[,]>();
        private List<MyPoint> validCheck = new List<MyPoint>();
        private bool isSolved = false;
        private bool finish = false;
        private int[,] board = new int[9, 9];
        private int viewIndex = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MakeBoard();
            integratedTrackBar.Value = integratedTrackBar.Maximum;
            timer.Interval = integratedTrackBar.Maximum - integratedTrackBar.Value + 1;
        }

        private void MakeBoard()
        {
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    Cell cell = new Cell();
                    cell.Button.Location = new Point(j*cell.Button.Width + j/3*10, i*cell.Button.Height + i/3*10);
                    cell.Button.Tag = i * 9 + j;
                    cell.Button.KeyDown += cell_KeyDown;
                    boardPanel.Controls.Add(cell.Button);
                    cells.Add(cell);
                }
            }
        }

        private void cell_KeyDown(object sender, KeyEventArgs e)
        {
            Button button = sender as Button;

            int index = (int)button.Tag;

            //MessageBox.Show(e.KeyValue.ToString() + ' ' + e.KeyData.ToString());
            CellTextChange(index, e.KeyValue);
        }

        private void CellTextChange(int index, int key)
        {
            int num = -1;
            if (key>=48 && key < 58) //Keypad Numer
                num = key - 48;
            else if(key>=96 && key < 106) //Numpad Number
                num = key - 96;
            else // WASD
            {
                if (key == 65)//A
                    SelectMove(index, Direction.LEFT);
                else if (key == 68)//D
                    SelectMove(index, Direction.RIGHT);
                else if (key == 83)//S
                    SelectMove(index, Direction.DOWN);
                else if (key == 87)//W
                    SelectMove(index, Direction.UP);
            }

            if(num != -1)
            {
                if (IsValid(index / 9, index % 9, num))
                {
                    cells[index].Number = num;
                    board[index / 9, index % 9] = num;
                }
                else
                {
                    MessageBox.Show("잘 못 입력하시지 않았는지 확인해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsInBoard(int y, int x)
        {
            return y>=0 && x>=0 && y<9 && x<9;
        }

        private void SelectMove(int index, int dir)
        {
            int x = index % 9, y = index / 9;
            switch (dir)
            {
                case Direction.UP:
                    y--;
                    break;
                case Direction.DOWN:
                    y++;
                    break;
                case Direction.LEFT:
                    x--;
                    break;
                case Direction.RIGHT:
                    x++;
                    break;
            }
            if (IsInBoard(y, x))
                index = y * 9 + x;

            cells[index].Button.Select();
        }

        private void WriteBoard()
        {
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    cells[i*9+j].Number = board[i,j];
                }
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                {
                    if (board[i, j] == 0)
                    {
                        validCheck.Add(new MyPoint(i, j));
                    }
                    if (!procViewCheckBox.Checked)
                    {
                        procViewCheckBox.Enabled= false;
                        integratedTrackBar.Enabled= false;
                    }
                    initButton.Enabled = false;
                    solveButton.Enabled = false;
                    cells[i * 9 + j].Button.Enabled = false;
                }

            Backtracking(0);

            if(isSolved)
            {
                if (procViewCheckBox.Checked)
                {
                    timer.Start();
                }
                else
                {
                    board = solvingProc[solvingProc.Count - 1];
                    WriteBoard();
                    HaveBeenSolved();
                }
            }
            else
            {
                MessageBox.Show("해결 할 수 없는 스도쿠 입니다.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initButton.Enabled = true;
            }
        }

        private void HaveBeenSolved()
        {
            initButton.Enabled = true;
            finish = true;
            rightLabel.Text = "현재로";
            leftLabel.Text = "과거로";
            integratedTrackBar.Maximum = solvingProc.Count - 1;
            integratedTrackBar.Value = integratedTrackBar.Maximum;
        }

        private bool IsValid(int y, int x, int n)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[y, i] == n || board[i, x] == n || board[y / 3 * 3 + i / 3, x / 3 * 3 + i % 3] == n)
                {
                    return false;
                }
            }
            return true;
        }

        private void Backtracking(int index)
        {
            if (index >= validCheck.Count)
            {
                if (!isSolved)
                    solvingProc.Add(board.Clone() as int[,]);
                validCheck.Clear();
                isSolved = true;
                return;
            }

            if (procViewCheckBox.Checked && !isSolved)
                solvingProc.Add(board.Clone() as int[,]);

            int x = validCheck[index].X, y = validCheck[index].Y;
            for(int i=1; i<=9; i++)
            {
                if (IsValid(y, x, i))
                {
                    board[y, x] = i;
                    Backtracking(index + 1);
                    board[y, x] = 0;
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (viewIndex > solvingProc.Count - 1)
            {
                timer.Stop();
                initButton.Enabled = true;
                HaveBeenSolved();
                return;
            }
            else if (!procViewCheckBox.Checked)
            {
                timer.Stop();
                initButton.Enabled = true;
                board = solvingProc[solvingProc.Count - 1];
                WriteBoard();
                HaveBeenSolved();
                return;
            }

            board = solvingProc[viewIndex++];
            WriteBoard();
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                {
                    board[i, j] = 0;
                    cells[i * 9 + j].Number = 0;
                    cells[i * 9 + j].Button.Enabled = true;
                }

            validCheck.Clear();
            solvingProc.Clear();
            isSolved = false;
            viewIndex = 0;

            procViewCheckBox.Enabled = true;
            solveButton.Enabled = true;
            integratedTrackBar.Enabled = true;
            rightLabel.Text = "빠르게";
            leftLabel.Text = "느리게";
            integratedTrackBar.Maximum = 200;
            integratedTrackBar.Value = integratedTrackBar.Maximum;
            finish = false;
        }

        private void integratedTrackBar_Scroll(object sender, EventArgs e)
        {
            if (finish)
            {
                int index = integratedTrackBar.Value;
                board = solvingProc[index];
                WriteBoard();
            }
            else
            {
                int viewSpeed = integratedTrackBar.Maximum - integratedTrackBar.Value + 1;
                timer.Interval = viewSpeed;
            }
        }

        private void procViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (procViewCheckBox.Checked)
            {
                integratedTrackBar.Visible = true;
                rightLabel.Visible = true;
                leftLabel.Visible = true;
            }
            else
            {
                integratedTrackBar.Visible = false;
                rightLabel.Visible= false;
                leftLabel.Visible= false;
            }
        }
    }
}
