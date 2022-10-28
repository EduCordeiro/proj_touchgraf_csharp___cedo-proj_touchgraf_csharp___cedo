using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace proj_touchgraf_csharp___cedo
{
    public class ObjCore
    {

        public ObjConf oConfig = new ObjConf();

        //========================================
        // Usando o padrão Singleton
        //========================================
        public objMySqlConnect ?oMySqlConnection;
        public objMySqlConnect? oMySqlConnection2;
        //========================================

        private MySqlCommand ?ComandoSQL;
        private MySqlCommand? ComandoSQL2;
        private MySqlDataReader ?readerMySql;
        private MySqlDataReader? readerMySql2;


        public ObjCore()
        {
            
            ComandoSQL = new MySqlCommand();
            ComandoSQL2 = new MySqlCommand();

            string sPathEXE = ajustaPath(System.AppDomain.CurrentDomain.BaseDirectory.ToString());
            //string sPathEXE_Anterior = sPathEXE.Substring(0, sPathEXE.LastIndexOf("\\", sPathEXE.Length - 2)) + "\\" + "Teste";
            string sNameEXE = System.AppDomain.CurrentDomain.FriendlyName.ToString();
            string sNameConfJson = sNameEXE + ".json";
            string sNameScripeySQL = sNameEXE + ".sql";


            //======================================================================
            // Deserializando arquivo .conf para obter os parâmetros.
            //======================================================================
            string TextContet = File.ReadAllText(sPathEXE + sNameConfJson);

            //================================================================================
            // Definindo template de variável para troca padrão
            //================================================================================
            TextContet = TextContet.Replace("@PathLocalApp", sPathEXE)
                                   .Replace(@"\", "/")
                                   .Replace("//", "/")
                                   .Replace("//", "/")
                                   .Replace("@Database", sNameEXE);
            //================================================================================

            var objConfigTMP = JsonSerializer.Deserialize<ObjConf>(TextContet);

            if (objConfigTMP != null)
            {
                oConfig = objConfigTMP;

                //================================================================================
                // Definindo template de variável para troca padrão
                //================================================================================
                //oConfig.PathEntrada = oConfig.PathEntrada.Replace("@PathLocalApp", sPathEXE);
                //oConfig.PathSaida = oConfig.PathSaida.Replace("@PathLocalApp", sPathEXE);
                //================================================================================


                if (oConfig.Tentar_conectar_Mysql == "true")
                {

                    if (oConfig.Uri != null)
                    {
                        try
                        {

                            //oMySqlConnection = objMySqlConnect.getInstance(oConfig.Uri);
                            //oMySqlConnection2 = objMySqlConnect.getInstance(oConfig.Uri);

                            oMySqlConnection = new objMySqlConnect(oConfig.Uri);
                            oMySqlConnection2 = new objMySqlConnect(oConfig.Uri);


                            // Pegando a conexão Singleton
                            if (oMySqlConnection != null)
                            {
                                ComandoSQL.Connection = oMySqlConnection.conn;
                                ComandoSQL2.Connection = oMySqlConnection2.conn;

                                //==========================================================================================
                                //                                  TESTE DE CONEXAO
                                // Observe que enquanto um DataReader estiver aberto,
                                // a Conexão estará em uso exclusivamente por esse DataReader.
                                // Você não pode executar nenhum comando para a Conexão,
                                // incluindo a criação de outro DataReader,
                                // até que o DataReader original seja fechado.                        
                                //==========================================================================================
                                /*
                                ComandoSQL.CommandText = "SELECT * FROM "
                                                       + " produtos "
                                                       + " WHERE id = @id ";

                                ComandoSQL.Parameters.AddWithValue("@id", "1");
                                ComandoSQL.Prepare();

                                using (readerMySql = ComandoSQL.ExecuteReader())
                                {

                                    while (readerMySql.Read())
                                    {
                                        //  MessageBox.Show(readerMySql.GetString(0) + " " + readerMySql.GetString(1));

                                    }
                                }
                                */
                                //==========================================================================================

                                //======================================================================
                                // Carregando ScriptSql
                                //======================================================================
                                string sScriptSQLContet = File.ReadAllText(sPathEXE + sNameScripeySQL);

                                ComandoSQL.CommandText = sScriptSQLContet.Replace("@Database", oConfig.Database)
                                                                         .Replace("@Tabela_Processamento", oConfig.Tabela_Processamento)
                                                                         .Replace("@Tabela_Processamento_history", oConfig.Tabela_Processamento_history)
                                                                         .Replace("@Tabela_Codigos_status", oConfig.Tabela_Codigos_status)
                                                                         .Replace("@Tabela_Codigos_motivos_devolucao", oConfig.Tabela_Codigos_motivos_devolucao)
                                                                         .Replace("@Tabela_Controle_arquivos", oConfig.Tabela_Controle_arquivos)
                                                                         .Replace("@Tabela_Controle_lotes", oConfig.Tabela_Controle_lotes)
                                                                         ;
                                ComandoSQL.ExecuteNonQuery();
                                //======================================================================

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

            }

        }

        public void ProcessarArquivo(string arquivoTXT, string pathSaida)
        {

            

            //====================================
            // Limpando tabela de processamento
            //====================================
            ComandoSQL.CommandText = "DELETE FROM " + oConfig.Tabela_Processamento;
            ComandoSQL.ExecuteNonQuery();

            //====================================
            // Lendo o arquivo
            //====================================
            int counter = 0;

            string sLinha = String.Empty;
            string sLinhaRel = String.Empty;
            string sTIPO_REGISTRO = String.Empty;
            string sTIPO_DOCUMENTO = String.Empty;
            string sDATA_GERACAO_ARQUIVO_CEDO = String.Empty;
            string sHORA_GERACAO_ARQUIVO = String.Empty;
            string sCIF = String.Empty;
            string sCODIGO_MOTIVO_DEVOLUCAO = String.Empty;
            string sCODIGO_STATUS = String.Empty;

            string sSEQUENCIA = String.Empty;

            string sN_CONTRATO = String.Empty;
            string sN_CHASSI = String.Empty;
            string sCPF_CNPJ_CLIENTE = String.Empty;
            string sNOME_CLIENTE = String.Empty;
            string sVALOR_CARNE = String.Empty;
            string sQTD_PARCELAS = String.Empty;
            string sDT_VENCIMENTO = String.Empty;
            string ?sSTATUS = String.Empty;
            string sCODIGO_POSTAGEM_CORREIOS = String.Empty;
            string sENDERECO = String.Empty;
            string sBAIRRO = String.Empty;
            string sCIDADE = String.Empty;
            string sUF = String.Empty;
            string sCEP = String.Empty;
            string sARQUIVO_ORIGEM_BANCO = String.Empty;
            string sDTA_REFERENCIA = String.Empty;
            string sDATA_POSTAGEM = String.Empty;
            string sMOTIVO_DEVOLUCAO = String.Empty;

            string sProdutoCarne = String.Empty;


            //==========================================================================================
            //
            // Read the file line by line.  
            //
            //==========================================================================================
            foreach (string line in System.IO.File.ReadLines(@"" + arquivoTXT + ""))
            {                
                counter++;

                sTIPO_REGISTRO = line.Substring(0, 1).Trim();

                if(sTIPO_REGISTRO == "1")
                {
                    sDATA_GERACAO_ARQUIVO_CEDO = line.Substring(1, 8).Trim();
                    sHORA_GERACAO_ARQUIVO = line.Substring(9, 4).Trim();
                }

                if(sTIPO_REGISTRO == "2")
                {

                    //==========================================================================================
                    //
                    // BUSCANDO O REGISTRO NA TABELA DE RELATÓRIOS DIÁRIOS PARA CRIAR O CEDO
                    //
                    //==========================================================================================
                    sCIF = line.Substring(1, 34).Trim();
                    ComandoSQL.CommandText = " SELECT LINHA, TIPO_DOCUMENTO, MOVIMENTO, STATUS_REGISTRO, DATA_POSTAGEM FROM " + oConfig.Tabela_Relatorio
                                           + " WHERE CIF = '" + sCIF + "'";
                    /*
                    ComandoSQL.Parameters.Clear();
                    ComandoSQL.Parameters.AddWithValue("@id", "1");
                    */

                    ComandoSQL.Prepare();

                    using (readerMySql = ComandoSQL.ExecuteReader())
                    {
                        while (readerMySql.Read())
                        {

                            //==========================================================================================
                            //
                            // BUSCANDO O ERRO NA TABELA DE CÓDIGOS DE ERRO CEDO
                            //
                            //==========================================================================================                            
                            sCODIGO_MOTIVO_DEVOLUCAO = line.Substring(35, 2).Trim();
                            ComandoSQL2.CommandText = " SELECT DESCRICAO FROM " + oConfig.Tabela_Codigos_motivos_devolucao
                                                   + " WHERE CODIGO = '" + sCODIGO_MOTIVO_DEVOLUCAO + "' "
                                                   + " LIMIT 1";
                            ComandoSQL2.Prepare();                            
                            using (readerMySql2 = ComandoSQL2.ExecuteReader())
                            {
                                while (readerMySql2.Read())
                                    sMOTIVO_DEVOLUCAO = readerMySql2.GetString(0);
                            }
                            //==========================================================================================

                            //==========================================================================================
                            //
                            // BUSCANDO O STATUS NA TABELA DE STATUS
                            //
                            //==========================================================================================                            
                            sCODIGO_STATUS = readerMySql.GetString(3);
                            ComandoSQL2.CommandText = " SELECT DESCRICAO FROM " + oConfig.Tabela_Codigos_status
                                                   + " WHERE CODIGO = '" + sCODIGO_MOTIVO_DEVOLUCAO + "' "
                                                   + " LIMIT 1";
                            ComandoSQL2.Prepare();
                            using (readerMySql2 = ComandoSQL2.ExecuteReader())
                            {
                                while (readerMySql2.Read())
                                    sSTATUS = readerMySql2.GetString(0);
                            }
                            //==========================================================================================
                            

                            sTIPO_DOCUMENTO = readerMySql.GetString(1);                            

                            if (sTIPO_DOCUMENTO == "CARNE") {

                                sLinha = readerMySql.GetString(0);

                                sProdutoCarne = sLinha.Substring(23, 3).Trim();

                                if (oConfig.ProdutoCarneEspecifico == sProdutoCarne)
                                    sSTATUS = oConfig.ProdutoCarneEspecificoLabel;

                                sN_CONTRATO = sLinha.Substring(0019, 16).Trim();
                                sN_CHASSI = sLinha.Substring(2167, 20).Trim();
                                sCPF_CNPJ_CLIENTE = sLinha.Substring(0593, 14).Trim();
                                sNOME_CLIENTE = sLinha.Substring(0100, 30).Trim();
                                sVALOR_CARNE = sLinha.Substring(1813, 15).Trim();
                                sQTD_PARCELAS = sLinha.Substring(0499, 3).Trim();
                                sDT_VENCIMENTO = sLinha.Substring(0046, 8).Trim();
                                sCODIGO_POSTAGEM_CORREIOS = sLinha.Substring(1898, 34).Trim();
                                sENDERECO = sLinha.Substring(0712, 60).Trim();
                                sBAIRRO = sLinha.Substring(0807, 30).Trim();
                                sCIDADE = sLinha.Substring(0837, 30).Trim();
                                sUF = sLinha.Substring(0867, 2).Trim();
                                sCEP = sLinha.Substring(0869, 8).Trim();
                                sARQUIVO_ORIGEM_BANCO = sLinha.Substring(2033, 13).Trim();
                                sDTA_REFERENCIA = readerMySql.GetString(2);

                                sDATA_POSTAGEM = readerMySql.GetString(4);

                                //==========================================================================================
                                //
                                // LINHA RELATÓRIO
                                //
                                //==========================================================================================
                                sLinhaRel = sN_CONTRATO
                                    + ";" + sN_CHASSI
                                    + ";" + sCPF_CNPJ_CLIENTE
                                    + ";" + sNOME_CLIENTE
                                    + ";" + sVALOR_CARNE
                                    + ";" + sQTD_PARCELAS
                                    + ";" + sDT_VENCIMENTO
                                    + ";" + sSTATUS
                                    + ";" + sCODIGO_POSTAGEM_CORREIOS
                                    + ";" + sENDERECO
                                    + ";" + sBAIRRO
                                    + ";" + sCIDADE
                                    + ";" + sUF
                                    + ";" + sCEP
                                    + ";" + sARQUIVO_ORIGEM_BANCO
                                    + ";" + sDTA_REFERENCIA
                                    + ";" + sDATA_POSTAGEM
                                    + ";" + sMOTIVO_DEVOLUCAO
                                   ;

                                //==========================================================================================
                                //
                                // INSERINDO NA TABELA PROCESSAMENTO
                                //
                                //==========================================================================================
                                ComandoSQL2.CommandText = "INSERT INTO " + oConfig.Tabela_Processamento
                                                   + " ("
                                                   + "  DATA_GERACAO_ARQUIVO_CEDO "
                                                   + ", HORA_GERACAO_ARQUIVO"
                                                   + ", CIF"
                                                   + ", CODIGO_MOTIVO_DEVOLUCAO"
                                                   + ", MOTIVO_DEVOLUCAO"
                                                   + ", N_CONTRATO"
                                                   + ", N_CHASSI"
                                                   + ", CPF_CNPJ_CLIENTE"
                                                   + ", NOME_CLIENTE"
                                                   + ", VALOR_CARNE"
                                                   + ", QTD_PARCELAS"
                                                   + ", DT_VENCIMENTO "
                                                   + ", STATUS "
                                                   + ", CODIGO_POSTAGEM_CORREIOS "
                                                   + ", ENDERECO "
                                                   + ", BAIRRO "
                                                   + ", CIDADE "
                                                   + ", UF "
                                                   + ", CEP "
                                                   + ", ARQUIVO_ORIGEM_BANCO "
                                                   + ", DTA_REFERENCIA "
                                                   + ", DTA_POSTAGEM"
                                                   + ", LINHA_REL_NEW"
                                                   + ") "
                                                   + "VALUES("
                                                   + "'"  + sDATA_GERACAO_ARQUIVO_CEDO + "'"
                                                   + ",'" + sHORA_GERACAO_ARQUIVO + "'"
                                                   + ",'" + sCIF + "'"
                                                   + ",'" + sCODIGO_MOTIVO_DEVOLUCAO + "'"
                                                   + ",'" + sMOTIVO_DEVOLUCAO + "'"
                                                   + ",'" + sN_CONTRATO + "'"
                                                   + ",'" + sN_CHASSI + "'"
                                                   + ",'" + sCPF_CNPJ_CLIENTE + "'"
                                                   + ",'" + sNOME_CLIENTE + "'"
                                                   + ",'" + sVALOR_CARNE + "'"
                                                   + ",'" + sQTD_PARCELAS + "'"
                                                   + ",'" + sDT_VENCIMENTO + "'"
                                                   + ",'" + sSTATUS + "'"
                                                   + ",'" + sCODIGO_POSTAGEM_CORREIOS + "'"
                                                   + ",'" + sENDERECO + "'"
                                                   + ",'" + sBAIRRO + "'"
                                                   + ",'" + sCIDADE + "'"
                                                   + ",'" + sUF + "'"
                                                   + ",'" + sCEP + "'"
                                                   + ",'" + sARQUIVO_ORIGEM_BANCO + "'"
                                                   + ",'" + sDTA_REFERENCIA + "'"
                                                   + ",'" + sDATA_POSTAGEM + "'"
                                                   + ",'" + sLinhaRel + "'"
                                                   + ")";
                                ComandoSQL2.ExecuteNonQuery();
                                //==========================================================================================



                                //==========================================================================================
                                //
                                // INSERINDO NA TABELA PROCESSAMENTO HISTORY
                                //
                                //==========================================================================================
                                ComandoSQL2.CommandText = "INSERT INTO " + oConfig.Tabela_Processamento_history
                                                   + " ("
                                                   + "  DATA_PROCESSAMENTO "
                                                   + ", DATA_GERACAO_ARQUIVO_CEDO "
                                                   + ", HORA_GERACAO_ARQUIVO"
                                                   + ", CIF"
                                                   + ", CODIGO_MOTIVO_DEVOLUCAO"
                                                   + ", MOTIVO_DEVOLUCAO"
                                                   + ", N_CONTRATO"
                                                   + ", N_CHASSI"
                                                   + ", CPF_CNPJ_CLIENTE"
                                                   + ", NOME_CLIENTE"
                                                   + ", VALOR_CARNE"
                                                   + ", QTD_PARCELAS"
                                                   + ", DT_VENCIMENTO "
                                                   + ", STATUS "
                                                   + ", CODIGO_POSTAGEM_CORREIOS "
                                                   + ", ENDERECO "
                                                   + ", BAIRRO "
                                                   + ", CIDADE "
                                                   + ", UF "
                                                   + ", CEP "
                                                   + ", ARQUIVO_ORIGEM_BANCO "
                                                   + ", DTA_REFERENCIA "
                                                   + ", DTA_POSTAGEM"
                                                   + ", LINHA_ORIGEM"
                                                   + ", LINHA_REL_NEW"
                                                   + ") "
                                                   + "VALUES("
                                                   + " '" + oConfig.DataProcessamento_YYYYMMDD + "'"
                                                   + ",'" + sDATA_GERACAO_ARQUIVO_CEDO + "'"
                                                   + ",'" + sHORA_GERACAO_ARQUIVO + "'"
                                                   + ",'" + sCIF + "'"
                                                   + ",'" + sCODIGO_MOTIVO_DEVOLUCAO + "'"
                                                   + ",'" + sMOTIVO_DEVOLUCAO + "'"
                                                   + ",'" + sN_CONTRATO + "'"
                                                   + ",'" + sN_CHASSI + "'"
                                                   + ",'" + sCPF_CNPJ_CLIENTE + "'"
                                                   + ",'" + sNOME_CLIENTE + "'"
                                                   + ",'" + sVALOR_CARNE + "'"
                                                   + ",'" + sQTD_PARCELAS + "'"
                                                   + ",'" + sDT_VENCIMENTO + "'"
                                                   + ",'" + sSTATUS + "'"
                                                   + ",'" + sCODIGO_POSTAGEM_CORREIOS + "'"
                                                   + ",'" + sENDERECO + "'"
                                                   + ",'" + sBAIRRO + "'"
                                                   + ",'" + sCIDADE + "'"
                                                   + ",'" + sUF + "'"
                                                   + ",'" + sCEP + "'"
                                                   + ",'" + sARQUIVO_ORIGEM_BANCO + "'"
                                                   + ",'" + sDTA_REFERENCIA + "'"
                                                   + ",'" + sDATA_POSTAGEM + "'"
                                                   + ",'" + sLinha + "'"
                                                   + ",'" + sLinhaRel + "'"
                                                   + ")";
                                ComandoSQL2.ExecuteNonQuery();
                                //==========================================================================================




                            }

                        }
                    }


                }



            }

            /*
            //==========================================================================================
            //
            // INSERINDO NA TABELA DE CONTROLE DE ARQUIVOS
            //
            //==========================================================================================
            ComandoSQL.CommandText = "INSERT INTO "
                                + oConfig.Tabela_Processamento
                                + " (FIELD_01, FIELD_02, FIELD_03, FIELD_04, FIELD_05, FIELD_06, FIELD_07, FIELD_08, FIELD_09, FIELD_10, FIELD_11, ARQUIVO_AFP) "
                                + "VALUES("
                                   //+ "'" + sField_01 + "'"
                                   //+ ",'" + sField_02 + "'"

                                   + ")";
            ComandoSQL.ExecuteNonQuery();
            //==========================================================================================
            */

        }

        public void GravaArquivo(string NomeArquivoTXT, string pathSaida)
        {
            //==========================================================================================
            //
            // GRAVANDO OS DADOS NO BANCO APÓS CARGA
            //
            //==========================================================================================
            ComandoSQL.CommandText = "SELECT LINHA_REL_NEW FROM " + oConfig.Tabela_Processamento;
            //+ " WHERE id = @id ";
            /*
            ComandoSQL.Parameters.Clear();
            ComandoSQL.Parameters.AddWithValue("@id", "1");
            */

            ComandoSQL.Prepare();

            using (readerMySql = ComandoSQL.ExecuteReader())
            {

                string sNomeArquivoSaida = NomeArquivoTXT;

                // Cria o diretório caso não exista
                if (!Directory.Exists(pathSaida))
                    Directory.CreateDirectory(pathSaida);

                if (File.Exists(pathSaida + sNomeArquivoSaida))
                    File.Delete(pathSaida + sNomeArquivoSaida);// File.Delete(Path.GetDirectoryName(Arquivo) + "//Registros.csv");

                // Objeto que determina o modo do arquivo
                FileMode fileMd = FileMode.OpenOrCreate;
                FileStream streamProc = new FileStream(pathSaida + sNomeArquivoSaida, fileMd);
                //Observe que estamos usando a cláusula using de forma a liberar os recursos usados na operação após sua utilização. 
                // Nunca esqueça de liberar os recursos usados e também verifique sempre se o arquivo existe quando necessário.
                using (StreamWriter swProc = new StreamWriter(streamProc))
                {

                    

                    string sLinha = "N_CONTRATO"
                                  + ";N_CHASSI"
                                  + ";CPF/CNPJ CLIENTE"
                                  + ";NOME CLIENTE"
                                  + ";VALOR CARNE"
                                  + ";QTD PARCELAS"
                                  + ";DT VENCIMENTO"
                                  + ";STATUS"
                                  + ";CODIGO POSTAGEM CORREIOS"
                                  + ";ENDEREÇO"
                                  + ";BAIRRO"
                                  + ";CIDADE"
                                  + ";UF"
                                  + ";CEP"
                                  + ";ARQUIVO"
                                  + ";DTA_REFERENCIA"
                                  + ";DATA CIF"
                                  + ";MOTIVO"
                                  ;
                    swProc.WriteLine(sLinha);

                    while (readerMySql.Read())
                    {

                        sLinha = readerMySql.GetString(0);

                        swProc.WriteLine(sLinha);

                    }


                }

            }
            //==========================================================================================
        }

        public string ajustaPath(string ?path)
        {
            string result = "";

            result = path.Replace("\\\\", @"\");
            result = path.Replace("/", @"\");


            if (path.Substring(path.Length - 1, 1) != @"\")
            {
                result = result + "\\";
            }

            return result;
        }

        public string ExecutarCMD(string comando, string parametros)
        {

            using (Process processo = new Process())
            {
                processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");

                // Formata a string para passar como argumento para o cmd.exe
                processo.StartInfo.Arguments = string.Format("/c {0}", comando + " " + parametros);

                processo.StartInfo.RedirectStandardOutput = true;
                processo.StartInfo.UseShellExecute = false;
                processo.StartInfo.CreateNoWindow = true;

                processo.Start();
                // processo.WaitForExit();7

                //  MessageBox.Show("  OK process \r\n", "  ", MessageBoxButtons.OK);

                string saida = processo.StandardOutput.ReadToEnd();
                return saida;
            }
        }

        public void OpenAndSelectPath(string path)
        {
            bool isfile = System.IO.File.Exists(path);
            if (isfile)
            {
                string argument = @"/select, " + path;
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
            else
            {
                bool isfolder = System.IO.Directory.Exists(path);
                if (isfolder)
                {
                    string argument = @"/select, " + path;
                    System.Diagnostics.Process.Start("explorer.exe", argument);
                }
            }
        }

    }
}
