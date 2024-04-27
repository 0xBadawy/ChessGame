using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chess chess = new Chess();

            if (Player1.Text == "")chess.VarPlayerName1 = "Player Num 1";
            else chess.VarPlayerName1 = Player1.Text;

            if (Player2.Text == "") chess.VarPlayerName2 = "Player Num 2";
            else chess.VarPlayerName2 = Player2.Text;

            chess.Gametype = comboBox1.Text;

            chess.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
