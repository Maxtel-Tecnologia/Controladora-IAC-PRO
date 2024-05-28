using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO
{
    public class PerifericosRequestDto
    {
        public PerifericosRequestDto()
        {
        }

        public PerifericosRequestDto(PerifericosRequestDto dto)
        {
            this.Action = dto.Action;
            this.Token = dto.Token;
            this.PeriodOn = dto.PeriodOn;
            this.PeriodOff = dto.PeriodOff;
            this.Rep = dto.Rep;
            this.Enable = dto.Enable;
            this.Output = dto.Output;
            this.Idle = dto.Idle;
        }

        public string Action { get; set; }
        public string Token { get; set; }

        [JsonProperty("period_on")]
        public int? PeriodOn { get; set; }

        [JsonProperty("period_off")]
        public int? PeriodOff { get; set; }
        public int? Rep { get; set; }
        public int? Enable { get; set; }
        public int? Output { get; set; }
        public int? Idle { get; set; }
    }
}
