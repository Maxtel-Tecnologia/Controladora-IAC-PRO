# Exemplo em C# para recebimento de comandos da controladora IAC PRO
## *Introdução*
Esse é um exemplo de como receber e tratar comandos enviados pela controladora IAC-PRO a um computador utilizando uma aplicação desenvolvida em C#
## Pré-Requisitos
É necessário ter o .NET 8.0 - SDK 8.0.300.

Lembrando que a url que a controladora envia por padrão é `http://host:porta/api/endpoint`

| Endpoint | Descrição |
| ------ | ------ |
| heartbeat | Requisição periódica para o servidor   |
| card_present | Leitura de cartão ou QRCode |
| door_event | Eventos/registros/alarmes referente ao controle de portas |
| turnstile_event | Eventos/registros/alarmes referente ao controle de portas |

Necessário configurar na controladora IAC-Pro o host e a porta desejada através do push_api_set, o servidor web Kestrel deve ser inicializado na mesma porta que foi configurado.

Se na controladora foi configurado o host como `192.168.1.1` e porta `3000`, o computador deverá ser configurado com esse mesmo ip e iniciar o servidor web kestrel na mesma porta, no host pode-se utilizar o endereço quer preferir, inclusive o nome do dominio ou computador na rede, exemplo: `www.seudominio.com.br`, lembrando que para utilizar desta forma a controladora precisa estar com as configurações de DNS corretas.
```
Onde:
192.168.1.1 => é o endereço IP local do computador
3000 => É a porta que o servidor php irá funcionar para receber os comandos da controladora IAC-Pro
```
## Observações
### heartbeat
O item heartbeat_period define o tempo que o comando heartbeat é enviado ao servidor, esse tempo é em segundos, para desativar deve-se configurar com o valor zero 
### Teste alteranativo (Mockoon)
Para efetuar testes alternativos afim de garantir que a controladora esteja enviando comandos corretamente para o computador pode ser utilizada uma ferramenta chamada Mockoon. 
[Clique aqui para efetuar o download do Mockoon](https://mockoon.com/download/#download-section)