<?php
function enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth)
{
    set_time_limit(0);
    $tempo_ini = microtime(true);
    $success_response = false;
    $statusCode_response = 0;
    $msg_response = 'Não mapeado';
    $ch = curl_init();
    $postData = json_encode($body_data);
    $HTTPHEADER = array(
        "cache-control: no-cache",
        "Connection: keep-alive",
        "Accept-encoding: deflate, gzip",
        'Content-Type: application/json'
    );
    curl_setopt_array($ch, array(
        CURLOPT_URL => $ip_device . '/api',
        CURLOPT_RETURNTRANSFER => true,
        CURLOPT_ENCODING => 'gzip,deflate',
        CURLOPT_MAXREDIRS => 10,
        CURLOPT_TIMEOUT => 2,
        CURLOPT_FOLLOWLOCATION => true,
        CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
        CURLOPT_CUSTOMREQUEST => $method,
        CURLOPT_HTTPHEADER => $HTTPHEADER,
        CURLOPT_HEADER => false,
        CURLOPT_POSTFIELDS => $postData,
        CURLOPT_USERAGENT => 'IACAPI',
        CURLOPT_SSL_VERIFYPEER => false,
    ));

    if ($http_auth['enabled']) {
        $user = $http_auth['user'];
        $password = $http_auth['pass'];
        curl_setopt_array($ch, array(
            CURLOPT_HTTPAUTH => CURLAUTH_BASIC,
            CURLOPT_USERPWD => "$user:$password",
        ));
    }

    $resposta = curl_exec($ch);
    $info_curl = curl_getinfo($ch);
    $resposta_array = json_decode($resposta, true);

    if ($info_curl['http_code'] == '0') {
        $success_response = false;
        $statusCode_response = 408;
        $msg_response = ", Time-out de comunicacao, IP: $ip_device";
    } else if (isset($resposta_array['error_code']) and ($resposta_array['error_code'] == 0)) {
        $success_response = true;
        $statusCode_response = 200;
        $msg_response = $resposta;
    } else {
        $success_response = false;
        //die(var_dump($resposta_array));
        $msg_response = '';

        $statusCode_response = @$resposta_array['error_code'];
        if (isset($resposta_array['action'])) {
            $msg_response .= ', action ' . $resposta_array['action'];
        }
        if (isset($resposta_array['error_code'])) {
            $msg_response .= ', error_code ' . $resposta_array['error_code'];
        }
        if (isset($resposta_array['error_message'])) {
            $msg_response .= ', error_message ' . $resposta_array['error_message'];
        }
        if (isset($resposta_array['server_message'])) {
            $msg_response .= ', server_message ' . $resposta_array['server_message'];
        }
        if (isset($resposta_array['server_message'])) {
            $msg_response .= ', server_message ' . $resposta_array['server_message'];
        }
    }

    curl_close($ch);
    $tempo_exec = round((microtime(true) - $tempo_ini), 4) . " segundos";
    if ($success_response) {
        $response = array(
            'success' => true,
            'message' => 'Comando enviado com sucesso',
            "statusCode" => $statusCode_response,
            'details' => $msg_response,
            "time_exec" => $tempo_exec,
            "ip_iac" => $ip_device,
        );
    } else {
        $response = array(
            'success' => false,
            'message' => 'Falha ao enviar comando',
            "statusCode" => $statusCode_response,
            'details' => $msg_response,
            "time_exec" => $tempo_exec,
            "ip_iac" => $ip_device,
        );
    }
    return ($response);
}

set_time_limit(0);
date_default_timezone_set('America/Sao_Paulo');
$tempo_ini = microtime(true);
$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, true);
$ip_device = $input['ip_device'];
$method = 'POST';
$http_auth = array(
    "enabled" => false,
    "user" => '',
    "pass" => ''
);
$session = array(
    "enabled" => false,
    "user" => '',
    "pass" => '',
    "token" => ''
);
if ($input['http_auth']) {
    $http_auth = array(
        "enabled" => true,
        "user" => $input['http_user'],
        "pass" => $input['http_pass']
    );
}
if ($input['session_enabled']) {
    $session = array(
        "enabled" => true,
        "user" => $input['session_user'],
        "pass" => $input['session_pass'],
        "token" => $input['session_token'],
    );
}
switch ($input['acao']) {
    case 'buzzer':
        $body_data = array(
            "action" => "buzzer",
            "token" =>  $session['token'],
            "period_on" => 100,
            "period_off" => 100,
            "rep" => 3,
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'login':
        $body_data = array(
            "action" => "login",
            "user" => $session['user'],
            "password" => $session['pass']
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'logout':
        $body_data = array(
            "action" => "logout"
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'obter_info':
        $body_data = array(
            "action" => "version",
            "token" =>  $session['token']
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'uptime':
        $body_data = array(
            "action" => "uptime",
            "token" =>  $session['token']
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'door_access':
        $body_data = array(
            "action" => "door_access",
            "token" =>  $session['token'],
            "cmd" => 0,
            "door" => 1,
            "open_time" => 0,
            "relay_time" => 0,
            "ref" => 123456789
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'set_api':
        $body_data = array(
            "action" => "push_api_set",
            "token" => $session['token'],
            "enable" => 1,
            "host" => $input['host_api'],
            "port" => intval($input['port_api']),
            "heartbeat_period" => intval($input['tempo_api']),
            "user" => "admin",
            "password" => "admin",
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'eth0_set':
        $body_data = array(
            "action" => "eth0_set",
            "token" => $session['token'],
            "dhcp" => 1
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    case 'door_set':
        $body_data = array(
            "action" => "door_set",
            "token" => $session['token'],
            "door" =>  1,
            "enable" =>  1,
            "relay_output" =>  1,
            "relay_time" =>  5000,
            "open_time" =>  5,
            "sensor_input" =>  1,
            "sensor_idle" =>  0,
            "rex_input" =>  5,
            "rex_idle" =>  0,
            "picto_output" =>  9,
            "picto_idle" =>  0,
            "countdown" =>  0,
            "events" =>  1,
            "ctrl_mode" =>  1,
            "siren_intrusion" =>  1,
            "siren_expiry" =>  1
        );
        $feedback = enviar_comando_iacpro($ip_device, $method, $body_data, $http_auth);
        break;
    default:
        $feedback = array(
            'success' => false,
            'message' => 'acao não informada',
            "statusCode" => '',
            'details' => '',
            "time_exec" => '',
            "ip_iac" => ''
        );
        break;
}

echo json_encode($feedback, true);
