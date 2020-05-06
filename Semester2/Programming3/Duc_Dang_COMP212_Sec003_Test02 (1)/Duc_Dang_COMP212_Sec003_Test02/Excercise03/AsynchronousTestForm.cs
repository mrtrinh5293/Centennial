// AsynchronousTestForm.cs
// Fibonacci, Factorial and RollDie calculations performed in separate threads
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Linq;

namespace FibonacciFactorialRollDieAsynchronous
{
   public partial class AsynchronousTestForm : Form
   {
      public AsynchronousTestForm()
      {
         InitializeComponent();
      }

      // start asynchronous calls to Fibonacci
      private async void startButton_Click(object sender, EventArgs e)
      {
         outputTextBox.Text = "Starting Task to calculate Factorial(46)\r\n";

         // create Task to perform Fibonacci(46) calculation in a thread
         Task<TimeData> task1 = Task.Run(() => StartFactorial(46));

         outputTextBox.AppendText(
            "Starting Task to calculate Fibonacci(45)\r\n");

         // create Task to perform Fibonacci(45) calculation in a thread
         Task<TimeData> task2 = Task.Run(() => StartFibonacci(45));

            outputTextBox.AppendText(
                "Starting Task to calculate RollDie(60000000)\r\n");

            // create Task to perform StartRollDie(60000000) calculation in a thread
            Task<TimeData> task3 = Task.Run(() => StartRollDie(60000000));

            await Task.WhenAll(task1, task2, task3); // wait for all to complete

         // determine time that first thread started
         DateTime startTime =(task1.Result.StartTime < task2.Result.StartTime) ?
           ((task1.Result.StartTime < task3.Result.StartTime)? 
           task1.Result.StartTime:task3.Result.StartTime) :
           ((task2.Result.StartTime < task3.Result.StartTime) ?
           task2.Result.StartTime : task3.Result.StartTime);

         // determine time that last thread ended
         DateTime endTime = (task1.Result.EndTime > task2.Result.EndTime) ?
           ((task1.Result.EndTime > task3.Result.EndTime) ? 
           task1.Result.EndTime : task3.Result.EndTime) :
           ((task2.Result.EndTime > task3.Result.EndTime) ?
           task2.Result.EndTime : task3.Result.EndTime);

            // display total time for calculations
            double totalMinutes = (endTime - startTime).TotalMinutes;
         outputTextBox.AppendText(
            $"Total calculation time = {totalMinutes:F6} minutes\r\n");
      }

      // starts a call to fibonacci and captures start/end times
      TimeData StartFibonacci(int n)
      {
         // create a TimeData object to store start/end times
         var result = new TimeData();

         AppendText($"Calculating Fibonacci({n})");
         result.StartTime = DateTime.Now;
         long fibonacciValue = Fibonacci(n);
         result.EndTime = DateTime.Now;

         AppendText($"Fibonacci({n}) = {fibonacciValue}");
         double minutes = 
            (result.EndTime - result.StartTime).TotalMinutes;
         AppendText($"Calculation time = {minutes:F6} minutes\r\n");

         return result;
      }

        // starts a call to factorial and captures start/end times
        TimeData StartFactorial(int n)
        {
            // create a TimeData object to store start/end times
            var result = new TimeData();

            AppendText($"Calculating Factorial({n})");
            result.StartTime = DateTime.Now;
            BigInteger factorialValue = Factorial(n);
            result.EndTime = DateTime.Now;

            AppendText($"Factorial({n}) = {factorialValue}");
            double minutes =
               (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation time = {minutes:F6} minutes\r\n");

            return result;
        }

        // starts a call to rolldie and captures start/end times
        TimeData StartRollDie(long n)
        {
            // create a TimeData object to store start/end times
            var result = new TimeData();

            AppendText($"Calculating RollDie({n})");
            result.StartTime = DateTime.Now;
            BigInteger highestNoValue = RollDie(n);
            result.EndTime = DateTime.Now;

            AppendText($"Number appearing Highest times in Die Roll({n}) = {highestNoValue}");
            double minutes =
               (result.EndTime - result.StartTime).TotalMinutes;
            AppendText($"Calculation time = {minutes:F6} minutes\r\n");

            return result;
        }

        // Recursively calculates Factorial
        public BigInteger Factorial(BigInteger n)
        {
            if (n == 1) return 1;
            else return BigInteger.Multiply(Factorial(n - 1), n);
        }

        // Recursively calculates Fibonacci numbers
        public long Fibonacci(long n)
      {
         if (n == 0 || n == 1)
         {
            return n;
         }
         else
         {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
         }
      }

        public long RollDie(long n)
        {
            Random r = new Random();
            long[] dice = new long[6];

            for(long i=1;i<=n;i++)
            {
                dice[r.Next(0, 5)]++;
            }
            return dice.ToList().IndexOf(dice.Max())+1;
        }

      // append text to outputTextBox in UI thread
      public void AppendText(String text)
      {
         if (InvokeRequired) // not GUI thread, so add to GUI thread
         {
            Invoke(new MethodInvoker(() => AppendText(text)));
         }
         else // GUI thread so append text
         {
            outputTextBox.AppendText(text + "\r\n");
         }
      }
   }
}

