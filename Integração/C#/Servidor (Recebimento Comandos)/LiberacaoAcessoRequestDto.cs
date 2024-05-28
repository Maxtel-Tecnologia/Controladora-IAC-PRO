using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO_Servidor_Web
{
    public class LiberacaoAcessoRequestDto
    {
        public LiberacaoAcessoRequestDto()
        {
        }

        public LiberacaoAcessoRequestDto(LiberacaoAcessoRequestDto dto)
        {
            this.Action = dto.Action;
            this.Token = dto.Token;
            this.Door = dto.Door;
            this.OpenTime = dto.OpenTime;
            this.RelayTime = dto.RelayTime;
            this.Ref = dto.Ref;
        }

        public string Action { get; set; }
        public string Token { get; set; }
        public int? Door { get; set; }

        [JsonProperty("open_time")]
        public int? OpenTime { get; set; }

        [JsonProperty("relay_time")]
        public int? RelayTime { get; set; }
        public int? Ref { get; set; }
        public int? Turnstile { get; set; }

        [JsonProperty("allow_entry")]
        public int? AllowEntry { get; set; }

        [JsonProperty("allow_exit")]
        public int? AllowExit { get; set; }

        [JsonProperty("access_time_out")]
        public int? AccessTimeOut { get; set; }
    }
}
