using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace RestartNodesCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckLogic chk = new CheckLogic();
            do
            {
                chk.check();
                System.Threading.Thread.Sleep(30000);
            } while (true);

            



            
        }
    }
}
