object FormServidor: TFormServidor
  Left = 0
  Top = 0
  BorderStyle = bsDialog
  Caption = 'Servidor Web IAC-PRO'
  ClientHeight = 806
  ClientWidth = 817
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Position = poScreenCenter
  OnClose = FormClose
  TextHeight = 13
  object GroupBoxLogin: TGroupBox
    Left = 250
    Top = 7
    Width = 318
    Height = 94
    Caption = 'Servidor Web'
    TabOrder = 0
    object LabelServerPort: TLabel
      Left = 18
      Top = 26
      Width = 111
      Height = 13
      Caption = 'Porta Local do Servidor'
    end
    object ServerPort: TEdit
      Left = 18
      Top = 45
      Width = 121
      Height = 21
      TabOrder = 0
      Text = '3000'
    end
    object ServerStart: TButton
      Left = 162
      Top = 29
      Width = 121
      Height = 37
      Caption = 'Iniciar Servidor Web'
      TabOrder = 1
      OnClick = ServerStartClick
    end
  end
  object GroupBoxResponse: TGroupBox
    Left = 18
    Top = 107
    Width = 782
    Height = 678
    Caption = 'Comandos Recebidos da IAC-PRO'
    TabOrder = 1
    object Memo: TMemo
      Left = 13
      Top = 24
      Width = 755
      Height = 641
      ScrollBars = ssVertical
      TabOrder = 0
    end
  end
end
