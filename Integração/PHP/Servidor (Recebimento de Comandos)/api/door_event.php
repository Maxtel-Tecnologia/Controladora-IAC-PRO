<?php
// Comando a ser recebido via post
// {"action":"door_event","hardware":"IAC-PRO","serial_number":"MP170037","door":1,"event":0,"src_req":0,"ref":0} 
require "header.php";
$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, true);
$inputs_var = filter_var_array($input, FILTER_DEFAULT, FILTER_NULL_ON_FAILURE);
if ($inputs_var['action'] == "door_event") {
    // se for um comando válido responde com o comando de acionamento de alguns bips, nesse ponto é possível retornar com qualquer tipo de comando nesse momento, até mesmo somente um comando com o body vazio
    return_bips(5, 100, 15);
}
