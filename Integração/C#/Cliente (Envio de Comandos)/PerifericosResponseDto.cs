﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO
{
    public class PerifericosResponseDto
    {
        public string Action { get; set; }

        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        public int? Enable { get; set; }
        public int? Output { get; set; }
        public int? Idle { get; set; }
    }
}
