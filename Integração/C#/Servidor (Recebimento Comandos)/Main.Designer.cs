namespace IAC_PRO_Servidor_Web
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtRotas = new TextBox();
            btnIniciarServidorWeb = new Button();
            label1 = new Label();
            txtPortaServidorWeb = new TextBox();
            statusStrip1 = new StatusStrip();
            tsslHost = new ToolStripStatusLabel();
            tsslIp = new ToolStripStatusLabel();
            tsslToken = new ToolStripStatusLabel();
            tsslTempoResposta = new ToolStripStatusLabel();
            tsslStatusServidor = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            gbStatus = new GroupBox();
            txtResponse = new TextBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnConfigurarPushAPI = new Button();
            txtHeartBeatPeriodo = new TextBox();
            txtIpIACPro = new TextBox();
            txtUrl = new TextBox();
            label2 = new Label();
            txtHostServidor = new TextBox();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            gbStatus.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtRotas);
            groupBox1.Controls.Add(btnIniciarServidorWeb);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtPortaServidorWeb);
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(557, 149);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Servidor Web";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(193, 17);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 10;
            label6.Text = "Rotas";
            // 
            // txtRotas
            // 
            txtRotas.Location = new Point(193, 41);
            txtRotas.Margin = new Padding(3, 4, 3, 4);
            txtRotas.Multiline = true;
            txtRotas.Name = "txtRotas";
            txtRotas.ScrollBars = ScrollBars.Vertical;
            txtRotas.Size = new Size(178, 97);
            txtRotas.TabIndex = 9;
            txtRotas.Leave += txtRotas_Leave;
            // 
            // btnIniciarServidorWeb
            // 
            btnIniciarServidorWeb.BackColor = Color.Black;
            btnIniciarServidorWeb.ForeColor = Color.White;
            btnIniciarServidorWeb.Location = new Point(392, 79);
            btnIniciarServidorWeb.Margin = new Padding(3, 4, 3, 4);
            btnIniciarServidorWeb.Name = "btnIniciarServidorWeb";
            btnIniciarServidorWeb.Size = new Size(144, 49);
            btnIniciarServidorWeb.TabIndex = 8;
            btnIniciarServidorWeb.Text = "Iniciar Servidor Web";
            btnIniciarServidorWeb.UseVisualStyleBackColor = false;
            btnIniciarServidorWeb.Click += btnIniciarServidorWeb_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 85);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 1;
            label1.Text = "Porta Local do Servidor";
            // 
            // txtPortaServidorWeb
            // 
            txtPortaServidorWeb.Location = new Point(8, 109);
            txtPortaServidorWeb.Margin = new Padding(3, 4, 3, 4);
            txtPortaServidorWeb.Name = "txtPortaServidorWeb";
            txtPortaServidorWeb.Size = new Size(178, 27);
            txtPortaServidorWeb.TabIndex = 0;
            txtPortaServidorWeb.Leave += txtPortaServidorWeb_Leave;
            // 
            // statusStrip1
            // 
            statusStrip1.GripStyle = ToolStripGripStyle.Visible;
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslHost, tsslIp, tsslToken, tsslTempoResposta, tsslStatusServidor, toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 765);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(914, 30);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslHost
            // 
            tsslHost.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslHost.BorderStyle = Border3DStyle.SunkenInner;
            tsslHost.Name = "tsslHost";
            tsslHost.Size = new Size(4, 24);
            // 
            // tsslIp
            // 
            tsslIp.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslIp.BorderStyle = Border3DStyle.SunkenInner;
            tsslIp.Name = "tsslIp";
            tsslIp.Size = new Size(4, 24);
            // 
            // tsslToken
            // 
            tsslToken.Name = "tsslToken";
            tsslToken.Size = new Size(0, 24);
            // 
            // tsslTempoResposta
            // 
            tsslTempoResposta.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            tsslTempoResposta.BorderStyle = Border3DStyle.SunkenInner;
            tsslTempoResposta.Name = "tsslTempoResposta";
            tsslTempoResposta.Size = new Size(4, 24);
            // 
            // tsslStatusServidor
            // 
            tsslStatusServidor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tsslStatusServidor.Name = "tsslStatusServidor";
            tsslStatusServidor.Size = new Size(0, 24);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            toolStripStatusLabel1.BorderStyle = Border3DStyle.SunkenInner;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(94, 24);
            toolStripStatusLabel1.Text = "Versão: 1.0.0";
            toolStripStatusLabel1.TextDirection = ToolStripTextDirection.Horizontal;
            // 
            // gbStatus
            // 
            gbStatus.Controls.Add(txtResponse);
            gbStatus.Location = new Point(11, 308);
            gbStatus.Margin = new Padding(3, 4, 3, 4);
            gbStatus.Name = "gbStatus";
            gbStatus.Padding = new Padding(3, 4, 3, 4);
            gbStatus.Size = new Size(903, 451);
            gbStatus.TabIndex = 2;
            gbStatus.TabStop = false;
            gbStatus.Text = "Comandos Recebidos da IAC-PRO";
            // 
            // txtResponse
            // 
            txtResponse.BorderStyle = BorderStyle.FixedSingle;
            txtResponse.Location = new Point(7, 29);
            txtResponse.Margin = new Padding(3, 4, 3, 4);
            txtResponse.Multiline = true;
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.ScrollBars = ScrollBars.Vertical;
            txtResponse.Size = new Size(888, 413);
            txtResponse.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnConfigurarPushAPI);
            groupBox2.Controls.Add(txtHeartBeatPeriodo);
            groupBox2.Controls.Add(txtIpIACPro);
            groupBox2.Controls.Add(txtUrl);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtHostServidor);
            groupBox2.Location = new Point(11, 173);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(903, 127);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Codigurar IAC-PRO Push API";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(563, 51);
            label5.Name = "label5";
            label5.Size = new Size(151, 20);
            label5.TabIndex = 16;
            label5.Text = "HeartBeat Período (s)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(378, 51);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 15;
            label4.Text = "IP IAC-PRO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 51);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 14;
            label3.Text = "URL";
            // 
            // btnConfigurarPushAPI
            // 
            btnConfigurarPushAPI.BackColor = Color.Black;
            btnConfigurarPushAPI.ForeColor = Color.White;
            btnConfigurarPushAPI.Location = new Point(751, 56);
            btnConfigurarPushAPI.Margin = new Padding(3, 4, 3, 4);
            btnConfigurarPushAPI.Name = "btnConfigurarPushAPI";
            btnConfigurarPushAPI.Size = new Size(144, 49);
            btnConfigurarPushAPI.TabIndex = 9;
            btnConfigurarPushAPI.Text = "Configurar Push API";
            btnConfigurarPushAPI.UseVisualStyleBackColor = false;
            btnConfigurarPushAPI.Click += btnConfigurarPushAPI_Click;
            // 
            // txtHeartBeatPeriodo
            // 
            txtHeartBeatPeriodo.Location = new Point(563, 75);
            txtHeartBeatPeriodo.Margin = new Padding(3, 4, 3, 4);
            txtHeartBeatPeriodo.Name = "txtHeartBeatPeriodo";
            txtHeartBeatPeriodo.Size = new Size(178, 27);
            txtHeartBeatPeriodo.TabIndex = 13;
            txtHeartBeatPeriodo.Leave += txtHeartBeatPeriodo_Leave;
            // 
            // txtIpIACPro
            // 
            txtIpIACPro.Location = new Point(378, 75);
            txtIpIACPro.Margin = new Padding(3, 4, 3, 4);
            txtIpIACPro.Name = "txtIpIACPro";
            txtIpIACPro.Size = new Size(178, 27);
            txtIpIACPro.TabIndex = 12;
            txtIpIACPro.Leave += txtIpIACPro_Leave;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(193, 75);
            txtUrl.Margin = new Padding(3, 4, 3, 4);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(178, 27);
            txtUrl.TabIndex = 11;
            txtUrl.Leave += txtUrl_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 51);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 10;
            label2.Text = "Host Servidor";
            // 
            // txtHostServidor
            // 
            txtHostServidor.Location = new Point(8, 75);
            txtHostServidor.Margin = new Padding(3, 4, 3, 4);
            txtHostServidor.Name = "txtHostServidor";
            txtHostServidor.Size = new Size(178, 27);
            txtHostServidor.TabIndex = 9;
            txtHostServidor.Leave += txtHostServidor_Leave;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(914, 795);
            Controls.Add(groupBox2);
            Controls.Add(gbStatus);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IAC-PRO-Servidor-Web | C#";
            Load += Main_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            gbStatus.ResumeLayout(false);
            gbStatus.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslHost;
        private ToolStripStatusLabel tsslIp;
        private GroupBox gbStatus;
        private TextBox txtResponse;
        private ToolStripStatusLabel tsslTempoResposta;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel tsslToken;
        private Button btnIniciarServidorWeb;
        private Label label1;
        private TextBox txtPortaServidorWeb;
        private GroupBox groupBox2;
        private Label label2;
        private TextBox txtHostServidor;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnConfigurarPushAPI;
        private TextBox txtHeartBeatPeriodo;
        private TextBox txtIpIACPro;
        private TextBox txtUrl;
        private ToolStripStatusLabel tsslStatusServidor;
        private Label label6;
        private TextBox txtRotas;
    }
}
