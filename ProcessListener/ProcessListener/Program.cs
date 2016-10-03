using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;

namespace ConsoleApplication3
{
    class Program
    {

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        static void Main(string[] args)
        {

            while (true)
            {
                const int nChars = 256;
                StringBuilder Buff = new StringBuilder(nChars);
                IntPtr handle = GetForegroundWindow();

                if (GetWindowText(handle, Buff, nChars) > 0)
                {
                   


                    Console.WriteLine(Buff.ToString()); //currently it just does this, not the stuff underneath this, it is just kept for further testing.
                    Thread.Sleep(1000);
                    String comp = Buff.ToString();
                    String comparer = "Excel"; //unused for now, used for listening for a current excel window e.g.
                    if (comp.Contains(comparer))
                    {
                        Console.WriteLine(Buff.ToString());
                        Thread.Sleep(1000);
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.RIGHT);
                        Thread.Sleep(1000);
                        break;
                    }


                }


            }
        }
    }
}



