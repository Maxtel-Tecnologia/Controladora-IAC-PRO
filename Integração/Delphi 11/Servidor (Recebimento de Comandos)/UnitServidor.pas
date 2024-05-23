unit UnitServidor;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants,
  System.Classes, Vcl.Graphics, Vcl.Controls, Vcl.Forms, Vcl.Dialogs,
  Vcl.StdCtrls, Vcl.ExtCtrls, Vcl.Mask, Vcl.DBCtrls, System.Actions,
  Vcl.ActnList, Vcl.ToolWin, Vcl.ComCtrls, Vcl.Menus, Vcl.ActnMan, Vcl.ActnCtrls,
  Vcl.CheckLst, Vcl.Grids, System.JSON, IdBaseComponent, IdComponent,
  IdCustomTCPServer, IdCustomHTTPServer, IdHTTPServer, IdContext;

type
  TFormServidor = class(TForm)
    GroupBoxLogin: TGroupBox;
    GroupBoxResponse: TGroupBox;
    LabelServerPort: TLabel;
    ServerPort: TEdit;
    ServerStart: TButton;
    Memo: TMemo;
    procedure AddMessage(Text: string); overload;
    procedure ServerStartClick(Sender: TObject);
    procedure HTTPServerOnCommandGet(AContext: TIdContext; ARequestInfo: TIdHTTPRequestInfo; AResponseInfo: TIdHTTPResponseInfo);
    procedure ConfigPushAPIClick(Sender: TObject);
    procedure FormClose(Sender: TObject; var Action: TCloseAction);

  private
    { Private declarations }
  public
  end;

var
  FormServidor: TFormServidor;
  IdHTTPServer: TIdHTTPServer;

implementation

{$R *.dfm}

function StreamToString(aStream: TStream): string;
var
  SS: TStringStream;
begin
  if aStream <> nil then
  begin
    SS := TStringStream.Create('');
    try
      SS.CopyFrom(aStream, 0);
      Result := SS.DataString;
    finally
      SS.Free;
    end;
  end
  else
  begin
    Result := '';
  end;
end;

procedure TFormServidor.AddMessage(Text: string);
begin
  Memo.lines.add(Text);
end;

procedure TFormServidor.ServerStartClick(Sender: TObject);
begin
  if assigned(IdHTTPServer) then
  begin
    IdHTTPServer.Active := False;
    IdHTTPServer.Free;
    AddMessage('Servidor Web finalizado');
  end;
  IdHTTPServer := TIdHTTPServer.Create(nil);
  IdHTTPServer.OnCommandGet := HTTPServerOnCommandGet;
  IdHTTPServer.DefaultPort := StrToInt(ServerPort.Text);
  IdHTTPServer.Active := True;
  AddMessage('Servidor Web iniciado');
end;

procedure TFormServidor.ConfigPushAPIClick(Sender: TObject);
begin
  ShowMessage('Aguardando protocolo HTTP 1.1');
end;

procedure TFormServidor.FormClose(Sender: TObject; var Action: TCloseAction);
begin
  if assigned(IdHTTPServer) then
  begin
    IdHTTPServer.Active := False;
    IdHTTPServer.Free;
  end;
end;

procedure TFormServidor.HTTPServerOnCommandGet(AContext: TIdContext; ARequestInfo: TIdHTTPRequestInfo; AResponseInfo: TIdHTTPResponseInfo);
var
  dados_string, serial_number: string;
  dados_Json: TJSonValue;
begin
  if (ARequestInfo.Command = 'POST') then
  begin
    if assigned(ARequestInfo.PostStream) then
    begin
      ARequestInfo.PostStream.Position := 0;
      dados_string := StreamToString(ARequestInfo.PostStream);
      if not (dados_string.IsEmpty) then
      begin
        // Converte os dados de string para um Json
        dados_Json := TJSONObject.ParseJSONValue(dados_string);

        // Exemplo que como extrair um parametro do json
        serial_number := dados_Json.GetValue<string>('serial_number');

        // Adiciona no Memo para ilustrar o comando recebido da IAC-PRO
        AddMessage('Recebido em: ' + FormatDateTime('yyyy-mm-dd hh:nn:ss.zzz', now));
        AddMessage('Tipo: ' + ARequestInfo.Command);
        AddMessage('Endpoint: ' + ARequestInfo.Document);
        AddMessage('RemoteIP: ' + ARequestInfo.RemoteIP);
        AddMessage('Body: ' + dados_Json.ToString);
        AddMessage('************************************');

        // Responde com algo, aqui podemos responder enviando qualquer comando
        AResponseInfo.ContentType := 'application/json';
        AResponseInfo.CharSet := 'UTF-8';
        AResponseInfo.ContentText := '{}';

        // Pode-se responder com qualquer comando para a IAC-PRO
        // Exemplo um comando de liberação de acesso ou qualquer outro necessário
        // AResponseInfo.ContentText := '{"action": "buzzer", "token": "", "period_on": 100, "period_off": 100, "rep": 3}';
      end;

    end;
  end;
end;

end.

