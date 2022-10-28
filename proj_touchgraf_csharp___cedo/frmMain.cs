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
        }

        private void MarcarTodos(bool CheckThem)
        {
            for (int i = 0; i <= (chkl_Arquivos.Items.Count - 1); i++)
            {
                if (CheckThem)
                {
                    chkl_Arquivos.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    chkl_Arquivos.SetItemCheckState(i, CheckState.Unchecked);
                }
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

        private void btn_DesmarcarTodos_Click(object sender, EventArgs e)
        {
            MarcarTodos(false);
        }

        private void btn_MarcarTodos_Click(object sender, EventArgs e)
        {
            MarcarTodos(true);
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
            try
            {
                chkl_Arquivos.Items.Clear();
                DirectoryInfo diretorio = new DirectoryInfo(txt_PathEntrada.Text);
                //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)

                if (oCore.oConfig.Extensao != null)
                {

                    FileInfo[] Arquivos = diretorio.GetFiles(oCore.oConfig.Extensao);

                    //Começamos a listar os arquivos                
                    foreach (FileInfo fileinfo in Arquivos)
                    {
                        chkl_Arquivos.Items.Add(fileinfo.Name);
                    }
                }
            }
            catch
            {

            }

        }

        private void btn_Processar_Click(object sender, EventArgs e)
        {

            frm_Processa();

        }

        private void frm_Processa()
        {

            //======================================================================================================================================================
            // PREPARA OS PARÂMETROS SELECIONADOS
            //======================================================================================================================================================
            DataProcessamento = this.dtp_DataProcessamento.Value.Date;
            oCore.oConfig.DataProcessamento = string.Format("{0:dd/MM/yyyy}", DataProcessamento);
            oCore.oConfig.DataProcessamento_YYYYMMDD = string.Format("{0:yyyyMMdd}", DataProcessamento);

            oCore.oConfig.PathEntrada = oCore.ajustaPath(txt_PathEntrada.Text);
            oCore.oConfig.PathSaida = oCore.ajustaPath(txt_PathSaida.Text);

            //======================================================================================================================================================
            // LÊ ARQUIVO POR ARQUIVO SELECIONADO
            //======================================================================================================================================================
            string sArquivoProcessar = String.Empty;
            for (int iContArquivo = 0; iContArquivo <= chkl_Arquivos.CheckedItems.Count - 1; iContArquivo++)
            {
                sArquivoProcessar = chkl_Arquivos.CheckedItems[iContArquivo].ToString();

                oCore.ProcessarArquivo(oCore.oConfig.PathEntrada + sArquivoProcessar, oCore.oConfig.PathSaida);

                oCore.GravaArquivo(sArquivoProcessar, oCore.oConfig.PathSaida);

            }
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

        }


    }
}