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

        /*//private Process myProcess;
        private PdfReader PDFReader;
        private FileStream Stream;
        private PdfStamper PDFStamper;
        private PdfContentByte PDFData;
        */
        private PdfPTable table;
        public MainWindow()
        {

           


            InitializeComponent();
            


           /* //opsætning af forskellige streams tjek
            PDFReader = new PdfReader("C:\\file.pdf");
            Stream = new FileStream("C:\\new.pdf", FileMode.Create, FileAccess.Write);
            PDFStamper = new PdfStamper(PDFReader, Stream);
            PDFData = PDFStamper.GetOverContent(1);
          */




            //opsætning af table
            table = new PdfPTable(3);
            table.TotalWidth = 200f;

            

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

            //opsætning af pdfs størrelse metode til at få x og y er i pdfstempler nu
            x.Maximum = p.getBredde(1);
            x.Minimum = 0;
            y.Maximum = p.getHoejde(1);
            y.Minimum = 0;
            x.Value = (p.getBredde(1) / 2) - table.TotalWidth / 2;
            y.Value = p.getHoejde(1) / 2;

            /*//der skrives til pdfen
            table.WriteSelectedRows(0, 3, (PDFReader.GetPageSize(1).GetRight(0)/2) - table.TotalWidth/2, PDFReader.GetPageSize(1).GetTop(0)/2, PDFData);

            //Streams lukkes
            PDFStamper.Close();
            PDFReader.Close();
            Stream.Close();

            //process startes op
            myProcess = new Process();
            myProcess.StartInfo.FileName = @"c:\new.pdf";
            myProcess.Start();*/

            p.FoersteStempel();
           

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            /*//process lukkes
            this.myProcess.Kill();
            Thread.Sleep(100);


            //Streams opsættes igen
            PDFReader = new PdfReader("C:\\file.pdf");
            Stream = new FileStream("C:\\new.pdf", FileMode.Create, FileAccess.Write);
            PDFStamper = new PdfStamper(PDFReader, Stream);
            PDFData = PDFStamper.GetOverContent(1);





            //tabel opsættes
            table = new PdfPTable(3);
            table.TotalWidth = 200f;

         

            //Data indsættes i tabel igen.
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

            


           //der skrives en tabel ud på den nye value hvilket er valgt af brugeren
           table.WriteSelectedRows(0, 3, (float)x.Value, (float)y.Value, PDFData);

           //Streams lukkes igen
           PDFStamper.Close();
           PDFReader.Close();
           Stream.Close();


            //vindue med pdf åbnes igen, for at vise den nye position af tabellen, der kan klikkes på "lav pdf" knappen igen for at genstarte denne metode med en ny position.
           myProcess.StartInfo.FileName = @"c:\new.pdf";
           myProcess.Start();
           */


        }
    }
}
