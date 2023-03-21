using ConsoleApp1;
using Laba1Sharp;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Laba2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> code = new List<string>();


        public MainWindow()
        {
            InitializeComponent();
        }
        private void boxCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string strCode = new TextRange(boxCode.Document.ContentStart, boxCode.Document.ContentEnd).Text;
            byte[] byteArray = Encoding.ASCII.GetBytes(strCode);
            code = new List<string>();
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                        code.Add(reader.ReadLine());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var reader = new StreamReader(openFileDialog.FileName);
                code = new List<string>();
                try
                {
                    while (!reader.EndOfStream)
                        code.Add(reader.ReadLine());
                }
                finally
                {
                    reader.Close();
                }

                string codeStr = "";
                foreach (string str in code)
                    codeStr += str + '\n';

                boxCode.Document.Blocks.Add(new Paragraph(new Run(codeStr)));
            }
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            Halsted.FillDictionaries(code);
            lblAbsDif.Content = Halsted.GetCL();
            lblRelateDif.Content = Math.Round(Halsted.Getcl(), 3);

            string strCode = "";
            foreach (string str in code)
                strCode += str + "\n";
            lblMaxLvl.Content = Jilb.MaxNestLvl(strCode);
        }
    }
}
