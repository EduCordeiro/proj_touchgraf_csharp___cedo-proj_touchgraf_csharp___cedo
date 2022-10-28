CREATE DATABASE IF NOT EXISTS @Database;

USE @Database;

DROP TABLE IF EXISTS @Tabela_Processamento;
CREATE TABLE IF NOT EXISTS @Tabela_Processamento (
   DATA_GERACAO_ARQUIVO_CEDO    varchar(008) default NULL
  ,HORA_GERACAO_ARQUIVO         varchar(004) default NULL
  ,CIF                          varchar(034) default NULL
  ,CODIGO_MOTIVO_DEVOLUCAO      varchar(002) default NULL
  ,MOTIVO_DEVOLUCAO             varchar(050) default NULL
  ,SEQUENCIA                    int          NOT NULL auto_increment
  ,N_CONTRATO                   varchar(016) default NULL
  ,N_CHASSI                     varchar(020) default NULL
  ,CPF_CNPJ_CLIENTE             varchar(014) default NULL
  ,NOME_CLIENTE                 varchar(030) default NULL
  ,VALOR_CARNE                  varchar(015) default NULL
  ,QTD_PARCELAS                 varchar(003) default NULL
  ,DT_VENCIMENTO                varchar(008) default NULL
  ,STATUS                       varchar(020) default NULL
  ,CODIGO_POSTAGEM_CORREIOS     varchar(034) default NULL
  ,ENDERECO                     varchar(060) default NULL
  ,BAIRRO                       varchar(030) default NULL
  ,CIDADE                       varchar(030) default NULL
  ,UF                           varchar(002) default NULL
  ,CEP                          varchar(008) default NULL
  ,ARQUIVO_ORIGEM_BANCO         varchar(013) default NULL
  ,DTA_REFERENCIA               varchar(008) default NULL
  ,DTA_POSTAGEM                 varchar(008) default NULL
  ,LINHA_REL_NEW                TEXT
  ,PRIMARY KEY  (SEQUENCIA)
);

CREATE TABLE IF NOT EXISTS @Tabela_Processamento_history (
   DATA_PROCESSAMENTO           varchar(008) default NULL
  ,DATA_GERACAO_ARQUIVO_CEDO    varchar(008) default NULL
  ,HORA_GERACAO_ARQUIVO         varchar(004) default NULL
  ,CIF                          varchar(034) default NULL
  ,CODIGO_MOTIVO_DEVOLUCAO      varchar(002) default NULL
  ,MOTIVO_DEVOLUCAO             varchar(050) default NULL
  ,SEQUENCIA                    int          NOT NULL auto_increment
  ,N_CONTRATO                   varchar(016) default NULL
  ,N_CHASSI                     varchar(020) default NULL
  ,CPF_CNPJ_CLIENTE             varchar(014) default NULL
  ,NOME_CLIENTE                 varchar(030) default NULL
  ,VALOR_CARNE                  varchar(015) default NULL
  ,QTD_PARCELAS                 varchar(003) default NULL
  ,DT_VENCIMENTO                varchar(008) default NULL
  ,STATUS                       varchar(020) default NULL
  ,CODIGO_POSTAGEM_CORREIOS     varchar(034) default NULL
  ,ENDERECO                     varchar(060) default NULL
  ,BAIRRO                       varchar(030) default NULL
  ,CIDADE                       varchar(030) default NULL
  ,UF                           varchar(002) default NULL
  ,CEP                          varchar(008) default NULL
  ,ARQUIVO_ORIGEM_BANCO         varchar(013) default NULL
  ,DTA_REFERENCIA               varchar(008) default NULL
  ,DTA_POSTAGEM                 varchar(008) default NULL
  ,LINHA_ORIGEM                 TEXT
  ,LINHA_REL_ORIGEM             TEXT
  ,LINHA_REL_NEW                TEXT
  ,PRIMARY KEY  (SEQUENCIA)
);

DROP TABLE IF EXISTS @Tabela_Codigos_status;
CREATE TABLE IF NOT EXISTS @Tabela_Codigos_status(
   CODIGO               varchar(002)          NOT NULL
  ,DESCRICAO            varchar(050)          NOT NULL
  ,PRIMARY KEY (CODIGO)
  ,KEY idx_codigos_motivos_devolucao (CODIGO)
);

INSERT INTO @Tabela_Codigos_status(CODIGO, DESCRICAO)
       VALUES("01", "IMPRESSÃO") 
	        ,("02", "CEP INCONSISTENTE") 
            ,("03", "CEP INCONSISTENTE")
			,("04", "CEP INCONSISTENTE")
			,("05", "RETENÇÃO");

DROP TABLE IF EXISTS @Tabela_Codigos_motivos_devolucao;
CREATE TABLE IF NOT EXISTS @Tabela_Codigos_motivos_devolucao(
   CODIGO               varchar(002)          NOT NULL
  ,DESCRICAO            varchar(050)          NOT NULL
  ,PRIMARY KEY (CODIGO)
  ,KEY idx_codigos_motivos_devolucao (CODIGO)
);

INSERT INTO @Tabela_Codigos_motivos_devolucao(CODIGO, DESCRICAO)
       VALUES("01", "Mudou-se") 
            ,("02", "Endereço insuficiente")
			,("03", "Não existe o nº. indicado")
			,("04", "Falecido")
			,("05", "Desconhecido")
			,("06", "Recusado")
			,("07", "Ausente")
			,("08", "Não procurado")
			,("09", "Outros");

/*DROP TABLE IF EXISTS @Tabela_Controle_arquivos;*/
CREATE TABLE IF NOT EXISTS @Tabela_Controle_arquivos (
  LOTE                 int(10)      unsigned NOT NULL,
  DATA_INSERSAO        datetime              NOT NULL,
  ARQUIVO              varchar(100)          NOT NULL,
  PAGINAS              varchar(010)          NOT NULL,
  OBJETOS              varchar(010)          NOT NULL,
  PRIMARY KEY (LOTE, ARQUIVO),
  KEY idx_controle_arquivo (ARQUIVO)
);

CREATE TABLE IF NOT EXISTS @Tabela_Controle_lotes (
  LOTE_PEDIDO      int     NOT NULL auto_increment,
  VALIDO           CHAR(1) NOT NULL default 'N',

  DATA_CRIACAO     DATETIME,
  CHAVE            VARCHAR(17),
  ID               VARCHAR(17),
  USUARIO_WIN      VARCHAR(20),
  USUARIO_APP      VARCHAR(20),
  IP               VARCHAR(14),
  LOTE_LOGIN       INT,

  RELATORIO_QTD    MEDIUMBLOB,
  HOSTNAME         varchar(15),
  PRIMARY KEY  (LOTE_PEDIDO)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
