using SHDocVw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActiveWindowPath
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static void Main(string[] args)
        {
            string path = null;


            Thread.Sleep(2000);
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



                        Thread.Sleep(100);

                        Console.WriteLine("buff" + Buff.ToString());
                        Console.WriteLine("path" + path);
                        String et = path.ToString();
                        String to = Buff.ToString();
                        if (et.Contains(to))
                        {
                            Console.WriteLine("du er i mappen lige nu!" + path);



                        }







                    }




                }

            }
        }
    }
}


    


