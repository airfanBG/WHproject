using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Common.MagicStrings;

namespace Data.Services.DataServices.Database
{
    public class ServerManagement
    {
      
        public void CreateBackup(string bckpDir, string connectionString, string databaseName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string backupQuery = $"BACKUP DATABASE {databaseName} TO DISK='{bckpDir}-{DateTime.Now.ToShortDateString()}'";
                using (SqlCommand command = new SqlCommand(backupQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        var res = command.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
