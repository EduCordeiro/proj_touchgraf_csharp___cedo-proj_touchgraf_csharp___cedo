using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace proj_touchgraf_csharp___cedo
{
    public class ObjCore
    {

        public ObjConf oConfig = new ObjConf();

        //========================================
        // Usando o padrão Singleton
        //========================================
        public objMySqlConnect ?oMySqlConnection;
        //========================================

        private MySqlCommand ?ComandoSQL;
        private MySqlDataReader ?readerMySql;
        

        public ObjCore()
        {
            
            ComandoSQL = new MySqlCommand();            

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

                            oMySqlConnection = objMySqlConnect.getInstance(oConfig.Uri);



                            // Pegando a conexão Singleton
                            if (oMySqlConnection != null)
                            {
                                ComandoSQL.Connection = oMySqlConnection.conn;

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
            string sField_01 = "";
            string sField_02 = "";
            string sField_03 = "";
            string sField_04 = "";
            string sField_05 = "";
            string sField_06 = "";
            string sField_07 = "";
            string sField_08 = "";
            string sField_09 = "";
            string sField_10 = "";
            string sField_11 = "";
            string sArquivoAFP = "";


            //==========================================================================================
            //
            // Read the file line by line.  
            //
            //==========================================================================================
            foreach (string line in System.IO.File.ReadLines(@"" + arquivoTXT + ""))
            {                
                counter++;

                sField_01 = line.Substring(0, 9).Trim();
                sField_02 = line.Substring(16, 9).Trim();
                sField_03 = line.Substring(25, 9).Trim();
                sField_04 = line.Substring(34, 10).Trim();
                sField_05 = line.Substring(44, 15).Trim();
                sField_06 = line.Substring(61, 21).Trim();
                sField_07 = line.Substring(81, 11).Trim();
                sField_08 = line.Substring(92, 18).Trim();
                sField_09 = line.Substring(110, 5).Trim();
                sField_10 = line.Substring(115, 39).Trim();
                sField_11 = line.Substring(154, 1).Trim();
                sArquivoAFP = line.Substring(897, 50).Trim();

                //==========================================================================================
                //
                // INSERE O REGISTRO NO BANCO
                //
                //==========================================================================================
                ComandoSQL.CommandText = "INSERT INTO "
                                       + oConfig.Tabela_Processamento
                                       + " (FIELD_01, FIELD_02, FIELD_03, FIELD_04, FIELD_05, FIELD_06, FIELD_07, FIELD_08, FIELD_09, FIELD_10, FIELD_11, ARQUIVO_AFP) "
                                       + "VALUES("
                                       +  "'" + sField_01 + "'"
                                       + ",'" + sField_02 + "'"
                                       + ",'" + sField_03 + "'"
                                       + ",'" + sField_04 + "'"
                                       + ",'" + sField_05 + "'"
                                       + ",'" + sField_06 + "'"
                                       + ",'" + sField_07 + "'"
                                       + ",'" + sField_08 + "'"
                                       + ",'" + sField_09 + "'"
                                       + ",'" + sField_10 + "'"
                                       + ",'" + sField_11 + "'"
                                       + ",'" + sArquivoAFP + "'"
                                       + ")";
                ComandoSQL.ExecuteNonQuery();
                //==========================================================================================


            }



        }

        public void GravaArquivo(string NomeArquivoTXT, string pathSaida)
        {
            //==========================================================================================
            //
            // GRAVANDO OS DADOS NO BANCO APÓS CARGA
            //
            //==========================================================================================
            ComandoSQL.CommandText = "SELECT FIELD_01"
                                        + ", FIELD_02"
                                        + ", FIELD_03"
                                        + ", FIELD_04"
                                        + ", FIELD_05"
                                        + ", FIELD_06"
                                        + ", FIELD_07"
                                        + ", FIELD_08"
                                        + ", FIELD_09"
                                        + ", FIELD_10"
                                        + ", FIELD_11"
                                        + ", ARQUIVO_AFP"
                                   + " FROM "
                                   + oConfig.Tabela_Processamento;
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

                    string sLinha = "";
                    string sFIELD_01 = "";
                    string sFIELD_02 = "";
                    string sFIELD_03 = "";
                    string sFIELD_04 = "";
                    string sFIELD_05 = "";
                    string sFIELD_06 = "";
                    string sFIELD_07 = "";
                    string sFIELD_08 = "";
                    string sFIELD_09 = "";
                    string sFIELD_10 = "";
                    string sFIELD_11 = "";
                    string sARQUIVO_AFP = "";


                    while (readerMySql.Read())
                    {

                        sFIELD_01       = readerMySql.GetString(0);
                        sFIELD_02       = readerMySql.GetString(1);
                        sFIELD_03       = readerMySql.GetString(2);
                        sFIELD_04       = readerMySql.GetString(3);
                        sFIELD_05       = readerMySql.GetString(4);
                        sFIELD_06       = readerMySql.GetString(5);
                        sFIELD_07       = readerMySql.GetString(6);
                        sFIELD_08       = readerMySql.GetString(7);
                        sFIELD_09       = readerMySql.GetString(8);
                        sFIELD_10       = readerMySql.GetString(9);
                        sFIELD_11       = readerMySql.GetString(10);
                        sARQUIVO_AFP    = readerMySql.GetString(11);


                        sLinha = sFIELD_01.Trim()
                               + sFIELD_02.Trim()
                               + sFIELD_03.Trim()
                               + sFIELD_04.Trim()
                               + sFIELD_05.Trim()
                               + sFIELD_06.Trim()
                               + sFIELD_07.Trim()
                               + sFIELD_08.Trim()
                               + sFIELD_09.Trim()
                               + sFIELD_10.Trim()
                               + sFIELD_11.Trim().PadRight(10)
                               + sARQUIVO_AFP.Trim();

                        swProc.WriteLine(sLinha);

                    }


                }

            }
            //==========================================================================================
        }

        public string ajustaPath(string path)
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
