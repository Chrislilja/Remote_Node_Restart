using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestartNodesCSharp
{
    class CommandLine
    {
        public void cmd(string id) {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //-startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "C:\\Program Files (x86)\\PuTTy\\putty.exe";
            startInfo.Arguments = "-load " + id + " -l root -m C:\\Users\\wz-mgmt\\Documents\\ChrisFOLDER\\PuttyCommand.txt";
            process.StartInfo = startInfo;
            process.Start();


            
            process.WaitForExit();

            Console.WriteLine("Restarted Node : " + id + " At " + DateTime.UtcNow);
        }
      
    }
}
