program Servidor_IAC;

uses
  Vcl.Forms,
  UnitServidor in 'UnitServidor.pas' {FormServidor};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFormServidor, FormServidor);
  Application.Run;
end.
