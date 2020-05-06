using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbcontext = new Duc_Dang_COMP212_Sec003_Test02.BooksEntities();

            var booksByAuthor =
                from book in dbcontext.Titles
                
                orderby book.Title1
                select new
                {
                    Authors =
                        from a in book.Authors
                        orderby a.LastName, a.FirstName
                        select a.FirstName + " " + a.LastName,
                        
                    Titles = book.Title1
                };

            outputTextBox.AppendText("\r\n\r\n" + "Exercise01.a" );

            foreach (var book in booksByAuthor)
            {
                outputTextBox.AppendText("\r\n\t" + book.Titles + ":");
                outputTextBox.AppendText("\r\n\t" + "Number of authors who have written that title " + book.Authors.Count());
                outputTextBox.AppendText("\r\n\t");
            }


            var titlesByAuthor =
                from author in dbcontext.Authors

                orderby author.FirstName, author.LastName
                select new
                {
                    Books =
                        from a in author.Titles
                        orderby a.Title1
                        select a.Title1,

                    Authors = author.FirstName + "" + author.LastName
                };

            outputTextBox.AppendText("\r\n\r\n" + "Exercise01.b");

            foreach (var author in titlesByAuthor)
            {
                outputTextBox.AppendText("\r\n\t" + author.Authors + ":");
                foreach(var book in author.Books)
                {
                    outputTextBox.AppendText("\r\n\t\t" + book);
                }
                //outputTextBox.AppendText("\r\n\t" + "Number of authors who have written that title " + book.Authors.Count());
                //outputTextBox.AppendText("\r\n\t");
            }
        }
    }
}
