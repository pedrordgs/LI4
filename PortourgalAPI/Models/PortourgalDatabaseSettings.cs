using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortourgalAPI.Models
{
    public class PortourgalDatabaseSettings : IPortourgalDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string DistritosCollectionName { get; set; }
        public string RoteirosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPortourgalDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string DistritosCollectionName { get; set; }
        string RoteirosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
