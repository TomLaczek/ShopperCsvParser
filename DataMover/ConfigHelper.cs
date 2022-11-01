using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMover
{
    internal class ConfigHelper
    {
        private readonly IConfiguration? _configuration;
        public string _connectionString { get; set; }
        public string _path { get; set; }

        public ConfigHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Aloes");
            _path = configuration.GetSection("FilePath").Value;
        }
    }
}
