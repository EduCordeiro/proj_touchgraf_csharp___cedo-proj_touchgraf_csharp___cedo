namespace proj_touchgraf_csharp___cedo
{
    partial class frmMain
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
            this.tbc_Opcoes = new System.Windows.Forms.TabControl();
            this.tab_Entrada = new System.Windows.Forms.TabPage();
            this.lbl_SelecionePathEntrada = new System.Windows.Forms.Label();
            this.btn_MarcarTodos = new System.Windows.Forms.Button();
            this.btn_DesmarcarTodos = new System.Windows.Forms.Button();
            this.chkl_Arquivos = new System.Windows.Forms.CheckedListBox();
            this.btn_SelecionarPath = new System.Windows.Forms.Button();
            this.txt_PathEntrada = new System.Windows.Forms.TextBox();
            this.tab_Saida = new System.Windows.Forms.TabPage();
            this.lbl_SelecionePathSaidaLabel = new System.Windows.Forms.Label();
            this.btn_SelecionaPathSaida = new System.Windows.Forms.Button();
            this.txt_PathSaida = new System.Windows.Forms.TextBox();
            this.tab_Processamento = new System.Windows.Forms.TabPage();
            this.btn_Processar = new System.Windows.Forms.Button();
            this.dtp_DataProcessamento = new System.Windows.Forms.DateTimePicker();
            this.tab_JaProcessados = new System.Windows.Forms.TabPage();
            this.btn_Reverter = new System.Windows.Forms.Button();
            this.btn_MarcarTodosProcessados = new System.Windows.Forms.Button();
            this.btn_DesmarcarTodosProcessados = new System.Windows.Forms.Button();
            this.chkl_ArquivosProcessados = new System.Windows.Forms.CheckedListBox();
            this.btn_Sobre = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.folderBrowserDialogPathEntrada = new System.Windows.Forms.FolderBrowserDialog();
            this.tbc_Opcoes.SuspendLayout();
            this.tab_Entrada.SuspendLayout();
            this.tab_Saida.SuspendLayout();
            this.tab_Processamento.SuspendLayout();
            this.tab_JaProcessados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbc_Opcoes
            // 
            this.tbc_Opcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbc_Opcoes.Controls.Add(this.tab_Entrada);
            this.tbc_Opcoes.Controls.Add(this.tab_Saida);
            this.tbc_Opcoes.Controls.Add(this.tab_Processamento);
            this.tbc_Opcoes.Controls.Add(this.tab_JaProcessados);
            this.tbc_Opcoes.Location = new System.Drawing.Point(23, 12);
            this.tbc_Opcoes.Name = "tbc_Opcoes";
            this.tbc_Opcoes.SelectedIndex = 0;
            this.tbc_Opcoes.Size = new System.Drawing.Size(669, 366);
            this.tbc_Opcoes.TabIndex = 0;
            // 
            // tab_Entrada
            // 
            this.tab_Entrada.Controls.Add(this.lbl_SelecionePathEntrada);
            this.tab_Entrada.Controls.Add(this.btn_MarcarTodos);
            this.tab_Entrada.Controls.Add(this.btn_DesmarcarTodos);
            this.tab_Entrada.Controls.Add(this.chkl_Arquivos);
            this.tab_Entrada.Controls.Add(this.btn_SelecionarPath);
            this.tab_Entrada.Controls.Add(this.txt_PathEntrada);
            this.tab_Entrada.Location = new System.Drawing.Point(4, 24);
            this.tab_Entrada.Name = "tab_Entrada";
            this.tab_Entrada.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Entrada.Size = new System.Drawing.Size(661, 338);
            this.tab_Entrada.TabIndex = 0;
            this.tab_Entrada.Text = "Entrada";
            this.tab_Entrada.UseVisualStyleBackColor = true;
            // 
            // lbl_SelecionePathEntrada
            // 
            this.lbl_SelecionePathEntrada.AutoSize = true;
            this.lbl_SelecionePathEntrada.Location = new System.Drawing.Point(10, 10);
            this.lbl_SelecionePathEntrada.Name = "lbl_SelecionePathEntrada";
            this.lbl_SelecionePathEntrada.Size = new System.Drawing.Size(153, 15);
            this.lbl_SelecionePathEntrada.TabIndex = 5;
            this.lbl_SelecionePathEntrada.Text = "Selecione o path de entrada";
            // 
            // btn_MarcarTodos
            // 
            this.btn_MarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MarcarTodos.Location = new System.Drawing.Point(389, 60);
            this.btn_MarcarTodos.Name = "btn_MarcarTodos";
            this.btn_MarcarTodos.Size = new System.Drawing.Size(109, 23);
            this.btn_MarcarTodos.TabIndex = 4;
            this.btn_MarcarTodos.Text = "Marcar Todos";
            this.btn_MarcarTodos.UseVisualStyleBackColor = true;
            this.btn_MarcarTodos.Click += new System.EventHandler(this.btn_MarcarTodos_Click);
            // 
            // btn_DesmarcarTodos
            // 
            this.btn_DesmarcarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DesmarcarTodos.Location = new System.Drawing.Point(504, 60);
            this.btn_DesmarcarTodos.Name = "btn_DesmarcarTodos";
            this.btn_DesmarcarTodos.Size = new System.Drawing.Size(109, 23);
            this.btn_DesmarcarTodos.TabIndex = 3;
            this.btn_DesmarcarTodos.Text = "Desmarcar Todos";
            this.btn_DesmarcarTodos.UseVisualStyleBackColor = true;
            this.btn_DesmarcarTodos.Click += new System.EventHandler(this.btn_DesmarcarTodos_Click);
            // 
            // chkl_Arquivos
            // 
            this.chkl_Arquivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkl_Arquivos.FormattingEnabled = true;
            this.chkl_Arquivos.Location = new System.Drawing.Point(3, 90);
            this.chkl_Arquivos.Name = "chkl_Arquivos";
            this.chkl_Arquivos.Size = new System.Drawing.Size(652, 238);
            this.chkl_Arquivos.TabIndex = 2;
            // 
            // btn_SelecionarPath
            // 
            this.btn_SelecionarPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelecionarPath.Location = new System.Drawing.Point(619, 30);
            this.btn_SelecionarPath.Name = "btn_SelecionarPath";
            this.btn_SelecionarPath.Size = new System.Drawing.Size(36, 23);
            this.btn_SelecionarPath.TabIndex = 1;
            this.btn_SelecionarPath.Text = "...";
            this.btn_SelecionarPath.UseVisualStyleBackColor = true;
            this.btn_SelecionarPath.Click += new System.EventHandler(this.btn_SelecionarPath_Click);
            // 
            // txt_PathEntrada
            // 
            this.txt_PathEntrada.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PathEntrada.Location = new System.Drawing.Point(6, 31);
            this.txt_PathEntrada.Name = "txt_PathEntrada";
            this.txt_PathEntrada.Size = new System.Drawing.Size(607, 23);
            this.txt_PathEntrada.TabIndex = 0;
            this.txt_PathEntrada.TextChanged += new System.EventHandler(this.txt_PathEntrada_TextChanged);
            // 
            // tab_Saida
            // 
            this.tab_Saida.Controls.Add(this.lbl_SelecionePathSaidaLabel);
            this.tab_Saida.Controls.Add(this.btn_SelecionaPathSaida);
            this.tab_Saida.Controls.Add(this.txt_PathSaida);
            this.tab_Saida.Location = new System.Drawing.Point(4, 24);
            this.tab_Saida.Name = "tab_Saida";
            this.tab_Saida.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Saida.Size = new System.Drawing.Size(661, 338);
            this.tab_Saida.TabIndex = 1;
            this.tab_Saida.Text = "Saída";
            this.tab_Saida.UseVisualStyleBackColor = true;
            // 
            // lbl_SelecionePathSaidaLabel
            // 
            this.lbl_SelecionePathSaidaLabel.AutoSize = true;
            this.lbl_SelecionePathSaidaLabel.Location = new System.Drawing.Point(6, 129);
            this.lbl_SelecionePathSaidaLabel.Name = "lbl_SelecionePathSaidaLabel";
            this.lbl_SelecionePathSaidaLabel.Size = new System.Drawing.Size(124, 15);
            this.lbl_SelecionePathSaidaLabel.TabIndex = 2;
            this.lbl_SelecionePathSaidaLabel.Text = "Selecione o path saída";
            // 
            // btn_SelecionaPathSaida
            // 
            this.btn_SelecionaPathSaida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelecionaPathSaida.Location = new System.Drawing.Point(619, 147);
            this.btn_SelecionaPathSaida.Name = "btn_SelecionaPathSaida";
            this.btn_SelecionaPathSaida.Size = new System.Drawing.Size(36, 23);
            this.btn_SelecionaPathSaida.TabIndex = 1;
            this.btn_SelecionaPathSaida.Text = "...";
            this.btn_SelecionaPathSaida.UseVisualStyleBackColor = true;
            this.btn_SelecionaPathSaida.Click += new System.EventHandler(this.btn_SelecionaPathSaida_Click);
            // 
            // txt_PathSaida
            // 
            this.txt_PathSaida.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PathSaida.Location = new System.Drawing.Point(6, 147);
            this.txt_PathSaida.Name = "txt_PathSaida";
            this.txt_PathSaida.Size = new System.Drawing.Size(607, 23);
            this.txt_PathSaida.TabIndex = 0;
            // 
            // tab_Processamento
            // 
            this.tab_Processamento.Controls.Add(this.btn_Processar);
            this.tab_Processamento.Controls.Add(this.dtp_DataProcessamento);
            this.tab_Processamento.Location = new System.Drawing.Point(4, 24);
            this.tab_Processamento.Name = "tab_Processamento";
            this.tab_Processamento.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Processamento.Size = new System.Drawing.Size(661, 338);
            this.tab_Processamento.TabIndex = 2;
            this.tab_Processamento.Text = "Processamento";
            this.tab_Processamento.UseVisualStyleBackColor = true;
            // 
            // btn_Processar
            // 
            this.btn_Processar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Processar.Location = new System.Drawing.Point(525, 260);
            this.btn_Processar.Name = "btn_Processar";
            this.btn_Processar.Size = new System.Drawing.Size(99, 43);
            this.btn_Processar.TabIndex = 1;
            this.btn_Processar.Text = "Processar";
            this.btn_Processar.UseVisualStyleBackColor = true;
            this.btn_Processar.Click += new System.EventHandler(this.btn_Processar_Click);
            // 
            // dtp_DataProcessamento
            // 
            this.dtp_DataProcessamento.Location = new System.Drawing.Point(24, 26);
            this.dtp_DataProcessamento.Name = "dtp_DataProcessamento";
            this.dtp_DataProcessamento.Size = new System.Drawing.Size(264, 23);
            this.dtp_DataProcessamento.TabIndex = 0;
            // 
            // tab_JaProcessados
            // 
            this.tab_JaProcessados.Controls.Add(this.btn_Reverter);
            this.tab_JaProcessados.Controls.Add(this.btn_MarcarTodosProcessados);
            this.tab_JaProcessados.Controls.Add(this.btn_DesmarcarTodosProcessados);
            this.tab_JaProcessados.Controls.Add(this.chkl_ArquivosProcessados);
            this.tab_JaProcessados.Location = new System.Drawing.Point(4, 24);
            this.tab_JaProcessados.Name = "tab_JaProcessados";
            this.tab_JaProcessados.Padding = new System.Windows.Forms.Padding(3);
            this.tab_JaProcessados.Size = new System.Drawing.Size(661, 338);
            this.tab_JaProcessados.TabIndex = 3;
            this.tab_JaProcessados.Text = "Reverter Processamento";
            this.tab_JaProcessados.UseVisualStyleBackColor = true;
            // 
            // btn_Reverter
            // 
            this.btn_Reverter.Location = new System.Drawing.Point(389, 16);
            this.btn_Reverter.Name = "btn_Reverter";
            this.btn_Reverter.Size = new System.Drawing.Size(224, 23);
            this.btn_Reverter.TabIndex = 7;
            this.btn_Reverter.Text = "Reverter processamento";
            this.btn_Reverter.UseVisualStyleBackColor = true;
            this.btn_Reverter.Click += new System.EventHandler(this.btn_Reverter_Click);
            // 
            // btn_MarcarTodosProcessados
            // 
            this.btn_MarcarTodosProcessados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_MarcarTodosProcessados.Location = new System.Drawing.Point(389, 60);
            this.btn_MarcarTodosProcessados.Name = "btn_MarcarTodosProcessados";
            this.btn_MarcarTodosProcessados.Size = new System.Drawing.Size(109, 23);
            this.btn_MarcarTodosProcessados.TabIndex = 6;
            this.btn_MarcarTodosProcessados.Text = "Marcar Todos";
            this.btn_MarcarTodosProcessados.UseVisualStyleBackColor = true;
            this.btn_MarcarTodosProcessados.Click += new System.EventHandler(this.btn_MarcarTodosProcessados_Click);
            // 
            // btn_DesmarcarTodosProcessados
            // 
            this.btn_DesmarcarTodosProcessados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_DesmarcarTodosProcessados.Location = new System.Drawing.Point(504, 60);
            this.btn_DesmarcarTodosProcessados.Name = "btn_DesmarcarTodosProcessados";
            this.btn_DesmarcarTodosProcessados.Size = new System.Drawing.Size(109, 23);
            this.btn_DesmarcarTodosProcessados.TabIndex = 5;
            this.btn_DesmarcarTodosProcessados.Text = "Desmarcar Todos";
            this.btn_DesmarcarTodosProcessados.UseVisualStyleBackColor = true;
            this.btn_DesmarcarTodosProcessados.Click += new System.EventHandler(this.btn_DesmarcarTodosProcessados_Click);
            // 
            // chkl_ArquivosProcessados
            // 
            this.chkl_ArquivosProcessados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkl_ArquivosProcessados.FormattingEnabled = true;
            this.chkl_ArquivosProcessados.Location = new System.Drawing.Point(3, 90);
            this.chkl_ArquivosProcessados.Name = "chkl_ArquivosProcessados";
            this.chkl_ArquivosProcessados.Size = new System.Drawing.Size(652, 238);
            this.chkl_ArquivosProcessados.TabIndex = 3;
            // 
            // btn_Sobre
            // 
            this.btn_Sobre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Sobre.Location = new System.Drawing.Point(23, 384);
            this.btn_Sobre.Name = "btn_Sobre";
            this.btn_Sobre.Size = new System.Drawing.Size(75, 23);
            this.btn_Sobre.TabIndex = 1;
            this.btn_Sobre.Text = "Sobre";
            this.btn_Sobre.UseVisualStyleBackColor = true;
            // 
            // btn_Sair
            // 
            this.btn_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Sair.Location = new System.Drawing.Point(613, 384);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(75, 23);
            this.btn_Sair.TabIndex = 2;
            this.btn_Sair.Text = "Sair";
            this.btn_Sair.UseVisualStyleBackColor = true;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 419);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Sobre);
            this.Controls.Add(this.tbc_Opcoes);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tbc_Opcoes.ResumeLayout(false);
            this.tab_Entrada.ResumeLayout(false);
            this.tab_Entrada.PerformLayout();
            this.tab_Saida.ResumeLayout(false);
            this.tab_Saida.PerformLayout();
            this.tab_Processamento.ResumeLayout(false);
            this.tab_JaProcessados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tbc_Opcoes;
        private TabPage tab_Entrada;
        private TabPage tab_Saida;
        private Button btn_Sobre;
        private Button btn_Sair;
        private TabPage tab_Processamento;
        private Button btn_SelecionarPath;
        private TextBox txt_PathEntrada;
        private FolderBrowserDialog folderBrowserDialogPathEntrada;
        private CheckedListBox chkl_Arquivos;
        private Button btn_MarcarTodos;
        private Button btn_DesmarcarTodos;
        private Button btn_SelecionaPathSaida;
        private TextBox txt_PathSaida;
        private Label lbl_SelecionePathSaidaLabel;
        private DateTimePicker dtp_DataProcessamento;
        private Button btn_Processar;
        private Label lbl_SelecionePathEntrada;
        private TabPage tab_JaProcessados;
        private CheckedListBox chkl_ArquivosProcessados;
        private Button btn_MarcarTodosProcessados;
        private Button btn_DesmarcarTodosProcessados;
        private Button btn_Reverter;
    }
}