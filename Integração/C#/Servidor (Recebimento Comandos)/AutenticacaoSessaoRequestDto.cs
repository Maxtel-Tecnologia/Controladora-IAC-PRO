using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAC_PRO_Servidor_Web
{
    public class AutenticacaoSessaoRequestDto
    {
        public AutenticacaoSessaoRequestDto()
        {
        }

        public AutenticacaoSessaoRequestDto(AutenticacaoSessaoRequestDto dto)
        {
            this.Action = dto.Action;
            this.Token = dto.Token;
            this.Enable = dto.Enable;
            this.Period = dto.Period;
            this.User = dto.User;
            this.Password = dto.Password;
            this.Scheme = dto.Scheme;
        }

        public string Action { get; set; }
        public string Token { get; set; }
        public int? Enable { get; set; }
        public int? Period { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Scheme { get; set; }
    }
}
