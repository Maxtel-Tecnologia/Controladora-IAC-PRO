using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO_Servidor_Web
{
    public class ConfigurationDto
    {
        public int PortaServidorWeb { get; set; }
        public List<string> Rotas { get; set; }
        public string HostServidor { get; set; }
        public string Url { get; set; }
        public string IpIacPro { get; set; }
        public int HeartBeatPeriodo { get; set; }
    }
}
