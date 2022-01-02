using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Utils.Infrastructure.Interfaces.Models
{
    public class BaseModel
    {
        // public virtual int Id { get; set; }
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }
        [JsonIgnore]
        public Guid Rowguid { get; set; }
    }
}
