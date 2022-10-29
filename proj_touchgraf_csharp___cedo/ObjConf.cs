
//public sealed class ObjConf
public class ObjConf
{

    //private static readonly ObjConf _instance = new ObjConf();

    public string? DataProcessamento { get; set; }
    public string? DataProcessamento_YYYYMMDD { get; set; }
    public string? PathEntrada { get; set; }
    public string? PathSaida { get; set; }

    public string ?Extensao { get; set; }
    public string? Tentar_conectar_Mysql { get; set; }
    public string? Database { get; set; }
    public string? Tabela_Processamento { get; set; }
    public string? Tabela_Processamento_history { get; set; }
    public string? Tabela_Codigos_status { get; set; }
    public string? Tabela_Codigos_motivos_devolucao { get; set; }
    public string? Tabela_Controle_arquivos { get; set; }
    public string? Tabela_Controle_lotes { get; set; }

    public string? Tabela_Relatorio { get; set; }
    public string? Uri { get; set; }
    public string? ProdutoCarneEspecifico { get; set; }
    public string? ProdutoCarneEspecificoLabel { get; set; }

    public List<string> lstArquivosJaProcessados { get; set; } 

    //public static ObjConf getInstance ()
    public ObjConf(){
        DataProcessamento = String.Empty;
        PathEntrada = String.Empty;

        lstArquivosJaProcessados = new List<string>();

    }
    
    /*
    public static ObjConf getInstance
    {
        get{
            return _instance; 
        }

    }
    */
    
    


}
