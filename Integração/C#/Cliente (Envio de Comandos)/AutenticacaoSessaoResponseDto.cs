﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO
{
    public class AutenticacaoSessaoResponseDto
    {
        public string Action { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public int? Enable { get; set; }
        public int? Period { get; set; }
    }
}
