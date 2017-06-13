using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace Notepad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string contents = String.Empty;
        
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainRichTextBox.Text != String.Empty)
            {
                DialogResult dr = MessageBox.Show("Do you want to save the changes? \n\n\t" + this.Text, "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Title = "Save";
                    save.Title = "Save File";
                    save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                    if (save.ShowDialog() == DialogResult.OK)
                    {
                        MainRichTextBox.LoadFile(File.ReadAllText(save.FileName));
                        this.Text = save.FileName;
                    }
                    if (MainRichTextBox.Text == " ")
                        return;
                    else
                    {
                        MainRichTextBox.Text = "";
                        this.Text = "Untitled";
                    }
                    contents = "";
                }
                else if (dr == DialogResult.No)
                {
                    MainRichTextBox.Text = "";
                    this.Text = "Untitled";
                    contents = "";
                }
                else
                {
                    MainRichTextBox.Focus();
                }
            }
            else
            {
                this.Text = "Untitled";
                MainRichTextBox.Text = "";
                contents = "";
                MainRichTextBox.Text = " ";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All Rights Reserved By the author. For more details Please contact with us: abduhalimbek@gmail.com", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            undoToolStripMenuItem.Enabled = true;
            redoToolStripMenuItem.Enabled = false;
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void MainRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (MainRichTextBox.Text.Length>0)
            {
                undoToolStripMenuItem.Enabled = true;
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
                boldToolStripMenuItem1.Enabled = true;
                normalToolStripMenuItem.Enabled = true;
                strikeThroughToolStripMenuItem.Enabled = true;
                underlineToolStripMenuItem.Enabled = true;


            }
            else
            {
                boldToolStripMenuItem1.Enabled = false;
                normalToolStripMenuItem.Enabled = false;
                strikeThroughToolStripMenuItem.Enabled = false;
                underlineToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem.Enabled = false;
                redoToolStripMenuItem.Enabled = false;
            }
            
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Text = MainRichTextBox.Text + DateTime.Now;
        }

        private void italicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Italic);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Regular);
        }

        private void boldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Bold);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Underline);
        }

        private void strikeThroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, FontStyle.Strikeout);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save=new SaveFileDialog();
            
            save.Title = "Save File";
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                MainRichTextBox.LoadFile(File.ReadAllText(save.FileName));
                this.Text = save.FileName;
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open";
            open.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (open.ShowDialog()==DialogResult.OK)
            {
                MainRichTextBox.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
                this.Text = open.FileName;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveas = new SaveFileDialog();

            saveas.Title = "Save as";
            saveas.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveas.ShowDialog() == DialogResult.OK)
            {
                MainRichTextBox.LoadFile(saveas.FileName, RichTextBoxStreamType.RichText);
                this.Text = saveas.FileName;
            }

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
             fontDialog1.ShowColor = true;
            
                fontDialog1.ShowEffects = true;
            
            if (fontDialog1.ShowDialog(this) == DialogResult.OK & !string.IsNullOrEmpty(MainRichTextBox.Text))
                
            {
                MainRichTextBox.SelectionFont = fontDialog1.Font;
                MainRichTextBox.SelectionColor = fontDialog1.Color;
                //MainRichTextBox.ForeColor = fontDialog1.Color;
                // MainRichTextBox.Font = fontDialog1.Font;
                //MainRichTextBox.SelectedText = fontDialog1.Color;
                
            }

        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open";
            open.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                MainRichTextBox.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
                this.Text = open.FileName;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation either version 2 of the License, or (at your option) any later version. This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more tails "
                        , "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            int index = 0;
            string temp = MainRichTextBox.Text;
            MainRichTextBox.Text = "";
            MainRichTextBox.Text = temp;
            while (index < MainRichTextBox.Text.LastIndexOf(textBox1.Text))
            {
                MainRichTextBox.Find(textBox1.Text, index, MainRichTextBox.TextLength, RichTextBoxFinds.None);
                MainRichTextBox.SelectionBackColor = Color.Yellow;
                index = MainRichTextBox.Text.IndexOf(textBox1.Text, index) + 1;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = "";
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Copy();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Cut();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Print Document";
            printDlg.Document = printDoc;
            printDlg.AllowSelection = true;
            printDlg.AllowSomePages = true;
            //Call ShowDialog
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Title = "Save File";
            save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                MainRichTextBox.LoadFile(File.ReadAllText(save.FileName));
                this.Text = save.FileName;
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to save the changes? \n\n\t" + this.Text, "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save";
                save.Title = "Save File";
                save.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    MainRichTextBox.LoadFile(File.ReadAllText(save.FileName));
                    this.Text = save.FileName;
                }
                if (MainRichTextBox.Text == " ")
                    return;
                else
                {
                    MainRichTextBox.Text = "";
                    this.Text = "Untitled";
                }
                contents = "";
            }
            else if (dr == DialogResult.No)
            {
                MainRichTextBox.Text = "";
                this.Text = "Untitled";
                contents = "";
            }
            else
            {
                MainRichTextBox.Focus();
            
            }
            
        }

        private void MainRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
