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

namespace BaseBall_Display_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Players.BaseballEntities dbcontext = new Players.BaseballEntities();
        private void searchButton_Click(object sender, EventArgs e)
        {
            var lastName = 
                from player in dbcontext.Players
                where player.LastName.StartsWith(findTextBox.Text)
                orderby player.LastName, player.FirstName
                select player;

            playerBindingSource.DataSource = lastName.ToList();
            playerBindingSource.MoveFirst();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //playerBindingSource.DataSource =
            //    from player in dbcontext.Players
            //    orderby player.PlayerID
            //    select player;
            dbcontext.Players.Load();
        }

        private void playersBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
            this.Validate();
            playerBindingSource.EndEdit();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerBindingSource.DataSource = dbcontext.Players.Local.OrderBy(player => player.PlayerID);
        }
    }
}
