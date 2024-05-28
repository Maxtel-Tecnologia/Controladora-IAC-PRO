using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IAC_PRO
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
        }

        protected void Limpar()
        {
            txtHint_tabFuncoesAuxiliares.Text = "Texto com até 64 caracteres, exemplo: CONTROLADORA PORTARIA 01";

            txtPeriodOn_tabPerifericos.Text = "100";
            txtPeriodOff_tabPerifericos.Text = "100";
            txtRep_tabPerifericos.Text = "3";
            txtEnable_tabPerifericos.Text = "1";
            txtOutput_tabPerifericos.Text = "8";
            txtIdle_tabPerifericos.Text = "0";

            txtDoor_tabLiberacaoAcesso.Text = "1";
            txtOpenTime_tabLiberacaoAcesso.Text = "0";
            txtRelayTime_tabLiberacaoAcesso.Text = "0";
            txtRefDoorAccess_tabLiberacaoAcesso.Text = "123456789";

            txtTurnstile_tabLiberacaoAcesso.Text = "1";
            txtAllowEntry_tabLiberacaoAcesso.Text = "1";
            txtAllowExit_tabLiberacaoAcesso.Text = "1";
            txtAccessTimeOut_tabLiberacaoAcesso.Text = "5";
            txtRefTurnstile_tabLiberacaoAcesso.Text = "123456789";

            txtOutput_tabEntradasSaidas.Text = "4";
            txtFunction_tabEntradasSaidas.Text = "2";
            txtPeriodOn_tabEntradasSaidas.Text = "100";
            txtPeriodOff_tabEntradasSaidas.Text = "100";
            txtRep_tabEntradasSaidas.Text = "20";

            txtEnable_tabAutenticacaoSessao.Text = "0";
            txtPeriod_tabAutenticacaoSessao.Text = "3600";
            txtScheme_tabAutenticacaoSessao.Text = "basic";
            txtUser_tabAutenticacaoSessao.Text = "new_user";
            txtPassword_tabAutenticacaoSessao.Text = "new_password";

            txtUserSet_tabAutenticacaoSessao.Text = "new_user";
            txtPasswordSet_tabAutenticacaoSessao.Text = "new_password";

            gbStatus.Text = string.Empty;
            txtStatus.Text = string.Empty;
            progressBar1.Value = 0;
        }

        private void cbActions_tabFuncoesAuxiliares_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (cbActions_tabFuncoesAuxiliares.SelectedItem == "hint_set")
            {
                lblHint_tabFuncoesAuxiliares.Visible = true;
                txtHint_tabFuncoesAuxiliares.Visible = true;
            }
            else
            {
                lblHint_tabFuncoesAuxiliares.Visible = false;
                txtHint_tabFuncoesAuxiliares.Visible = false;
            }
        }

        private async void btnEnviar_tabFuncoesAuxiliares_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                var body = new FuncoesAuxiliaresRequestDto()
                {
                    Action = (string?)cbActions_tabFuncoesAuxiliares.SelectedItem,
                    Token = tsslToken.Text
                };

                if (cbActions_tabFuncoesAuxiliares.SelectedItem == "hint_set")
                {
                    body = new FuncoesAuxiliaresRequestDto(body) { Hint = txtHint_tabFuncoesAuxiliares.Text };
                }

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                if (response.StatusCode == HttpStatusCode.OK)
                    gbStatus.ForeColor = Color.Green;
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<FuncoesAuxiliaresResponseDto>(response.Content);

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private void cbActions_tabPerifericos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (cbActions_tabPerifericos.SelectedItem == "buzzer")
            {
                lblPeriodOn_tabPerifericos.Visible = true;
                txtPeriodOn_tabPerifericos.Visible = true;
                lblPeriodOff_tabPerifericos.Visible = true;
                txtPeriodOff_tabPerifericos.Visible = true;
                lblRep_tabPerifericos.Visible = true;
                txtRep_tabPerifericos.Visible = true;

                lblEnable_tabPerifericos.Visible = false;
                txtEnable_tabPerifericos.Visible = false;

                lblEnable_tabPerifericos.Visible = false;
                txtEnable_tabPerifericos.Visible = false;
                lblOutput_tabPerifericos.Visible = false;
                txtOutput_tabPerifericos.Visible = false;
                lblIdle_tabPerifericos.Visible = false;
                txtIdle_tabPerifericos.Visible = false;
            }
            else if (cbActions_tabPerifericos.SelectedItem == "buzzer_set")
            {
                lblEnable_tabPerifericos.Visible = true;
                txtEnable_tabPerifericos.Visible = true;

                lblPeriodOn_tabPerifericos.Visible = false;
                txtPeriodOn_tabPerifericos.Visible = false;
                lblPeriodOff_tabPerifericos.Visible = false;
                txtPeriodOff_tabPerifericos.Visible = false;
                lblRep_tabPerifericos.Visible = false;
                txtRep_tabPerifericos.Visible = false;

                lblOutput_tabPerifericos.Visible = false;
                txtOutput_tabPerifericos.Visible = false;
                lblIdle_tabPerifericos.Visible = false;
                txtIdle_tabPerifericos.Visible = false;
            }
            else if (cbActions_tabPerifericos.SelectedItem == "siren_set")
            {
                lblEnable_tabPerifericos.Visible = true;
                txtEnable_tabPerifericos.Visible = true;
                lblOutput_tabPerifericos.Visible = true;
                txtOutput_tabPerifericos.Visible = true;
                lblIdle_tabPerifericos.Visible = true;
                txtIdle_tabPerifericos.Visible = true;


                lblPeriodOn_tabPerifericos.Visible = false;
                txtPeriodOn_tabPerifericos.Visible = false;
                lblPeriodOff_tabPerifericos.Visible = false;
                txtPeriodOff_tabPerifericos.Visible = false;
                lblRep_tabPerifericos.Visible = false;
                txtRep_tabPerifericos.Visible = false;
            }
            else
            {
                lblPeriodOn_tabPerifericos.Visible = false;
                txtPeriodOn_tabPerifericos.Visible = false;
                lblPeriodOff_tabPerifericos.Visible = false;
                txtPeriodOff_tabPerifericos.Visible = false;
                lblRep_tabPerifericos.Visible = false;
                txtRep_tabPerifericos.Visible = false;

                lblEnable_tabPerifericos.Visible = false;
                txtEnable_tabPerifericos.Visible = false;

                lblEnable_tabPerifericos.Visible = false;
                txtEnable_tabPerifericos.Visible = false;
                lblOutput_tabPerifericos.Visible = false;
                txtOutput_tabPerifericos.Visible = false;
                lblIdle_tabPerifericos.Visible = false;
                txtIdle_tabPerifericos.Visible = false;
            }
        }

        private async void btnEnviar_tabPerifericos_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                var body = new PerifericosRequestDto()
                {
                    Action = (string?)cbActions_tabPerifericos.SelectedItem,
                    Token = tsslToken.Text
                };

                if (cbActions_tabPerifericos.SelectedItem == "buzzer")
                {
                    body = new PerifericosRequestDto(body)
                    {
                        PeriodOn = Convert.ToInt32(txtPeriodOn_tabPerifericos.Text),
                        PeriodOff = Convert.ToInt32(txtPeriodOff_tabPerifericos.Text),
                        Rep = Convert.ToInt32(txtRep_tabPerifericos.Text)
                    };
                }

                if (cbActions_tabPerifericos.SelectedItem == "buzzer_set")
                {
                    body = new PerifericosRequestDto(body)
                    {
                        Enable = Convert.ToInt32(txtEnable_tabPerifericos.Text)
                    };
                }

                if (cbActions_tabPerifericos.SelectedItem == "siren_set")
                {
                    body = new PerifericosRequestDto(body)
                    {
                        Enable = Convert.ToInt32(txtEnable_tabPerifericos.Text),
                        Output = Convert.ToInt32(txtOutput_tabPerifericos.Text),
                        Idle = Convert.ToInt32(txtIdle_tabPerifericos.Text),
                    };
                }

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                if (response.StatusCode == HttpStatusCode.OK)
                    gbStatus.ForeColor = Color.Green;
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<PerifericosResponseDto>(response.Content);

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private void cbActions_tabLiberacaoAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (cbActions_tabLiberacaoAcesso.SelectedItem == "door_access")
            {
                lblDoor_tabLiberacaoAcesso.Visible = true;
                txtDoor_tabLiberacaoAcesso.Visible = true;
                lblOpenTime_tabLiberacaoAcesso.Visible = true;
                txtOpenTime_tabLiberacaoAcesso.Visible = true;
                lblRelayTime_tabLiberacaoAcesso.Visible = true;
                txtRelayTime_tabLiberacaoAcesso.Visible = true;
                lblRefDoorAccess_tabLiberacaoAcesso.Visible = true;
                txtRefDoorAccess_tabLiberacaoAcesso.Visible = true;

                lblTurnstile_tabLiberacaoAcesso.Visible = false;
                txtTurnstile_tabLiberacaoAcesso.Visible = false;
                lblAllowEntry_tabLiberacaoAcesso.Visible = false;
                txtAllowEntry_tabLiberacaoAcesso.Visible = false;
                lblAllowExit_tabLiberacaoAcesso.Visible = false;
                txtAllowExit_tabLiberacaoAcesso.Visible = false;
                lblAccessTimeOut_tabLiberacaoAcesso.Visible = false;
                txtAccessTimeOut_tabLiberacaoAcesso.Visible = false;
                lblRefTurnstile_tabLiberacaoAcesso.Visible = false;
                txtRefTurnstile_tabLiberacaoAcesso.Visible = false;
            }
            else if (cbActions_tabLiberacaoAcesso.SelectedItem == "turnstile_access")
            {
                lblTurnstile_tabLiberacaoAcesso.Visible = true;
                txtTurnstile_tabLiberacaoAcesso.Visible = true;
                lblAllowEntry_tabLiberacaoAcesso.Visible = true;
                txtAllowEntry_tabLiberacaoAcesso.Visible = true;
                lblAllowExit_tabLiberacaoAcesso.Visible = true;
                txtAllowExit_tabLiberacaoAcesso.Visible = true;
                lblAccessTimeOut_tabLiberacaoAcesso.Visible = true;
                txtAccessTimeOut_tabLiberacaoAcesso.Visible = true;
                lblRefTurnstile_tabLiberacaoAcesso.Visible = true;
                txtRefTurnstile_tabLiberacaoAcesso.Visible = true;

                lblDoor_tabLiberacaoAcesso.Visible = false;
                txtDoor_tabLiberacaoAcesso.Visible = false;
                lblOpenTime_tabLiberacaoAcesso.Visible = false;
                txtOpenTime_tabLiberacaoAcesso.Visible = false;
                lblRelayTime_tabLiberacaoAcesso.Visible = false;
                txtRelayTime_tabLiberacaoAcesso.Visible = false;
                lblRefDoorAccess_tabLiberacaoAcesso.Visible = false;
                txtRefDoorAccess_tabLiberacaoAcesso.Visible = false;
            }
            else
            {
                lblDoor_tabLiberacaoAcesso.Visible = false;
                txtDoor_tabLiberacaoAcesso.Visible = false;
                lblOpenTime_tabLiberacaoAcesso.Visible = false;
                txtOpenTime_tabLiberacaoAcesso.Visible = false;
                lblRelayTime_tabLiberacaoAcesso.Visible = false;
                txtRelayTime_tabLiberacaoAcesso.Visible = false;
                lblRefDoorAccess_tabLiberacaoAcesso.Visible = false;
                txtRefDoorAccess_tabLiberacaoAcesso.Visible = false;

                lblTurnstile_tabLiberacaoAcesso.Visible = false;
                txtTurnstile_tabLiberacaoAcesso.Visible = false;
                lblAllowEntry_tabLiberacaoAcesso.Visible = false;
                txtAllowEntry_tabLiberacaoAcesso.Visible = false;
                lblAllowExit_tabLiberacaoAcesso.Visible = false;
                txtAllowExit_tabLiberacaoAcesso.Visible = false;
                lblAccessTimeOut_tabLiberacaoAcesso.Visible = false;
                txtAccessTimeOut_tabLiberacaoAcesso.Visible = false;
                lblRefTurnstile_tabLiberacaoAcesso.Visible = false;
                txtRefTurnstile_tabLiberacaoAcesso.Visible = false;
            }
        }

        private async void btnEnviar_tabLiberacaoAcesso_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                var body = new LiberacaoAcessoRequestDto()
                {
                    Action = (string?)cbActions_tabLiberacaoAcesso.SelectedItem,
                    Token = tsslToken.Text
                };

                if (cbActions_tabLiberacaoAcesso.SelectedItem == "door_access")
                {
                    body = new LiberacaoAcessoRequestDto(body)
                    {
                        Door = Convert.ToInt32(txtDoor_tabLiberacaoAcesso.Text),
                        OpenTime = Convert.ToInt32(txtOpenTime_tabLiberacaoAcesso.Text),
                        RelayTime = Convert.ToInt32(txtRelayTime_tabLiberacaoAcesso.Text),
                        Ref = Convert.ToInt32(txtRefDoorAccess_tabLiberacaoAcesso.Text)
                    };
                }

                if (cbActions_tabLiberacaoAcesso.SelectedItem == "turnstile_access")
                {
                    body = new LiberacaoAcessoRequestDto(body)
                    {
                        Turnstile = Convert.ToInt32(txtTurnstile_tabLiberacaoAcesso.Text),
                        AllowEntry = Convert.ToInt32(txtAllowEntry_tabLiberacaoAcesso.Text),
                        AllowExit = Convert.ToInt32(txtAllowExit_tabLiberacaoAcesso.Text),
                        AccessTimeOut = Convert.ToInt32(txtAccessTimeOut_tabLiberacaoAcesso.Text),
                        Ref = Convert.ToInt32(txtRefTurnstile_tabLiberacaoAcesso.Text)
                    };
                }

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                if (response.StatusCode == HttpStatusCode.OK)
                    gbStatus.ForeColor = Color.Green;
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<LiberacaoAcessoResponseDto>(response.Content);

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private async void btnEnviar_tabEntradasSaidas_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                var body = new EntradasSaidasRequestDto()
                {
                    Action = (string?)cbActions_tabEntradasSaidas.SelectedItem,
                    Token = tsslToken.Text
                };

                if (cbActions_tabEntradasSaidas.SelectedItem == "output_set")
                {
                    body = new EntradasSaidasRequestDto(body)
                    {
                        Output = Convert.ToInt32(txtOutput_tabEntradasSaidas.Text),
                        Function = Convert.ToInt32(txtFunction_tabEntradasSaidas.Text),
                        PeriodOn = Convert.ToInt32(txtPeriodOn_tabEntradasSaidas.Text),
                        PeriodOff = Convert.ToInt32(txtPeriodOff_tabEntradasSaidas.Text),
                        Rep = Convert.ToInt32(txtRep_tabEntradasSaidas.Text)
                    };
                }

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                if (response.StatusCode == HttpStatusCode.OK)
                    gbStatus.ForeColor = Color.Green;
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<EntradasSaidasResponseDto>(response.Content);

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private void cbActions_tabEntradasSaidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (cbActions_tabEntradasSaidas.SelectedItem == "output_set")
            {
                lblOutput_tabEntradasSaidas.Visible = true;
                txtOutput_tabEntradasSaidas.Visible = true;
                lblFunction_tabEntradasSaidas.Visible = true;
                txtFunction_tabEntradasSaidas.Visible = true;
                lblPeriodOn_tabEntradasSaidas.Visible = true;
                txtPeriodOn_tabEntradasSaidas.Visible = true;
                lblPeriodOff_tabEntradasSaidas.Visible = true;
                txtPeriodOff_tabEntradasSaidas.Visible = true;
                lblRep_tabEntradasSaidas.Visible = true;
                txtRep_tabEntradasSaidas.Visible = true;
            }
            else
            {
                lblOutput_tabEntradasSaidas.Visible = false;
                txtOutput_tabEntradasSaidas.Visible = false;
                lblFunction_tabEntradasSaidas.Visible = false;
                txtFunction_tabEntradasSaidas.Visible = false;
                lblPeriodOn_tabEntradasSaidas.Visible = false;
                txtPeriodOn_tabEntradasSaidas.Visible = false;
                lblPeriodOff_tabEntradasSaidas.Visible = false;
                txtPeriodOff_tabEntradasSaidas.Visible = false;
                lblRep_tabEntradasSaidas.Visible = false;
                txtRep_tabEntradasSaidas.Visible = false;
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();
        }

        private async void btnEnviar_tabAutenticacaoSessao_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                var body = new AutenticacaoSessaoRequestDto()
                {
                    Action = (string?)cbActions_tabAutenticacaoSessao.SelectedItem,
                    Token = tsslToken.Text
                };

                if (cbActions_tabAutenticacaoSessao.SelectedItem == "session_set")
                {
                    body = new AutenticacaoSessaoRequestDto(body)
                    {
                        Enable = Convert.ToInt32(txtEnable_tabAutenticacaoSessao.Text),
                        Period = Convert.ToInt32(txtPeriod_tabAutenticacaoSessao.Text)
                    };
                }

                if (cbActions_tabAutenticacaoSessao.SelectedItem == "login_set")
                {
                    body = new AutenticacaoSessaoRequestDto(body)
                    {
                        User = txtUserSet_tabAutenticacaoSessao.Text,
                        Password = txtPasswordSet_tabAutenticacaoSessao.Text
                    };
                }

                if (cbActions_tabAutenticacaoSessao.SelectedItem == "http_auth")
                {
                    body = new AutenticacaoSessaoRequestDto(body)
                    {
                        Enable = Convert.ToInt32(txtEnable_tabAutenticacaoSessao.Text),
                        Scheme = txtScheme_tabAutenticacaoSessao.Text,
                        User = txtUser_tabAutenticacaoSessao.Text,
                        Password = txtPassword_tabAutenticacaoSessao.Text
                    };
                }

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                if (response.StatusCode == HttpStatusCode.OK)
                    gbStatus.ForeColor = Color.Green;
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<AutenticacaoSessaoResponseDto>(response.Content);

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private void cbActions_tabAutenticacaoSessao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar();

            if (cbActions_tabAutenticacaoSessao.SelectedItem == "session_set")
            {
                lblEnable_tabAutenticaoSessao.Visible = true;
                txtEnable_tabAutenticacaoSessao.Visible = true;
                lblPeriod_tabAutenticaoSessao.Visible = true;
                txtPeriod_tabAutenticacaoSessao.Visible = true;
                lblScheme_tabAutenticacaoSessao.Visible = false;
                txtScheme_tabAutenticacaoSessao.Visible = false;
                lblUser_tabAutenticacaoSessao.Visible = false;
                txtUser_tabAutenticacaoSessao.Visible = false;
                lblPassword_tabAutenticacaoSessao.Visible = false;
                txtPassword_tabAutenticacaoSessao.Visible = false;
                lblUserSet_tabAutenticacaoSessao.Visible = false;
                txtUserSet_tabAutenticacaoSessao.Visible = false;
                lblPasswordSet_tabAutenticacaoSessao.Visible = false;
                txtPasswordSet_tabAutenticacaoSessao.Visible = false;
            }
            else if (cbActions_tabAutenticacaoSessao.SelectedItem == "http_auth")
            {
                lblEnable_tabAutenticaoSessao.Visible = true;
                txtEnable_tabAutenticacaoSessao.Visible = true;
                lblPeriod_tabAutenticaoSessao.Visible = false;
                txtPeriod_tabAutenticacaoSessao.Visible = false;
                lblScheme_tabAutenticacaoSessao.Visible = true;
                txtScheme_tabAutenticacaoSessao.Visible = true;
                lblUser_tabAutenticacaoSessao.Visible = true;
                txtUser_tabAutenticacaoSessao.Visible = true;
                lblPassword_tabAutenticacaoSessao.Visible = true;
                txtPassword_tabAutenticacaoSessao.Visible = true;
                lblUserSet_tabAutenticacaoSessao.Visible = false;
                txtUserSet_tabAutenticacaoSessao.Visible = false;
                lblPasswordSet_tabAutenticacaoSessao.Visible = false;
                txtPasswordSet_tabAutenticacaoSessao.Visible = false;
            }
            else if (cbActions_tabAutenticacaoSessao.SelectedItem == "login_set")
            {
                lblEnable_tabAutenticaoSessao.Visible = false;
                txtEnable_tabAutenticacaoSessao.Visible = false;
                lblPeriod_tabAutenticaoSessao.Visible = false;
                txtPeriod_tabAutenticacaoSessao.Visible = false;
                lblScheme_tabAutenticacaoSessao.Visible = false;
                txtScheme_tabAutenticacaoSessao.Visible = false;
                lblUser_tabAutenticacaoSessao.Visible = false;
                txtUser_tabAutenticacaoSessao.Visible = false;
                lblPassword_tabAutenticacaoSessao.Visible = false;
                txtPassword_tabAutenticacaoSessao.Visible = false;
                lblUserSet_tabAutenticacaoSessao.Visible = true;
                txtUserSet_tabAutenticacaoSessao.Visible = true;
                lblPasswordSet_tabAutenticacaoSessao.Visible = true;
                txtPasswordSet_tabAutenticacaoSessao.Visible = true;
            }
            else
            {
                lblEnable_tabAutenticaoSessao.Visible = false;
                txtEnable_tabAutenticacaoSessao.Visible = false;
                lblPeriod_tabAutenticaoSessao.Visible = false;
                txtPeriod_tabAutenticacaoSessao.Visible = false;
                lblScheme_tabAutenticacaoSessao.Visible = false;
                txtScheme_tabAutenticacaoSessao.Visible = false;
                lblUser_tabAutenticacaoSessao.Visible = false;
                txtUser_tabAutenticacaoSessao.Visible = false;
                lblPassword_tabAutenticacaoSessao.Visible = false;
                txtPassword_tabAutenticacaoSessao.Visible = false;
                lblUserSet_tabAutenticacaoSessao.Visible = false;
                txtUserSet_tabAutenticacaoSessao.Visible = false;
                lblPasswordSet_tabAutenticacaoSessao.Visible = false;
                txtPasswordSet_tabAutenticacaoSessao.Visible = false;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                string authorizationBasic = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{txtLoginUser.Text}:{txtLoginPassword.Text}"));

                request.AddHeader("Authorization", $"Basic {authorizationBasic}");

                var body = new
                {
                    Action = "login",
                    User = txtLoginUser.Text,
                    Password = txtLoginPassword.Text
                };

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<AutenticacaoSessaoResponseDto>(response.Content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    gbStatus.ForeColor = Color.Green;

                    tsslToken.Visible = true;
                    tsslToken.BackColor = Color.Green;
                    tsslToken.ForeColor = Color.Black;
                    tsslToken.Text = obj.Token;
                }
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

        private async void btnLogout_Click(object sender, EventArgs e)
        {
            var dtInicial = DateTime.Now;

            try
            {
                progressBar1.Value = progressBar1.Value = 0;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = string.Empty;

                var options = new RestClientOptions($"http://{txtEndPoint.Text}/api")
                {
                    MaxTimeout = 2000,
                    ThrowOnAnyError = true
                };

                if (http_auth_enabled.Checked) {
                    options.Authenticator = new HttpBasicAuthenticator(httpUser.Text, httpPassword.Text);
                }

                progressBar1.Value = progressBar1.Value += 10;

                using var client = new RestClient(options);

                var request = new RestRequest("", Method.Post);

                request.AddHeader("Content-Type", "application/json");

                string authorizationBasic = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes($"{txtLoginUser.Text}:{txtLoginPassword.Text}"));

                request.AddHeader("Authorization", $"Basic {authorizationBasic}");

                var body = new
                {
                    Action = "logout"
                };

                request.AddStringBody(JsonConvert.SerializeObject(body), DataFormat.Json);

                progressBar1.Value = progressBar1.Value += 10;

                RestResponse response = await client.ExecuteAsync(request);

                gbStatus.Text = $"Status: {(int)response.StatusCode} {response.StatusCode}";

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var obj = JsonConvert.DeserializeObject<AutenticacaoSessaoResponseDto>(response.Content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    gbStatus.ForeColor = Color.Green;

                    tsslToken.Visible = false;
                    tsslToken.Text = string.Empty;
                }
                else
                    gbStatus.ForeColor = Color.Red;

                progressBar1.Value = progressBar1.Value += 10;

                progressBar1.Value = progressBar1.Value += 10;

                txtStatus.Text = JsonConvert.SerializeObject(obj, Formatting.Indented, settings);

                progressBar1.Value = progressBar1.Value = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                TimeSpan tp = DateTime.Now - dtInicial;

                tsslTempoResposta.Text = $"Tempo de resposta: {tp.Milliseconds.ToString()} ms";
            }
        }

    }
}
