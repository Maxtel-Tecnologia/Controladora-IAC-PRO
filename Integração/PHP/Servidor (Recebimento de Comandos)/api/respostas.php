<?php
function return_nao_autorizado($text)
{
    $resultados = array(
        'success' => false,
        'statusCode' => 401,
        'message' => "$text"
    );
    http_response_code(401);
    die(json_encode($resultados, JSON_PRETTY_PRINT));
}

function return_sucesso($dados_array)
{
    http_response_code(200);
    die(json_encode($dados_array, JSON_PRETTY_PRINT));
}

function return_libera_acesso_porta($door, $referencia, $open_time = 0, $relay_time = 0, $cmd = 0)
{
    $resultados = array(
        'action' => "door_access",
        "cmd" => intval($cmd),
        "door" => intval($door),
        "open_time" => intval($open_time),
        "relay_time" => intval($relay_time),
        "ref" => intval($referencia)
    );

    http_response_code(200);
    die(json_encode($resultados, JSON_PRETTY_PRINT));
}

function return_bad_request($text)
{
    $resultados = array(
        'success' => false,
        'statusCode' => 400,
        "message" => "$text"
    );
    http_response_code(400);
    die(json_encode($resultados, JSON_PRETTY_PRINT));
}

function return_simples()
{
    http_response_code(200);
    $data = array();
    die(json_encode($data, JSON_PRETTY_PRINT));
}

function return_bips($qtd, $period_on, $period_off)
{
    $resultados = array(
        'action' => "buzzer",
        "period_on" => $period_on,
        'period_off' => $period_off,
        "rep" => $qtd
    );
    http_response_code(200);
    die(json_encode($resultados, JSON_PRETTY_PRINT));
}


function return_bips_nao_autorizado($text)
{
    $resultados = array(
        'action' => "buzzer",
        "period_on" => 10,
        'period_off' => 10,
        "rep" => 10,
        'message' => "$text"
    );
    http_response_code(200);
    die(json_encode($resultados, JSON_PRETTY_PRINT));
}
