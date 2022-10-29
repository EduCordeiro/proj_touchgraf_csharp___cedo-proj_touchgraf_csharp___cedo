namespace proj_touchgraf_csharp___cedo
{
    public partial class frmMain : Form
    {
        ObjCore oCore = new ObjCore();

        private static DateTime DataProcessamento;
        public frmMain()
        {
            InitializeComponent();

            chkl_Arquivos.Items.Clear();

            txt_PathEntrada.Text = oCore.ajustaPath(oCore.oConfig.PathEntrada);
            txt_PathSaida.Text = oCore.ajustaPath(oCore.oConfig.PathSaida);

            CarregaArquivosJaProcessados();

            tbc_Opcoes.SelectedIndex = 0;

        }

        private void CarregaArquivosJaProcessados()
        {
            oCore.startListaArquivoJaProcessados();
            chkl_ArquivosProcessados.Items.Clear();

            foreach (string arquivoProcessado in oCore.oConfig.lstArquivosJaProcessados)
                chkl_ArquivosProcessados.Items.Add(arquivoProcessado);
        }

        private void MarcarTodos(bool CheckThem, CheckedListBox chkl)
        {
            for (int i = 0; i <= (chkl.Items.Count - 1); i++)
            {
                if (CheckThem)
                {
                    chkl.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    chkl.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        private void CarregaArquivosProcessar()
        {

            try
            {
                CarregaArquivosJaProcessados();

                chkl_Arquivos.Items.Clear();
                DirectoryInfo diretorio = new DirectoryInfo(txt_PathEntrada.Text);
                //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)

                if (oCore.oConfig.Extensao != null)
                {
                    string sArquivo = string.Empty;
                    FileInfo[] Arquivos = diretorio.GetFiles(oCore.oConfig.Extensao);

                    //Começamos a listar os arquivos                
                    foreach (FileInfo fileinfo in Arquivos)
                    {
                        sArquivo = fileinfo.Name;
                        if (!oCore.ArquivoJaProcessados(sArquivo))
                            chkl_Arquivos.Items.Add(fileinfo.Name);
                    }
                }
            }
            catch
            {

            }

        }

        private void btn_SelecionarPath_Click(object sender, EventArgs e)
        {

            folderBrowserDialogPathEntrada.SelectedPath = txt_PathEntrada.Text;

            if (folderBrowserDialogPathEntrada.ShowDialog() == DialogResult.OK)
            {
                txt_PathEntrada.Text = oCore.ajustaPath(folderBrowserDialogPathEntrada.SelectedPath);
            }
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_MarcarTodos_Click(object sender, EventArgs e)
        {
            MarcarTodos(true, chkl_Arquivos);
        }

        private void btn_DesmarcarTodos_Click(object sender, EventArgs e)
        {
            MarcarTodos(false, chkl_Arquivos);
        }

        private void btn_MarcarTodosProcessados_Click(object sender, EventArgs e)
        {
            MarcarTodos(true, chkl_ArquivosProcessados);
        }

        private void btn_DesmarcarTodosProcessados_Click(object sender, EventArgs e)
        {
            MarcarTodos(false, chkl_ArquivosProcessados);
        }



        private void btn_SelecionaPathSaida_Click(object sender, EventArgs e)
        {

            folderBrowserDialogPathEntrada.SelectedPath = txt_PathSaida.Text;

            if (folderBrowserDialogPathEntrada.ShowDialog() == DialogResult.OK)
            {
                txt_PathSaida.Text = oCore.ajustaPath(folderBrowserDialogPathEntrada.SelectedPath);
            }
        }

        private void txt_PathEntrada_TextChanged(object sender, EventArgs e)
        {

            CarregaArquivosProcessar();

        }



        private void btn_Processar_Click(object sender, EventArgs e)
        {

            frm_Processa();
            tbc_Opcoes.SelectedIndex = 0;

        }

        private void frm_Processa()
        {

            //======================================================================================================================================================
            // PREPARA OS PARÂMETROS SELECIONADOS
            //======================================================================================================================================================
            DataProcessamento = this.dtp_DataProcessamento.Value;
            oCore.oConfig.DataProcessamento = string.Format("{0:dd/MM/yyyy}", DataProcessamento);
            oCore.oConfig.DataProcessamento_YYYYMMDD = string.Format("{0:yyyyMMdd}", DataProcessamento);

            oCore.oConfig.PathEntrada = oCore.ajustaPath(txt_PathEntrada.Text);
            oCore.oConfig.PathSaida = oCore.ajustaPath(txt_PathSaida.Text);

            //======================================================================================================================================================
            // LÊ ARQUIVO POR ARQUIVO SELECIONADO
            //======================================================================================================================================================

            oCore.LimparTabelaProcessamento();

            string ?sArquivoProcessar = String.Empty;
            for (int iContArquivo = 0; iContArquivo <= chkl_Arquivos.CheckedItems.Count - 1; iContArquivo++)
            {
                if (chkl_Arquivos.CheckedItems[iContArquivo] != null)
                {
                    sArquivoProcessar = chkl_Arquivos.CheckedItems[iContArquivo].ToString();
                    oCore.ProcessarArquivo(oCore.oConfig.PathEntrada + sArquivoProcessar, oCore.oConfig.PathSaida, false);
                }                
            }

            //============================================
            // GRAVANDO A SAÍDA DO ARQUIVO
            //============================================
            string NomeArquivoSaida = "RELATPRIO_CEDO_" + string.Format("{0:yyyyMMdd H:mm:ss zzz}", DataProcessamento) + ".CSV";
            NomeArquivoSaida=  NomeArquivoSaida.Replace(":", "")
                                               .Replace("-", "")
                                               .Replace(" ", "");


            oCore.GravaArquivo(NomeArquivoSaida, oCore.oConfig.PathSaida);
            //======================================================================================================================================================


            //======================================================================================================================================================
            // FIM DE PROCESSAMENTO, PERGUNTA SE QUER ABRIR O DIRETÓRIO ONDE O ARQUIVO FOI CRIADO
            //======================================================================================================================================================
            DialogResult dialogResult = MessageBox.Show("Fim de processamento !!! \nDeseja abrir a pasta de saída?", "Processamento", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                oCore.OpenAndSelectPath(oCore.oConfig.PathSaida + sArquivoProcessar);
            }
            //======================================================================================================================================================

            
            CarregaArquivosProcessar();

        }

        private void btn_Reverter_Click(object sender, EventArgs e)
        {
            reverterprocessamento();
            CarregaArquivosProcessar();
            tbc_Opcoes.SelectedIndex = 0;
        }

        private void reverterprocessamento()
        {

            DialogResult dialogResult = MessageBox.Show("Atenção !!! \nDeseja mesmo reverter os arquivos selecionados?", "reversão", MessageBoxButtons.YesNo);            

            if (dialogResult == DialogResult.Yes)
            {
                //======================================================================================================================================================
                // LÊ ARQUIVO POR ARQUIVO SELECIONADO - JÁ PROCESSADOS
                //======================================================================================================================================================
                string? sArquivojAProcessados = string.Empty;
                for (int iContArquivo = 0; iContArquivo <= chkl_ArquivosProcessados.CheckedItems.Count - 1; iContArquivo++)
                {
                    sArquivojAProcessados = chkl_ArquivosProcessados.CheckedItems[iContArquivo].ToString();

                    if (sArquivojAProcessados != null)
                        oCore.reverterArquivoJaProceessado(sArquivojAProcessados);

                }
                //======================================================================================================================================================

            }

        }
    }
}