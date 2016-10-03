using iTextSharp.text.pdf;
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
using System.Diagnostics;

using System.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Process myProcess;
        private PdfPTable table;
        public MainWindow()
        {




            InitializeComponent();

            //opsætning af table
            table = new PdfPTable(3);
            table.TotalWidth = 200f;

            //test of commit on git, does this work? :-)

            //data tilføjes til tabel
            table.AddCell("Row 1, Col 1");
            table.AddCell("Row 1, Col 2");
            table.AddCell("Row 1, Col 3");
            table.AddCell("Row 2, Col 1");
            table.AddCell("Row 2, Col 2");
            table.AddCell("Row 2, Col 3");
            table.AddCell("Row 2, Col 1");
            table.AddCell("Row 2, Col 2");
            table.AddCell("Row 2, Col 3");
            table.AddCell("Row 3, Col 1");
            table.AddCell("Row 3, Col 2");
            table.AddCell("Row 3, Col 3");


            PDFStempler p = new PDFStempler("C:\\file.pdf", table);

            

            myProcess = p.FoersteStempel();
            myProcess.Start();

            x.Maximum = p.getBredde(1);
            x.Minimum = 0;
            y.Maximum = p.getHoejde(1);
            y.Minimum = 0;
            x.Value = (p.getBredde(1) / 2) - table.TotalWidth / 2;
            y.Value = p.getHoejde(1) / 2;


        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
           this.myProcess.Kill();
           Thread.Sleep(100);
           PDFStempler p = new PDFStempler("C:\\file.pdf", table);

           myProcess =  p.NytStempel((float)x.Value, (float)y.Value);
           myProcess.Start();
        }
    }
}
