using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class PDFStempler
    {
        private String OriginalFil;
        private PdfPTable Data;

        
        private PdfReader PDFReader;
        private FileStream Stream;
        private PdfStamper PDFStamper;
        private PdfContentByte PDFData;
        

        public PDFStempler(String OriginalFil, PdfPTable Data)
        {
            this.OriginalFil = OriginalFil;
            this.Data = Data;
        }

        public Process FoersteStempel()
        {
            PDFReader = new PdfReader(OriginalFil);
            Stream = new FileStream(OriginalFil+"new.pdf", FileMode.Create, FileAccess.Write);   //placeholder indtil der kommer filvælgning osv.
            PDFStamper = new PdfStamper(PDFReader, Stream);
            PDFData = PDFStamper.GetOverContent(1);

            Data.WriteSelectedRows(0, 3, (PDFReader.GetPageSize(1).GetRight(0) / 2) - Data.TotalWidth / 2, PDFReader.GetPageSize(1).GetTop(0) / 2, PDFData);

            //Streams lukkes
            PDFStamper.Close();
            PDFReader.Close();
            Stream.Close();

            //process startes op
            Process myProcess;
            myProcess = new Process();
            myProcess.StartInfo.FileName = OriginalFil + "new.pdf";
            return myProcess;
        }

        public float getBredde(int side)
        {
            return this.PDFReader.GetPageSize(1).GetRight(0);
        }

        public float getHoejde(int side)
        {
            return PDFReader.GetPageSize(1).GetTop(0);
        }

        public Process NytStempel(float x, float y)
        {
            

            PDFReader = new PdfReader(OriginalFil);
            Stream = new FileStream(OriginalFil + "new.pdf", FileMode.Create, FileAccess.Write);   //placeholder indtil der kommer filvælgning osv.
            PDFStamper = new PdfStamper(PDFReader, Stream);
            PDFData = PDFStamper.GetOverContent(1);

            Data.WriteSelectedRows(0, 3, x, y, PDFData);

            //Streams lukkes
            PDFStamper.Close();
            PDFReader.Close();
            Stream.Close();
            
            //process startes op
            Process myProcess;
            myProcess = new Process();
            myProcess.StartInfo.FileName = OriginalFil + "new.pdf";
            return myProcess;

        }
    }
}
