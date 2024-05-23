<?php
// Comando a ser recebido via post
// {"action":"turnstile_event","hardware":"IAC-PRO","serial_number":"MP170XXX","turnstile":1,"event":3,"access_way":1,"src_req":2,"ref":0} 
require "header.php";
$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, true);
$inputs_var = filter_var_array($input, FILTER_DEFAULT, FILTER_NULL_ON_FAILURE);
if ($inputs_var['action'] == "turnstile_event") {
    // se for um comando válido responde com o comando de acionamento de alguns bips, nesse ponto é possível retornar com qualquer tipo de comando nesse momento, até mesmo somente um comando com o body vazio
    return_bips(5, 100, 15);
}
