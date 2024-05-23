<?php
// Comando a ser recebido via post
// {"action":"heartbeat","hardware":"IAC-PRO","serial_number":"MP170XXX"}
require "header.php";
switch ($_SERVER['REQUEST_METHOD']) {
    case 'POST':
        $inputJSON = file_get_contents('php://input');
        $input = json_decode($inputJSON, true);
        $inputs_var = filter_var_array($input, FILTER_DEFAULT, FILTER_NULL_ON_FAILURE);
        $action = $inputs_var['action'];
        if (($action == "heartbeat")) {
            $hardware = $inputs_var['hardware'];
            $serial_number = $inputs_var['serial_number'];
            // Pode-se responder com qualquer tipo de comando, estamos enviando um comando de bips
            return_bips(2, 5, 5);
            //return_simples();
        } else {
            die("voce nao solicitou um heartbeat");
        }
        break;
    default:
        die("Método não permitido");
        break;
}
