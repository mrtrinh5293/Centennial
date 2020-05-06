using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BaseBall.BaseballEntities dbcontext = new BaseBall.BaseballEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            dbcontext.Players.Load();
        }

        private void playersBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            this.Validate();
            playerBindingSource.EndEdit();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            playerBindingSource.DataSource = dbcontext.Players.Local.OrderBy(player => player.PlayerID);
        }

        private void searchButton_Click_1(object sender, EventArgs e)
        {
            var lastName =
                from player in dbcontext.Players
                where player.LastName.StartsWith(findTextBox.Text)
                orderby player.LastName, player.FirstName
                select player;

            playerBindingSource.DataSource = lastName.ToList();
            playerBindingSource.MoveFirst();
        }

        private void btnSearchById_Click(object sender, EventArgs e)
        {
            var playerID =
                from player in dbcontext.Players
                where player.PlayerID.ToString().StartsWith(textBox_ID.Text)
                orderby player.LastName, player.FirstName
                select player;

            playerBindingSource.DataSource = playerID.ToList();
            playerBindingSource.MoveFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var battingAverage =
                (from player in dbcontext.Players
                    /*group player by 0 into p
                    select new
                    {
                        value1 = p.Average(player => player.BattingAverage
                    };*/
                select player.BattingAverage).Average();

            label3.Text = Math.Round(battingAverage,3).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var highestScore =
                (from player in dbcontext.Players
                 where player.BattingAverage.Equals(dbcontext.Players.Select(x => x.BattingAverage).Max())
                 select player.FirstName.ToString() + " " + player.LastName.ToString()).Single();
                 
                

            label4.Text = highestScore.ToString();
        }
    }
}

