using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();

            string filename;

            foreach (SHDocVw.InternetExplorer ie in shellWindows)
            {
                filename = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                
                 
                if (filename.Equals("explorer"))
                {
                    // Save the location off to your application
                    if (ie.LocationURL.ToString().Contains("Observationer"))
                    {
                        Console.WriteLine(ie.LocationURL);
                        //Console.WriteLine("Explorer location : {0}", ie.LocationURL);
                    }
                    // Setup a trigger for when the user navigates
                    //ie.NavigateComplete2 += new SHDocVw.DWebBrowserEvents2_NavigateComplete2EventHandler(handlerMethod);
                }
            }


        }
    }
}
