<?php
set_time_limit(0);
header("Access-Control-Allow-Origin: *");
header("Access-Control-Allow-Headers: *");
header("Access-Control-Allow-Methods: POST, GET, PUT, DELETE, OPTIONS");
header('Content-Type: application/json; charset=utf-8');
date_default_timezone_set('America/Sao_Paulo');
require "respostas.php";
