using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;

namespace ConsoleApplication2
{
    class Program
    {
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
     

        //de 3 linjer herover er fra  http://www.codeproject.com/Questions/279441/Bring-Process-to-the-front
        static void Main(string[] args)
        {


            Process myProcess;
                 Process myProcesss; 
            myProcess = new Process();
            myProcess.StartInfo.FileName = "C:\\file.pdf";
            myProcess.Start();



            Thread.Sleep(2000);
            SetForegroundWindow(myProcess.MainWindowHandle);
            
            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.RIGHT);

            myProcesss = new Process();
            myProcesss.StartInfo.FileName = "C:\\testx.xls";
            myProcesss.Start();

            //Thread.Sleep(2000);
            SetForegroundWindow(myProcess.MainWindowHandle);

            InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.LEFT);




        }
    }



}








