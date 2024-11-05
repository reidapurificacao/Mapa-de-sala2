ALTER TABLE CURSOS
ALTER COLUMN Nome VARCHAR(200);

ALTER TABLE CURSOS
ALTER COLUMN Sigla VARCHAR(100);

ALTER TABLE PROFESSORES
ADD ATIVO BIT;

INSERT INTO DISCIPLINAS (Nome, Sigla, Ativo) VALUES

('Artes','ARTES',1)
,('Educa��o F�sica','ED F�SICA',1)
,('Biologia','BIOOLOGIA',1)
,('F�sica','F�SICA',1)
,('Qu�mica','QU�MICA',1)
,('Filosofia','FILOSOFIA',1)
,('Hist�ria','HIST�RIA',1)
,('Geografia','GEOGRAFIA',1)
,('Matem�tica ','MAT',1)
,('L�ngua Inglesa ','LING ING',1)
,('L�ngua Portuguesa ','LING PORT',1)
,('Sociologia','SOCIOLOGIA',1)
,('Laborat�rio de Investiga��o Cient�fica','L. I. C.',1)
,('Pr�ticas de Empreendedorismo','P.E.',1)
,('Estudos Avan�ados em Ci�ncias da Natureza e suas Tecnologias','E. A. C. N. T.',1)
,('Estudos Avan�ados em Matem�tica e suas Tecnologias','E. A. M. T.',1)
,('�tica e Cidadania Organizacional','E.C.O',1)
,('Laborat�rio de Media��o e Interven��o Sociocultural','L. M. I. S.',1)
,('Laborat�rio de Processos Criativos','L. P. C.',1)
,('L�ngua Estrangeira Moderna - Ingl�s e Comunica��o Profissional','LING. EST. MODER.',1)
,('L�ngua Portuguesa, Literatura e Comunica��o Profissional','PORT L.P.L.C.P.',1)
,('An�lise e Projeto de Sistemas','APS',1)
,('Design Digital','DD',1)
,('Fundamentos da Inform�tica','FUND INFO',1)
,('Programa��o Web I','PW I',1)
,('Programa��o Web II','PW II',1)
,('Programa��o Web III','PW III',1)
,('T�cnicas de Programa��o e Algoritmos','TPA',1)
,('Banco de Dados I','BD I',1)
,('Banco de Dados II','BD II',1)
,('Desenvolvimento de Sistemas','DS',1)
,('Programa��o de Aplicativos Mobile I','PAM I',1)
,('Programa��o de Aplicativos Mobile II','PAM II',1)
,('Internet, Protocolos e Seguran�a de Sistemas da Informa��o','IPSSI',1)
,('Planejamento e Desenvolvimento do TCC em Desenvolvimento de Sistemas','PDTCC',1)
,('Qualidade e Teste de Software','QTS',1)
,('Sistemas Embarcados','SE',1);


INSERT INTO PROFESSORES (Nome, Apelido, Ativo) VALUES 
('ADILCILEIA BRAGA RESENDE','LEIA',1),
('ALEXANDER DA SILVA MARANHO','ALEXANDER',1),
('ALEXANDRE GALVANI','GALVANI',1),
('ALUISIO ADURENS','ALUISIO',1),
('ANA PAULA ZANIBONI BARRETO','ANA PAULA',1),
('ANTONIO MONTEIRO DA SILVA','MONTEIRO',1),
('CAROLINA LEITE CARDINALE','CAROL',1),
('ELIETE REGINA DE SOUZA','ELIETE',1),
('ELISIO BARBOSA RODRIGUES','ELISIO',1),
('FERNANDO CESAR GRACIANO','FERNANDO G',1),
('IRIANI APARECIDA NORATO MELHEM','IRIANI',1),
('JOAO RICARDO ANDREO','JOAO R',1),
('LUCILENE MARANHO','LUCILENE',1),
('LUIZ GUSTAVO RODRIGUES','LUIZ GUSTAVO',1),
('MARCELO AUGUSTO JUNQUEIRA DE OLIVEIRA','MARCELO O.',1),
('MARCELO JOSE STORION','STORION',1),
('MARIA LUCIA DE AZEVEDO','MALU',1),
('OLIVER MARCOS NETTO','OLIVER',1),
('OSVALDO HENRIQUE NICOLIELO MAIA','OSVALDO',1),
('PAULA VILANI DA SILVA','PAULA V.',1),
('RAFAEL MARTINS SANCHES','RAFAEL S.',1),
('RENATA FERNANDES','RENATA F.',1),
('ROBERTA RIBEIRO SOARES MOURA PADOAN','ROBERTA',1),
('SILVIA CRISTIANE MARANGONI','SILVIA M.',1),
('SILVIA MARIA RIBEIRO MARTINS FERREIRA','SILVIA F.',1),
('THAIS APARECIDA DE CASTRO RAMOS POLLICE','THAIS P.',1),
('THAIS HERMOSO DE OLIVEIRA','THAIS H.',1),
('VANDERLEIA VALERIA DE MELO','VANDERLEIA',1),
('WELINGTON LUIS DE CAMPOS','WELINGTON C.',1);


