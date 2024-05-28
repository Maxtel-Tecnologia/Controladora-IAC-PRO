using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO_Servidor_Web
{
    public class EntradasSaidasRequestDto
    {
        public EntradasSaidasRequestDto()
        {
        }

        public EntradasSaidasRequestDto(EntradasSaidasRequestDto dto)
        {
            this.Action = dto.Action;
            this.Token = dto.Token;
            this.Output = dto.Output;
            this.Function = dto.Function;
            this.PeriodOn = dto.PeriodOn;
            this.PeriodOff = dto.PeriodOff;
            this.Rep = dto.Rep;
        }

        public string Action { get; set; }
        public string Token { get; set; }
        public int? Output { get; set; }
        public int? Function { get; set; }

        [JsonProperty("period_on")]
        public int? PeriodOn { get; set; }

        [JsonProperty("period_off")]
        public int? PeriodOff { get; set; }
        public int? Rep { get; set; }
    }
}
