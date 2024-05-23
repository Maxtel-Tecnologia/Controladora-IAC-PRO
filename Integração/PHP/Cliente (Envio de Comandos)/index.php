<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo envio de comandos para IAC-PRO</title>
</head>
<style>
    .container {
        display: flex;
    }

    .container div {
        flex: 1;
        border: 1px solid black;
        padding: 10px;
        margin: 10px;
    }
</style>

<body>
    <div class="container">
        <div>
            <h4>Ip Controladora IAC-PRO</h4>
            <p> Lista de IPs (separado por virgula): - <input type="checkbox" value="1" name="todas" id="todas"><label for="todas">Enviar comandos para todos esses IP´S</label></p>
            <p><textarea name="lista_ips" id="lista_ips" rows="2" cols="60">192.168.1.200, 192.168.1.201, 192.168.1.202</textarea></p>
            <p>Host/IP IAC-Pro: <input type="text" value="192.168.1.200" name="ip_iac" id="ip_iac"></p>
            <hr>
            <h4>Configuração para o push_api_set na IAC-PRO (Servidor)</h4>
            <p>Tempo PUSH API: <input type="text" value="5" name="tempo_api" id="tempo_api"></p>
            <p>Host/IP PUSH API: <input type="text" value="192.168.1.1" name="host_api" id="host_api"></p>
            <p>Porta PUSH API: <input type="text" value="80" name="port_api" id="port_api"></p>
            <hr>
            <h4>HTTP Auth Basic:</h4>
            <p><input type="checkbox" value="1" name="http_auth" id="http_auth"><label for="http_auth">Utilizar</label></p>
            <p>Usuário: <input type="text" value="admin" name="http_user" id="http_user"></p>
            <p>Senha: <input type="text" value="admin" name="http_pass" id="http_pass"></p>
            <hr>
            <h4>Controle de Sessão:</h4>
            <p><input type="checkbox" value="1" name="session_enabled" id="session_enabled"><label for="session_enabled">Utilizar</label></p>
            <p>Usuário: <input type="text" value="admin" name="session_user" id="session_user"></p>
            <p>Senha: <input type="text" value="admin" name="session_pass" id="session_pass"></p>
            <p>Token: <input type="text" name="session_token" id="session_token"></p>
            <button type="button" id="login" name="login" value="1">Login</button>
            <button type="button" id="logout" name="logout" value="1">Logout</button>
            <hr>
        </div>
        <div>
            <p>
                <label for="filtro" class="control-label">Selecione uma opção</label>
                <select class="form-control" id="comando" name="comando">
                    <option value="buzzer">Enviar beep</option>
                    <option value="obter_info">Obter Informações</option>
                    <option value="uptime">Uptime</option>
                    <option value="door_access">Enviar liberação</option>
                    <option value="set_api">Configurar Servidor Push</option>
                    <option value="eth0_set">Habilitar DHCP</option>
                    <option value="door_set">Configura porta 1</option>
                </select>
                <button type="button" id="enviar_comando" name="enviar_comando" value="enviar_comando">Enviar Comando</button>
            </p>
            <p id="feedback_send" name="feedback_send"></p>
            <p id="feedback" name="feedback"></p>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script>
        $(document).ready(function() {
            $("#login").click(function() {
                if (!$('#session_enabled').prop('checked')) {
                    alert('Checkbox não está selecionado para utilizar a autenticação de sessão');
                    return false;
                }
                $("#feedback_send").html('Enviando comando, aguarde');
                $("#feedback").html('');
                let ip_iac = $("#ip_iac").val();
                enviar_comando('login', ip_iac);
            });
            $("#logout").click(function() {
                $("#feedback_send").html('Enviando comando, aguarde');
                $("#feedback").html('');
                let ip_iac = $("#ip_iac").val();
                enviar_comando('logout', ip_iac);
            });
            $("#enviar_comando").click(function() {
                let todas = $("#todas").is(":checked");
                let ip_iac = $("#ip_iac").val();
                let q_comando = $('#comando').val();
                $("#feedback_send").html('Enviando comando, aguarde');
                $("#feedback").html('');
                if (!todas) {
                    enviar_comando(q_comando, ip_iac);
                } else {
                    let lista_ips = $('textarea#lista_ips').val();
                    let lista_ips_Array = lista_ips.split(",");
                    lista_ips_Array.forEach(function(ip) {
                        enviar_comando(q_comando, ip.trim());
                    });
                }
            });

            function enviar_comando(q_acao, q_ip) {
                let tempo_api = $("#tempo_api").val();
                let host_api = $("#host_api").val();
                let port_api = $("#port_api").val();
                let http_auth = $("#http_auth").prop('checked');
                let http_user = $("#http_user").val();
                let http_pass = $("#http_pass").val();
                let session_enabled = $("#session_enabled").prop('checked');
                let session_user = $("#session_user").val();
                let session_pass = $("#session_pass").val();
                let session_token = $("#session_token").val();
                let bodydata = {
                    "acao": q_acao,
                    "ip_device": q_ip,
                    "tempo_api": tempo_api,
                    "host_api": host_api,
                    "port_api": port_api,
                    "http_auth": http_auth,
                    "http_user": http_user,
                    "http_pass": http_pass,
                    "session_enabled": session_enabled,
                    "session_user": session_user,
                    "session_pass": session_pass,
                    "session_token": session_token,
                }
                bodydata = JSON.stringify(bodydata);
                $.ajax({
                    url: 'iac_api.php',
                    type: 'POST',
                    data: bodydata,
                    success: function(data) {
                        try {
                            retorna_json = JSON.parse(data);
                            let feedback_before = $("#feedback").html();
                            $("#feedback").html('');
                            $("#feedback_send").html('');
                            if (retorna_json.success) {
                                $("#feedback").append(retorna_json.message);
                                $("#feedback").append('<br>IP: ' + retorna_json.ip_iac);
                                $("#feedback").append('<br>Tempo execução: ' + retorna_json.time_exec);
                                $("#feedback").append('<br>Resposta RAW: ' + retorna_json.details);
                                if (q_acao == 'login') {
                                    body_login = JSON.parse(retorna_json.details);
                                    $("#session_token").val(body_login.token);
                                }
                            } else if (!retorna_json.success) {
                                $("#feedback").append(retorna_json.message);
                                $("#feedback").append(retorna_json.details);
                            }
                            $("#feedback").append('<hr>');
                            $("#feedback").append(feedback_before);
                        } catch (err) {
                            $("#feedback").html('FALHOU');
                            $("#feedback").append(data);
                        }
                    },
                    error: function(request, status, error) {
                        $("#feedback").html('Erro ao enviar comando');
                    }
                });
            }
        });
    </script>
</body>

</html>