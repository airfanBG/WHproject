using Data.Services.DataServices.Database;
using Microsoft.Extensions.Configuration;
using Quartz;
using System.Threading.Tasks;
using Utils.Common.MagicStrings;

namespace ClientSide.API.Qscheduler
{
    [DisallowConcurrentExecution]
    public class Qjob : IJob
    {
        public Qjob(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ServerManagement Management { get; }=new ServerManagement();
        public IConfiguration Configuration { get; }

        public async Task Execute(IJobExecutionContext context)
        {
            Management.CreateBackup(Configuration[ConfigurationKeys.BackupDir], Configuration.GetConnectionString("DefaultConnection"), Configuration[ConfigurationKeys.DatabaseName]);
        }


    }
}
