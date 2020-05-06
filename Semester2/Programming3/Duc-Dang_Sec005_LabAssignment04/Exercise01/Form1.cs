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

namespace Exercise01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Assigment04.BooksEntities dbcontext =
        new Assigment04.BooksEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            dbcontext.Titles.Load(); // load Titles table into memory

            // set the ComboBox to show the default query that
            // selects all books from the Titles table
            comboBox1.SelectedIndex = 0;

            var dbcontext1 = new Assigment04.BooksEntities();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: // all titles
                        // use LINQ to order the books by title
                    titleBindingSource.DataSource =
                       dbcontext.Titles.Local.OrderBy(book => book.Title1);
                    break;
                case 1: // titles with 2016 copyright
                        // use LINQ to get titles with 2016
                        // copyright and sort them by title
                    titleBindingSource.DataSource =
                       dbcontext.Titles.Local
                          .Where(book => book.Copyright == "2016")
                          .OrderBy(book => book.Title1);
                    break;
                case 2: // titles ending with "How to Program"
                        // use LINQ to get titles ending with
                        // "How to Program" and sort them by title
                    titleBindingSource.DataSource =
                       dbcontext.Titles.Local
                          .Where(
                             book => book.Title1.EndsWith("How to Program"))
                          .OrderBy(book => book.Title1);
                    break;
            }

            titleBindingSource.MoveFirst(); // move to first entry
        }
    }
}