INSERT INTO SALAS (Nome, NumeroComputadores, NumeroCadeiras, IsLab, Disponivel  ) VALUES 
('SALA 01',1,40,0,1),
('SALA 02',20,40,1,1),
('SALA 03',1,40,0,1),
('SALA 04',1,40,0,1),
('SALA 05',20,40,1,1),
('SALA 06',1,40,0,1),
('SALA 07',1,40,0,1),
('SALA 08',20,40,1,1),
('SALA 09',1,40,0,1),
('SALA 10',1,40,0,1),
('SALA 11',1,40,0,1),
('SALA 12',1,40,0,1),
('SALA 13',1,40,0,1),
('SALA 14',1,40,0,1),
('SALA 15',20,40,1,1),
('SALA 16',1,40,0,0),
('SALA 17',20,40,1,1),
('SALA 18',20,40,1,1),
('SALA 19',20,40,1,1),
('SALA 20',1,40,0,1),
('SALA 21',1,40,0,1),
('SALA 22',1,40,0,1),
('SALA 23',1,40,0,1),
('SALA 24',1,40,0,1),
('SALA 25',1,40,0,1),
('SALA 26',1,40,0,1);

INSERT INTO CURSOS (Nome, Turno, Sigla, Ativo) VALUES

('T�cnico em Administra��o', 'Noite', 'ADM-N',1),
('Administra��o Integrado ao Ensino M�dio (Mtec Noturno)', 'Noite', 'ADM-MTEC-N',1),
('Administra��o Integrado ao Ensino M�dio PI', 'Integral', 'ADM-PI',1),
('T�cnico em Desenvolvimento de Sistemas', 'Noite', 'DS-N',1),
('Desenvolvimento de Sistemas Integrado ao Ensino M�dio AMS', 'Tarde', 'AMS-T ',1),
('Desenvolvimento de Sistemas Integrado ao Ensino M�dio PI ', 'Integral', 'DS-PI',1),
('T�cnico em Enfermagem ', 'Manh�', 'ENF-M',1),
('T�cnico em Enfermagem ', 'Tarde', 'ENF-T',1),
('Ensino M�dio com Itiner�rio Formativo de Ci�ncias Humanas e Sociais Aplicadas', 'Manh�', 'IFCHS-M',1),
('Inform�tica para Internet Integrado ao Ensino M�dio Mtec', 'Tarde', 'INFO-MTEC-T',1),
('T�cnico em Log�stica (Ernesto Monte) ', 'Noite', 'LOG-N EM',1),
('T�cnico em Log�stica (Agudos) ', 'Noite', 'LOG-N AG',1),
('Log�stica Integrado ao Ensino M�dio - Mtec ', '', 'LOG-MTEC-T',1),
('T�cnico em Recursos Humanos ', 'Noite', 'RH-N',1),
('T�cnico em Sa�de Bucal ', 'Noite', 'SB-N',1),
('T�cnico em Seguran�a do Trabalho ', 'Noite', 'SEG-N',1),
('Servi�os Jur�dicos Integrado ao Ensino M�dio - Mtec ', 'Tarde', 'SJ-MTEC-T',1);