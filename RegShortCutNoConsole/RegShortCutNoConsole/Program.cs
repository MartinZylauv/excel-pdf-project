using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;


static class Program
{

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);




    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] arguments)//Windows passes an array of arguments which may be filesnames or folder names.
    {





        //Thread.Sleep(2000);

        string path = null;


        Thread.Sleep(100);
        {
            foreach (SHDocVw.InternetExplorer window in new SHDocVw.ShellWindows())
            {



                path = window.LocationURL;






                const int nChars = 256;
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();

                if (GetWindowText(handle, Buff, nChars) > 0)
                {



                    //Console.WriteLine(Buff.ToString()); //currently it just does this, not the stuff underneath this, it is just kept for further testing.

                    String comp = Buff.ToString();





                    //Console.WriteLine("buff" + Buff.ToString());
                    //Console.WriteLine("path" + path);
                    String et = path.ToString();
                    String to = Buff.ToString();
                    if (et.Contains(to))
                    {
                        // Console.WriteLine("du er i mappen lige nu!" + path);

                        string uriPath = path;

                        string localPath = new Uri(uriPath).LocalPath;

                        //string sourcePath = @"\\fs01\Observationer\Wordskabeloner\Obs Afvigelse.docx";
                        //string targetPath = path+"\\test.docx";
                        System.IO.File.Copy(@"\\fs01\Observationer\Wordskabeloner\Obs Afvigelse.docx", localPath + "\\test.docx", true); //file is being copied to new location.
                        Thread.Sleep(50);
                        Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
                        ap.Visible = true;
                        Document document = ap.Documents.Open(localPath + "\\test.docx"); //document is being opened.

                    }







                }




            }

        }






        // if (arguments.Length > 0)//If user rightclicked a folder. Arguments[0] is a folder.
        // {



        //File.WriteAllText(arguments[0] + "\\Here is my new Notepad File.txt", "This is my data!");  //The selected word document should be created here on the selected location, add this.



        string fileName = "Obs Afvigelse.docx"; //TODO:: Lav så filen hedder det som parameteret har haft imellem et punktum og et "/".
                                                // string[]argumentSplit = arguments[1].Split('\');


        string sourcePath = @"\\fs01\Observationer\Wordskabeloner\Obs Afvigelse.docx";
        string targetPath = @"\\fs01\Observationer\Wordskabeloner\test.docx";
        System.IO.File.Copy(sourcePath, targetPath, true); //file is being copied to new location.

        /*
         //TILFØJ EN FIL OG TJEK HER.
            //string sourcePath = arguments[1];
           string targetPath = @"\\fs01\Observationer\Wordskabeloner\";
           
            

            // Use Path class to manipulate file and directory paths.
           // string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
           string destFile = System.IO.Path.Combine(targetPath, fileName);

            System.IO.File.Copy(sourcePath, destFile, true); //file is being copied to new location.





          Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
           ap.Visible = true;
           Document document = ap.Documents.Open(destFile); //document is being opened.
           */



        //}
        //else//No folder was rightclicked on by the user.
        //{
        //add something informational to the user here.
        //   Console.WriteLine("ingen folder passed."); //this is just here for debugging purposes.
        //   Console.ReadLine(); //this is just here for debugging purposes.
        // }
    }
}
