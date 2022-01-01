using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data;

namespace Utils.Common.SQLcommands
{
    public class SqlFunctions
    {
        public static void RestoreDb(String databaseName, String backUpFile)
        {
            var connectionString = "Server=.;Integrated security=SSPI;database=master";
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //String str;
                //str = $"CREATE DATABASE {databaseName}";

                //SqlCommand myCommand = new SqlCommand(str, conn);
                try
                {
                    //conn.Open();
                    //myCommand.ExecuteNonQuery();

                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                   
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }

            }

            ServerConnection connection = new ServerConnection(".", "sa", "Damqnov84!");
            Server sqlServer = new Server(connection);
            Restore rstDatabase = new Restore();
            rstDatabase.Action = RestoreActionType.Database;
            rstDatabase.Database = databaseName;
            BackupDeviceItem bkpDevice = new BackupDeviceItem(backUpFile, DeviceType.File);
            rstDatabase.Devices.Add(bkpDevice);
            rstDatabase.ReplaceDatabase = true;
            rstDatabase.SqlRestore(sqlServer);
        }

        public static void RestoreDatabase(string backupPath, string databaseName)
        {
            var connectionString = "Server=.;Integrated security=SSPI;database=master";
            string script = File.ReadAllText(backupPath);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                String str;
                str = $"CREATE DATABASE {databaseName}";

                SqlCommand myCommand = new SqlCommand(str, conn);
                try
                {
                    conn.Open();
                    myCommand.ExecuteNonQuery();
                   
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    FileInfo fileInfo = new FileInfo(backupPath);
                    string sc = fileInfo.OpenText().ReadToEnd();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sc, conn);
                        cmd.ExecuteNonQuery();
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
              
            }

         
        }

    }
}
