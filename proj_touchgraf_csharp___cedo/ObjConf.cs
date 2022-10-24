
//public sealed class ObjConf
public class ObjConf
{

    //private static readonly ObjConf _instance = new ObjConf();

    public string? DataProcessamento { get; set; }
    public string? PathEntrada { get; set; }
    public string? PathSaida { get; set; }

    public string ?Extensao { get; set; }
    public string? Tentar_conectar_Mysql { get; set; }
    public string? Database { get; set; }
    public string? Tabela_Processamento { get; set; }
    public string? Tabela_Controle_arquivos { get; set; }
    public string? Tabela_Controle_lotes { get; set; }
    public string? Uri { get; set; }

    //public static ObjConf getInstance ()
    public ObjConf(){
        
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
