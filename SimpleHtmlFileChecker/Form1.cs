/* Name: Young Sang Kwon
 * Student Number: 000847777
 * Date: 2022 Nov 21
 * Programming in .NET - COMP-10204-01 (Professor: Peter Basl)
 * Purpose: A program that check HTML container tags by using Stack<T>
 * 
 * Statement of Authorship:
 * I, Young Sang Kwon, 000847777 certify that this material is my original work.  
 * No other person's work has been used without due acknowledgement.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab4b
{
    /// <summary>
    /// Class
    /// </summary>
    public partial class Form1 : Form
    {
        List<string> dataStr = new List<string>();
        Stack<string> tagStr = new Stack<string>();
        string fileName = "";
        int level = 0;
        bool inc = false;
        bool preInc = false;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataStr = new List<string>();
            tagStr = new Stack<string>();
            listBox.Items.Clear();

            try
            {
                openFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Processing file:{ex.Message}", "File Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Exit program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void localFileCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkTagsCtrlQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 0;
            inc = false;
            preInc = false;
            bool isMatch = true;

            foreach (string selStr in dataStr)
            {
                if (isMatch)
                {
                    for (int i = 0; i < selStr.Length; i++)
                    {
                        if (selStr[i] == '<')
                        {
                            if (selStr[i + 1] == 'h' && selStr[i + 2] == 't' && selStr[i + 3] == 'm' && selStr[i + 4] == 'l')
                            {
                                PushtoStack("html");
                            }
                            else if (selStr[i + 1] == 'b' && selStr[i + 2] == 'o' && selStr[i + 3] == 'd' && selStr[i + 4] == 'y')
                            {
                                PushtoStack("body");
                            }
                            else if (selStr[i + 1] == 't' && selStr[i + 2] == 'i' && selStr[i + 3] == 't' && selStr[i + 4] == 'l' && selStr[i + 5] == 'e')
                            {
                                PushtoStack("title");
                            }
                            else if (selStr[i + 1] == 't' && selStr[i + 2] == 'a' && selStr[i + 3] == 'b' && selStr[i + 4] == 'l' && selStr[i + 5] == 'e')
                            {
                                PushtoStack("table");
                            }
                            else if (selStr[i + 1] == 't' && selStr[i + 2] == 'r')
                            {
                                PushtoStack("tr");
                            }
                            else if (selStr[i + 1] == 't' && selStr[i + 2] == 'h')
                            {
                                PushtoStack("th");
                            }
                            else if (selStr[i + 1] == 't' && selStr[i + 2] == 'd')
                            {
                                PushtoStack("td");
                            }
                            else if (selStr[i + 1] == 'h' && selStr[i + 2] == '1')
                            {
                                PushtoStack("h1");
                            }
                            else if (selStr[i + 1] == 'h' && selStr[i + 2] == '2')
                            {
                                PushtoStack("h2");
                            }
                            else if (selStr[i + 1] == 'h' && selStr[i + 2] == '3')
                            {
                                PushtoStack("h3");
                            }
                            else if (selStr[i + 1] == 'h' && selStr[i + 2] == '4')
                            {
                                PushtoStack("h4");
                            }
                            else if (selStr[i + 1] == 'p' && selStr[i + 2] == '>')
                            {
                                PushtoStack("p");
                            }
                            else if (selStr[i + 1] == 'b' && selStr[i + 2] == '>')
                            {
                                PushtoStack("b");
                            }
                            else if (selStr[i + 1] == 'a')
                            {
                                PushtoStack("a");
                            }
                            else if (selStr[i + 1] == '/')
                            {
                                if (selStr[i + 2] == 'h' && selStr[i + 3] == 't' && selStr[i + 4] == 'm' && selStr[i + 5] == 'l')
                                {
                                    if (!PopFromStack("html"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'b' && selStr[i + 3] == 'o' && selStr[i + 4] == 'd' && selStr[i + 5] == 'y')
                                {
                                    if (!PopFromStack("body"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 't' && selStr[i + 3] == 'i' && selStr[i + 4] == 't' && selStr[i + 5] == 'l' && selStr[i + 6] == 'e')
                                {
                                    if (!PopFromStack("title"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 't' && selStr[i + 3] == 'a' && selStr[i + 4] == 'b' && selStr[i + 5] == 'l' && selStr[i + 6] == 'e')
                                {
                                    if (!PopFromStack("table"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 't' && selStr[i + 3] == 'r')
                                {
                                    if (!PopFromStack("tr"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 't' && selStr[i + 3] == 'h')
                                {
                                    if (!PopFromStack("th"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 't' && selStr[i + 3] == 'd')
                                {
                                    if (!PopFromStack("td"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'h' && selStr[i + 3] == '1')
                                {
                                    if (!PopFromStack("h1"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'h' && selStr[i + 3] == '2')
                                {
                                    if (!PopFromStack("h2"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'h' && selStr[i + 3] == '3')
                                {
                                    if (!PopFromStack("h3"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'h' && selStr[i + 3] == '4')
                                {
                                    if (!PopFromStack("h4"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'p' && selStr[i + 3] == '>')
                                {
                                    if (!PopFromStack("p"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'b' && selStr[i + 3] == '>')
                                {
                                    if (!PopFromStack("b"))
                                        isMatch = false;
                                }
                                else if (selStr[i + 2] == 'a' && selStr[i + 3] == '>')
                                {
                                    if (!PopFromStack("a"))
                                        isMatch = false;
                                }
                            }
                        }
                    }
                }
            }
            if (tagStr.Count == 0) // There is nothing in Stack
                label.Text = fileName + " balanced tags";
            else
                label.Text = fileName + " does not have balanced tags";
        }

        /// <summary>
        /// OpenFileDialog Class
        /// Reference: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-7.0
        /// </summary>
        /// <returns></returns>
        private void openFile()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "html files (*.html)|*.html";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileName = Path.GetFileName(filePath);

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        try
                        {   
                            while (!reader.EndOfStream)
                            {
                                string tagLine = reader.ReadLine().ToLower();
                                dataStr.Add(tagLine);
                            }
                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.Error.WriteLine($"Error reading file: {ex.Message}");
                        }
                    }
                }
            }
            label.Text = "Loaded: " + fileName;
        }

        /// <summary>
        /// Push to Stack by using stack<T>
        /// </summary>
        /// <param name="str"></param>
        private void PushtoStack(string str)
        {
            inc = true;
            if (preInc == inc) 
                level++;
            preInc = inc;
            tagStr.Push(str);
            string empty = "";
            for (int j = 0; j < level; j++)
                empty += "   ";
            listBox.Items.Add(empty + "Found opening tag: <" + str + ">");
        }

        /// <summary>
        /// Pop from Stack by using stack<T>
        /// </summary>
        /// <param name="str"></param>
        /// <returns>comparing value with Peek and expectation</returns>
        private bool PopFromStack(string str)
        {
            inc = false;
            if (preInc == inc) 
                level--;
            preInc = inc;
            if (tagStr.Peek() == str)
            {
                tagStr.Pop();
                string empty = "";
                for (int j = 0; j < level; j++)
                    empty += "   ";
                listBox.Items.Add(empty + "Found closing tag: </" + str + ">");
                return true;
            }
            else
            {
                tagStr.Pop();
                string empty = "";
                for (int j = 0; j < level; j++)
                    empty += "   ";
                listBox.Items.Add(empty + "Found closing tag: </" + str + ">");
                return false;
            }
        }
    }
}

