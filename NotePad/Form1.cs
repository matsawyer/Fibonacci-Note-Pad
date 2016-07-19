//Matthew Sawyer
//11252935
//CptS 322

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class FibonacciTextReader : TextReader
        {
            StringBuilder sbtrFib = new StringBuilder();
            int lines;
            //Constructor that takes integer parameter as max number of lines
            public FibonacciTextReader(int MaxLines)
            {
                lines = MaxLines;
            }
            //Class function to override the ReadtoEnd() function for assignment purposes
            public override string ReadToEnd()
            {

                StringBuilder sbFib = new StringBuilder();
                sbFib.Append("Fibonacci sequences incoming!");
                for (int i = 0; i < lines; i++)
                {
                    sbFib.AppendLine();
                    sbFib.Append(i + 1);
                    sbFib.Append(": ");
                    sbFib.Append(Fibonacci2(i));

                }
                string fib = sbFib.ToString();
                return (fib);
            }           
        }
        //Independent function to calculate Fibonacci sequence value at the n iteration
        static BigInteger Fibonacci2(int n)
        {
            if (n == 0) 
                return 0;
            if (n == 1) 
                return 1;
            BigInteger prev = 0;
            BigInteger curr = 1;
            BigInteger result = 0;

            for (int i = 2; i <= n; i++)
            {
                result = curr + prev;
                prev = curr;
                curr = result;
            }
            return result;
        }
        //This function is the Generic Loading Function called in my button click event functions for loading
        public void LoadText(TextReader sr) 
        {
            textBox1.Text = sr.ReadToEnd();
        }
        //Event attached to savefileDialog1
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        //Function attached to GUI form
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Event attached to openFileDialog1
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        //This is the button click event for Load, openFileDialog class example on MSDN .NET was referenced
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file_t = openFileDialog1.FileName;
                StreamReader open_file = new StreamReader(file_t);
                LoadText(open_file);
                open_file.Dispose();
            }
        }
        //This function defines the Load 50 fibonacci numbers button click event
        private void loadFibToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FibonacciTextReader TRfib = new FibonacciTextReader(50);
             LoadText(TRfib);            
        }
        //This function defines the Load 100 fibonacci numbers button click event
        private void loadFib100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader TRfib = new FibonacciTextReader(100);
            LoadText(TRfib); 
        }
        //Code structure from example on SaveFileDialog Class in MSDN .NET framework was partly referenced, but edited by me for assignment purposes
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {  
                    File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }
    }
}
