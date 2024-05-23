<?php
// Comando a ser recebido via post
// {"action":"card_present","hardware":"IAC-PRO","serial_number":"MP170037","reader_id":1,"reader_type":0,"reader_data":"10756006"} 
require "header.php";
$lista_cartoes = array(
    "00100001",
    "00200002",
    "00300003"
);
$inputJSON = file_get_contents('php://input');
$input = json_decode($inputJSON, true);
$inputs_var = filter_var_array($input, FILTER_DEFAULT, FILTER_NULL_ON_FAILURE);
if ($inputs_var['action'] == "card_present") {
    $exists = in_array($inputs_var['reader_data'], $lista_cartoes);
    if ($exists) {
        return_libera_acesso_porta($inputs_var['reader_id'], $inputs_var['reader_data'], 0, 0, 0);
    } else {
        return_bips(3, 100, 100);
    }
}
