using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dbcontext = new Assigment04.BooksEntities();

            var authorsAndTitles =
            from book in dbcontext.Titles
            from author in book.Authors
            orderby book.Title1
  
            select new {  
                book.Title1, author.FirstName, author.LastName
            };

            outputTextBox.AppendText("\r\n\r\n1. Sort By Title:");

            // display authors and titles in tabular format
            foreach (var element in authorsAndTitles)
            {
                outputTextBox.AppendText($"\r\n\t {element.Title1,-60} " +
                   $" {element.FirstName,-10}  {element.LastName} ");
            }
            /////////////////////////////////////////////////////////////////////////////

           var authorsForeachTitles =
            from book in dbcontext.Titles
            orderby book.Title1
            select new
            {
                Authors =
                    from a in book.Authors
                    orderby  a.FirstName, a.LastName
                    select a.FirstName + " " + a.LastName,

                Titles = book.Title1
            };

            outputTextBox.AppendText("\r\n\r\n2. Authors and titles with authors sorted for each title:");

            // display authors and titles in tabular format
            foreach (var element in authorsForeachTitles)
            {
                
                foreach (var author in element.Authors)
                {
                    outputTextBox.AppendText($"\r\n\t {element.Titles,-60} " +
                   $" {author} ");
                }
            }

            //////////////////////////////////////////////////////////////////////////////
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

            outputTextBox.AppendText("\r\n\r\n3. Sort Author By Book Title:");

            foreach (var book in booksByAuthor)
            {
                //display book's title
                outputTextBox.AppendText("\r\n\t" + book.Titles + ":");

                // display authors of that book
                foreach (var author in book.Authors)
                {
                    outputTextBox.AppendText("\r\n\t\t" + author);
                }
            }
        }

        private void outputTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
