using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    internal class Cell
    {
        private Button button;
        private int number;

        public Cell()
        {
            button = new Button();
            button.Name = "Cell";
            button.Text = "";
            button.AutoSize = false;
            button.Size = new Size(50, 50);
            button.BackColor = Color.White;
            button.UseVisualStyleBackColor = true;
            button.Font = new Font(button.Font.Name, 20, FontStyle.Bold);
            number = 0;
        }

        public void Clear()
        {
            Number = 0;
        }

        public int Number
        {
            get { return number; }
            set { 
                number = value;
                if (number == 0)
                    button.Text = "";
                else
                    button.Text = number.ToString();
            }
        }

        public Button Button
        {
            get { return button; }
            set { button = value; }
        }
    }
}
