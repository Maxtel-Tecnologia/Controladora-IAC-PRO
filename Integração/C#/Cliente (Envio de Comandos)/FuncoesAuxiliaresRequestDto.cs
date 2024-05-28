using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO
{
    public class FuncoesAuxiliaresRequestDto
    {
        public FuncoesAuxiliaresRequestDto()
        {
        }

        public FuncoesAuxiliaresRequestDto(FuncoesAuxiliaresRequestDto dto)
        {
            this.Action = dto.Action;
            this.Token = dto.Token;
            this.Hint = dto.Hint;
        }

        public string Action { get; set; }
        public string Token { get; set; }
        public string Hint { get; set; }
    }
}
