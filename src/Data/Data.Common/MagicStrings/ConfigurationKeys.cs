using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Common.MagicStrings
{
    public class ConfigurationKeys
    {
        public static string JWT_TokenSecret = "JWT:TokenSecret";
        public static string JWT_ValidIssuer = "JWT:ValidIssuer";
        public static string JWT_ValidAudience = "JWT:ValidAudience";
        public static string JWT_Expiration = "JWT:Expiration";
        public static string BackupDir = "BackupDir";
        public static string DatabaseName = "DatabaseName";
        public static string QuartzJob = "Quartz:quartz.scheduler.instanceName";
        public static string QuartzTimeBackupExecute = "Quartz:timeBackupExecute";
    }
}
