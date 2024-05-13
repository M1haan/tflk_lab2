using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tflk_lab1
{
    public class FileWork
    {
        OpenFileDialog openFileDialog = new OpenFileDialog(); SaveFileDialog saveFileDialog = new SaveFileDialog();
        static bool fileOpened = false;
        static bool fileCreated = false;
        static string openedFileName; static string createdFileName;
        public void CreateFile()
        {
            saveFileDialog.Filter = "All Files|*.doc;*.xls;*.ppt;*.doc;.xls;*.ppt;*.txt;";
            saveFileDialog.FileName = "Новый документ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; File.WriteAllText(filePath, "");
                fileCreated = true; createdFileName = saveFileDialog.FileName;
            }
        }
        public string OpenFile()
        {
            openFileDialog.Filter = "All Files|*.doc;*.xls;*.ppt;*.doc;.xls;*.ppt;*.txt;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string text = reader.ReadToEnd();
                    fileOpened = true; openedFileName = openFileDialog.FileName;
                    return text;
                }
            }
            else
                throw new Exception("Невозможно открыть файл!");
        }
        public void SaveFile(string str)
        {
            saveFileDialog.Filter = "All Files|*.doc;*.xls;*.ppt;*.doc;.xls;*.ppt;*.txt;";
            if (fileOpened)
            {
                string filePath = openedFileName;
                File.WriteAllText(filePath, str);
            }
            if (fileCreated)
            {
                string filePath = createdFileName;
                File.WriteAllText(filePath, str);
            }
            if (!fileCreated & !fileOpened)
            {
                SaveAs(str);
            }
        }
        public void SaveAs(string str)
        {
            saveFileDialog.Filter = "All Files|*.doc;*.xls;*.ppt;*.doc;.xls;*.ppt;*.txt;";
            saveFileDialog.FileName = "Новый документ";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName; File.WriteAllText(filePath, str);
            }
        }
    }
}


