using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO_Servidor_Web
{
    public class FuncoesAuxiliaresResponseDto
    {
        public string Action { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        public int? Days { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public int? Seconds { get; set; }
        public string Hardware { get; set; }

        [JsonProperty("serial_number")]
        public string SerialNumber { get; set; }
        public string Firmware { get; set; }
        public string BootLoader { get; set; }
        public string Hint { get; set; }
    }
}
