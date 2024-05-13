using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tflk_lab1
{
    public partial class Form1 : Form
    {

        OpenFileDialog openFileDialog = new OpenFileDialog(); SaveFileDialog saveFileDialog = new SaveFileDialog();
        bool fileOpened = false;
        bool fileCreated = false;
        string openedFileName; string createdFileName;
        public Form1()
        {
            InitializeComponent();


        }

        private void fToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ааToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void вызовСправкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\ELENA\source\repos\tflk_lab1\tflk_lab1\CallHelp.html");

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(InputTextBox1.Text);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox1.Text = Clipboard.GetText();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(InputTextBox1.Text);
            InputTextBox1.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox1.SelectAll();
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputTextBox1.ClearUndo();
            //richTextBox1.Text = undo;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "All Files|*.doc;*.xls;*.ppt;*.doc;.xls;*.ppt;*.txt;";
            saveFileDialog.FileName = "Новый документ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; System.IO.File.WriteAllText(filePath, "");
                fileCreated = true; createdFileName = saveFileDialog.FileName;
            }
            else
                MessageBox.Show("Файл не был создан!");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.SaveFile(InputTextBox1.Text);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.SaveAs(InputTextBox1.Text);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Compiler_FormClosing(object sender, FormClosingEventArgs e)
        {         
        
                if (MessageBox.Show("Вы уверены, что хотите закрыть программу?\n" +
                "Текущие изменения не сохранятся!", "Подтвердите закрытие", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {         
                InputTextBox1.ClearUndo();
                //richTextBox1.Text = undo;            
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(InputTextBox1.Text);
            InputTextBox1.Clear();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(InputTextBox1.Text);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            InputTextBox1.Text = Clipboard.GetText();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.SaveFile(InputTextBox1.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.CreateFile();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FileWork fw = new FileWork();
            fw.OpenFile();
        }

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //}
        private void DisplayTokensInDataGridView(List<Token> elements)
        {
            dataGridView1.Rows.Clear();

            foreach (var element in elements)
            {
                var typeDescription = Helper.elementTitles[element.Type];
                string location = $"с {element.StartPos} по {element.StartPos + element.Value.Length - 1} символ";
                dataGridView1.Rows.Add(element.Type, typeDescription, element.Value, location);
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string inputText = InputTextBox1.Text;
            var elements = inputText.Tokenize();
            dataGridView1.DataSource = null;
            DisplayTokensInDataGridView(elements);

            InputTextBox1.Visible = true;
        }
    }
}