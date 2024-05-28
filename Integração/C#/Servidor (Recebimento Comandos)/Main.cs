using Microsoft.AspNetCore.Builder;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IAC_PRO_Servidor_Web
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tsslHost.Text = $"Host: {System.Environment.MachineName}";

            IPAddress[] ipLocal = Dns.GetHostAddresses(System.Environment.MachineName);

            string ip = ipLocal[1].ToString();

            tsslIp.Text = $"IP Local: {ip}";

            ObterConfiguracoes();
            SetControls();
        }

        public static class Configuracoes
        {
            public static int PortaServidorWeb;
            public static List<string> Rotas;
            public static string HostServidor;
            public static string Url;
            public static string IpIacPro;
            public static int HeartBeatPeriodo;
        }

        private void ObterConfiguracoes()
        {
            var directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var fullPath = @$"{directory}\Configurations.json";

            if (!File.Exists(fullPath))
            {
                var sw = new System.IO.StreamWriter(fullPath);

                var json = @"{
                  ""portaServidorWeb"": 3000,
                  ""rotas"": [
                    ""heartbeat"",
                    ""card_present"",
                    ""door_event"",
                    ""turnstile_event""
                  ],
                  ""hostServidor"": ""192.168.1.1"",
                  ""url"": ""/api"",
                  ""ipIacPro"": ""192.168.1.200"",
                  ""heartBeatPeriodo"": 10
                }";

                sw.Write(json);
                sw.Close();
                sw.Dispose();
            }

            var sr = new System.IO.StreamReader(fullPath);

            var obj = JsonConvert.DeserializeObject<ConfigurationDto>(sr.ReadToEnd());

            sr.Close();
            sr.Dispose();

            Configuracoes.PortaServidorWeb = obj.PortaServidorWeb;
            Configuracoes.Rotas = obj.Rotas;
            Configuracoes.HostServidor = obj.HostServidor;
            Configuracoes.Url = obj.Url;
            Configuracoes.IpIacPro = obj.IpIacPro;
            Configuracoes.HeartBeatPeriodo = obj.HeartBeatPeriodo;
        }

        private void SetControls()
        {
            txtHeartBeatPeriodo.Text = Configuracoes.HeartBeatPeriodo.ToString();
            txtHostServidor.Text = Configuracoes.HostServidor;
            txtIpIACPro.Text = Configuracoes.IpIacPro.ToString();
            txtPortaServidorWeb.Text = Configuracoes.PortaServidorWeb.ToString();
            txtUrl.Text = Configuracoes.Url;

            var rotas = string.Join(System.Environment.NewLine, Configuracoes.Rotas);

            txtRotas.Text = rotas;
        }

        private void AlteraConfiguracao()
        {
            var directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var fullPath = @$"{directory}\Configurations.json";

            var sw = new System.IO.StreamWriter(fullPath);

            var dto = new ConfigurationDto
            {
                PortaServidorWeb = Configuracoes.PortaServidorWeb,
                Rotas = Configuracoes.Rotas,
                HostServidor = Configuracoes.HostServidor,
                Url = Configuracoes.Url,
                IpIacPro = Configuracoes.IpIacPro,
                HeartBeatPeriodo = Configuracoes.HeartBeatPeriodo
            };

            sw.Write(JsonConvert.SerializeObject(dto, Formatting.Indented));
            sw.Close();
            sw.Dispose();
        }

        private async void btnIniciarServidorWeb_Click(object sender, EventArgs e)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(new string[0]);
                builder.Services.AddControllers();

                var app = builder.Build();

                foreach (var controller in txtRotas.Text.Split("\r\n").Distinct())
                {
                    app.MapPost($"{txtUrl.Text}/{controller}", async (HttpRequest request) =>
                    {
                        if (request?.Path.Value != "/")
                        {
                            string body = string.Empty;

                            request.EnableBuffering();

                            using (var reader = new StreamReader(
                                        request.Body,
                                        encoding: Encoding.UTF8,
                                        detectEncodingFromByteOrderMarks: false,
                                        bufferSize: 1024 * 100,
                                        leaveOpen: true))
                            {
                                body = await reader.ReadToEndAsync();

                                request.Body.Position = 0;

                                string jsonFormatted = JValue.Parse(body).ToString(Formatting.Indented);

                                AtualizaResponse("POST", $"{txtUrl.Text}/{controller}", RemoteIp(request), jsonFormatted);
                            }
                        }
                    });
                }

                AtualizaStatusServidorWeb("Servidor Web Iniciado");

                await app.RunAsync($"http://*:{txtPortaServidorWeb.Text}");
            }
            catch (Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(ex.Message, "", buttons, MessageBoxIcon.Error);
            }
        }

        private string RemoteIp(HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress.ToString().Replace("::ffff:", "");
        }

        private void AtualizaResponse(string tipo, string endPoint, string remoteIp, string response)
        {
            var result = $"Recebido em: {DateTime.Now.ToString()}\r\nTipo: {tipo}\r\nEndpoint: {endPoint}\r\nRemoteIP: {remoteIp}\r\nBody: {response}\r\n************************************";

            Invoke(new Action(() =>
            {
                txtResponse.AppendText($"{result}{System.Environment.NewLine}");
            }));
        }

        private void AtualizaStatusServidorWeb(string status)
        {
            Invoke(new Action(() =>
            {
                tsslStatusServidor.Text = status;
                tsslStatusServidor.BackColor = Color.Green;
                tsslStatusServidor.ForeColor = Color.Black;
            }));
        }

        private async void btnConfigurarPushAPI_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions($"http://{txtIpIACPro.Text}/api")
            {
            };

            using var client = new RestClient(options);

            var request = new RestRequest("", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            var body = new
            {
                action = "push_api_set",
                token = "",
                enable = 1,
                host = txtHostServidor.Text,
                port = Int32.Parse(txtPortaServidorWeb.Text),
                heartbeat_period = Int32.Parse(txtHeartBeatPeriodo.Text)
            };

            request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(@"Push API configurado", "", buttons, MessageBoxIcon.Information);
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show(response.Content, "Erro ao configurar o Push API", buttons, MessageBoxIcon.Error);
            }
        }

        private void txtPortaServidorWeb_Leave(object sender, EventArgs e)
        {
            if (Configuracoes.PortaServidorWeb.ToString() != txtPortaServidorWeb.Text)
            {
                Configuracoes.PortaServidorWeb = Int32.Parse(txtPortaServidorWeb.Text);

                AlteraConfiguracao();
            }
        }

        private void txtHostServidor_Leave(object sender, EventArgs e)
        {
            if (Configuracoes.HostServidor != txtHostServidor.Text)
            {
                Configuracoes.HostServidor = txtHostServidor.Text;

                AlteraConfiguracao();
            }
        }

        private void txtUrl_Leave(object sender, EventArgs e)
        {
            if (Configuracoes.Url.ToString() != txtUrl.Text)
            {
                Configuracoes.Url = txtUrl.Text;

                AlteraConfiguracao();
            }
        }

        private void txtIpIACPro_Leave(object sender, EventArgs e)
        {
            if (Configuracoes.IpIacPro != txtIpIACPro.Text)
            {
                Configuracoes.IpIacPro = txtIpIACPro.Text;

                AlteraConfiguracao();
            }
        }

        private void txtHeartBeatPeriodo_Leave(object sender, EventArgs e)
        {
            if (Configuracoes.HeartBeatPeriodo.ToString() != txtHeartBeatPeriodo.Text)
            {
                Configuracoes.HeartBeatPeriodo = Int32.Parse(txtHeartBeatPeriodo.Text);

                AlteraConfiguracao();
            }
        }

        private void txtRotas_Leave(object sender, EventArgs e)
        {
            var rotas = txtRotas.Text.Split("\r\n").ToList();
            
            if (Configuracoes.Rotas != rotas)
            {
                Configuracoes.Rotas = rotas;

                AlteraConfiguracao();
            }
        }
    }
}
