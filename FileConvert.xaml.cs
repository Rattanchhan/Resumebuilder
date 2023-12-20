using Microsoft.Win32;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ResumeBuilder
{
    /// <summary>
    /// Interaction logic for FileConvert.xaml
    /// </summary>
    public partial class FileConvert : Window
    {
        public FileConvert()
        {
            InitializeComponent();
        }
        public string ReadFile()
        {
            string templateType;
            try
            {
                templateType = File.ReadAllText("typeOfTemplate.txt");
                return templateType;
            }
            catch
            {
                return null;
            }
        }
        private void ConvertTODocx()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "pdf files (*.pdf) |*.pdf;";
            try
            {
                dlg.ShowDialog();
                if (dlg.FileName != null)
                {
                    PdfDocument doc = new PdfDocument();
                    doc.LoadFromFile(dlg.FileName);
                    doc.ConvertOptions.SetPdfToDocOptions(true, true);
                    doc.SaveToFile(@"D:_ResumePDF.doc", FileFormat.DOC);
                    doc.SaveToFile(@"D:_ResumePDF.docx", FileFormat.DOCX);
                    doc.Close();
                    MessageBox.Show("Your resume saved (Loacation: D:\\_ResumePDF.doc");
                }
            }
            catch { }

        }
        public void TemplateFill()
        {
            if (ReadFile() == "template1")
            {
                Template1 template1 = new Template1();
                template1.Show();
            }
            else if (ReadFile() == "template2")
            {
                Template2 template2 = new Template2();
                template2.Show();
            }
            else if (ReadFile() == "template3")
            {
                Template1 template1 = new Template1();
                template1.Show();
            }
            else if (ReadFile() == "template4")
            {
                Template2 template2 = new Template2();
                template2.Show();
            }
            else if (ReadFile() == "template5")
            {
                Template1 template1 = new Template1();
                template1.Show();
            }
            else
            {
                Template2 template2 = new Template2();
                template2.Show();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TemplateFill();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConvertTODocx();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("window.txt", "FileConvert");
        }

        private void backButton_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
            WindowStep3 windowStep3 = new WindowStep3();
            windowStep3.Show();
        }

        private void backButton1_Click(object sender, RoutedEventArgs e)
        {
            Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
