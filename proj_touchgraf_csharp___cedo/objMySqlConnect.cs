using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;

namespace proj_touchgraf_csharp___cedo
{
    public sealed class objMySqlConnect
    {
        private static objMySqlConnect ?_instance; // = new objMySqlConnect();
        public int iTotalDeInstancias { get; set; }
        public MySqlConnection ?conn;
        //private String ?Uri { get; set; }


        private objMySqlConnect(String uri)
        {

            try
            {

                conn = new MySqlConnection();
                conn.ConnectionString = uri;
                conn.Open();
            }
            catch (MySqlException ex)
            {
                //===========================================================================
                // Quero ignorar esso lower_case_table_names para versões antigas do MySql
                //===========================================================================
                if (ex.Number != 1193)
                {
                    MessageBox.Show("Error " + ex.Number + " Erro ocorrido: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static objMySqlConnect getInstance(String uri)
        {

            if (_instance == null)
            {
                _instance = new objMySqlConnect(uri);
            }

            return _instance;
        }


    }
}
