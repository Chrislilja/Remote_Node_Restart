using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestartNodesCSharp
{
    class CheckLogic
    {
        public void check()
        {
            SQLConnect sqlconnect = new SQLConnect();
            RunSQLCmd rcmd = new RunSQLCmd();
            CommandLine cmd = new CommandLine();

            MySqlConnection conn;

            string response;
            //Create all nodes listing
            string[] nodes = new string[12];

            nodes[0] = "wf1";
            nodes[1] = "wf2";
            nodes[2] = "wf3";
            nodes[3] = "wf4";
            nodes[4] = "wf5";
            nodes[5] = "wf6";
            nodes[6] = "wf7";
            nodes[7] = "wf8";
            nodes[8] = "wf9";
            nodes[9] = "wf10";
            nodes[10] = "wf11";
            nodes[11] = "wf12";
            conn = sqlconnect.connect();

            foreach (string node in nodes)
            {

                //get last update and create a minute comparasen
                rcmd.comrun("SELECT LastUpdate FROM mon_nodes WHERE NodeID='" + node + "';", conn, out response);

                DateTime lastupdate = Convert.ToDateTime(response);

                Int32 diff = (DateTime.UtcNow - lastupdate).Minutes;
              

                //if minutes over 4 then flag particular node for restart
                if (diff > 4)
                {
                    string notneeded; 
                    Console.WriteLine(node);
                    Console.WriteLine("Diffrence is : " + diff);
                    Console.WriteLine("FLAG FOR RESTART");
                    rcmd.comrun("UPDATE mon_nodes SET Restart ='1' WHERE NodeID ='" + node + "';", conn, out notneeded);
                }

                //If node is set to restart, Restart it
                Int32 restart;
                string restarthold;
                rcmd.comrun("SELECT Restart FROM mon_nodes WHERE NodeID='" + node + "';", conn, out restarthold);

                restart = Convert.ToInt32(restarthold);
                if (restart == 1)
                {
                    string notneeded;
                    cmd.cmd(node);
                    rcmd.comrun("UPDATE mon_nodes SET Restart ='0' WHERE NodeID ='" + node + "';", conn, out notneeded);
                }
                
                

            }
            
          
        }
    }
}
