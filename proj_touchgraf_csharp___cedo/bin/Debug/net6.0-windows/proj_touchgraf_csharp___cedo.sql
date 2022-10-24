CREATE DATABASE IF NOT EXISTS @Database;

USE @Database;

DROP TABLE IF EXISTS @Tabela_Processamento;
CREATE TABLE IF NOT EXISTS @Tabela_Processamento (
   SEQUENCIA                  INTEGER
  ,FIELD_01                   varchar(009) default NULL
  ,FIELD_02                   varchar(009) default NULL
  ,FIELD_03                   varchar(009) default NULL
  ,FIELD_04                   varchar(010) default NULL
  ,FIELD_05                   varchar(015) default NULL
  ,FIELD_06                   varchar(021) default NULL
  ,FIELD_07                   varchar(011) default NULL
  ,FIELD_08                   varchar(018) default NULL
  ,FIELD_09                   varchar(005) default NULL
  ,FIELD_10                   varchar(039) default NULL
  ,FIELD_11                   varchar(001) default NULL
  ,CIF                        varchar(034) default NULL
  ,PAGINAS                    INTEGER
  ,FOLHAS                     INTEGER
  ,PAGINA_INICIAL             INTEGER
  ,PAGINA_FINAL               INTEGER
  ,NOME                       varchar(040) default NULL
  ,LOGRADOURO                 varchar(100) default NULL
  ,CEP                        varchar(009) default NULL
  ,FILLER_01                  varchar(001) default NULL
  ,FILLER_02                  varchar(001) default NULL
  ,FILLER_03                  varchar(001) default NULL
  ,FILLER_04                  varchar(001) default NULL
  ,FILLER_05                  varchar(001) default NULL
  ,CODIGO_BARRAS              varchar(044) default NULL
  ,FILLER_06                  varchar(001) default NULL
  ,FILLER_07                  varchar(005) default NULL
  ,NOME_2                     varchar(040) default NULL
  ,DEVOLUCAO                  varchar(010) default NULL
  ,LOTE                       varchar(005) default NULL
  ,DATA_POSTAGEM              varchar(006) default NULL
  ,ARQUIVO_IDX                varchar(050) default NULL
  ,ARQUIVO_AFP                varchar(050) default NULL
  ,ARQUIVO_ZIP                varchar(050) default NULL
  ,MOVIMENTO                  varchar(008) default NULL
);

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
