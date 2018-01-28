using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestartNodesCSharp
{
    class RunSQLCmd
    {

        public void comrun(string command, MySqlConnection connection, out string response)
        {
            //Create and forward SQL command to DB

            MySqlCommand comm = new MySqlCommand(command, connection);

            comm.CommandText = command;
            comm.Connection = connection;

            response = Convert.ToString(comm.ExecuteScalar());


        }
    }
}
