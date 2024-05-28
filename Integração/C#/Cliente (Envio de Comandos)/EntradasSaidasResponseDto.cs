using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO
{
    public class EntradasSaidasResponseDto
    {
        public string Action { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        public int? out1 { get; set; }
        public int? out2 { get; set; }
        public int? out3 { get; set; }
        public int? out4 { get; set; }
        public int? out5 { get; set; }
        public int? out6 { get; set; }
        public int? out7 { get; set; }
        public int? out8 { get; set; }
        public int? out9 { get; set; }
        public int? out10 { get; set; }
        public int? out11 { get; set; }
        public int? out12 { get; set; }
        public int? in1 { get; set; }
        public int? in2 { get; set; }
        public int? in3 { get; set; }
        public int? in4 { get; set; }
        public int? in5 { get; set; }
        public int? in6 { get; set; }
        public int? in7 { get; set; }
        public int? in8 { get; set; }
    }
}
