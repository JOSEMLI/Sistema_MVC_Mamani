use db_modelo;

-- insertando registros a la tabla SEMESTRE>

insert into Semestre values ('2018-I','2018','A');
insert into Semestre values ('2018-II','2018','A');
insert into Semestre values ('2018-REC','2018','I');
insert into Semestre values ('2019-I','2019','A');

-- insertando registros a la tabla MODELO-->

insert into Modelo values ('MODELO I','este es el modelo 1','A');
insert into Modelo values ('MODELO II','este es el modelo 2','A');
insert into Modelo values ('MODELO III','este es el modelo 3','I');
insert into Modelo values ('MODELO IV','este es el modelo 4','A');

-- insertando registros a la tabla DOCENTE-->

insert into Docente values ('2014548654','87548647','Lopez Mendoza','Juan','M','ljuan@gmail.com','984567215','docente','TC','cat A','foto','A');
insert into Docente values ('2016859345','97456821','Calisaya Maquera','Jose','M','jcalisaya@gmail.com','984567215','docente','TP','cat B','foto','A');
insert into Docente values ('2014594654','87546247','Rodriguez Marca','Elard','M','elardroma@gmail.com','989564215','docente','TC','cat C','foto','A');
insert into Docente values ('2016946845','97145821','Ale Nieto','Tito','M','titofale@gmail.com','984642815','docente','TP','cat D','foto','A');



-- insertando registros a la tabla USUARIO -->
INSERT INTO Usuario VALUES (1,'jlopez','123456','administrador','usuario1.png','A')
INSERT INTO Usuario VALUES (2,'jcalizaya','12345','supervisor','usuario4.png','A')
INSERT INTO Usuario VALUES (3,'elardroma','1234','usuario','usuario2.png','A')
INSERT INTO Usuario VALUES (4,'titofale','123','administrador','usuario3.png','A')


-- insertando registros a la tabla Estudiante>

insert into Estudiante values ('2013046588','68452635','Mamani Maquera','Juan','M','jmamani@gmail.com','las vilcas','935468264','sin foto','A');
insert into Estudiante values ('2013634518','68464825','Mendoza Lopez','Maria','F','mmendoza@gmail.com','las vilcas','935658424','sin foto','A');
insert into Estudiante values ('2086421948','68356485','Padilla Paredes','Yoselin','F','ypadilla@gmail.com','las vilcas','935436547','sin foto','A');
insert into Estudiante values ('2084682156','68465216','Linares Cabrera','Nathalia','F','nlinares@gmail.com','las vilcas','932648124','sin foto','A');


-- insertando registros a la tabla Asignacion>

insert into Asignacion values (1,'Asignacion 2018-I','2018-05-18','A');
insert into Asignacion values (2,'Asignacion 2018-II','2018-05-18','A');
insert into Asignacion values (3,'Asignacion 2018-REC','2018-05-18','A');
insert into Asignacion values (4,'Asignacion 2019-I','2019-05-19','A');



-- insertando registros a la tabla criterio>

insert into Criterio values (1,'criterio spansih','criterio english','este es la url del criterio I','criterio del modelo I','A');
insert into Criterio values (2,'criterio spansih','criterio english','este es la url del criterio I','criterio del modelo II','A');
insert into Criterio values (3,'criterio spansih','criterio english','este es la url del criterio I','criterio del modelo III','A');
insert into Criterio values (4,'criterio spansih','criterio english','este es la url del criterio I','criterio del modelo VI','A');


-- insertando registros a la tabla Asignacion detalle>

insert into DetalleAsignacion values (1,1,1,'A');
insert into DetalleAsignacion values (2,2,2,'A');
insert into DetalleAsignacion values (3,3,3,'A');
insert into DetalleAsignacion values (4,4,4,'A');



-- insertando registros a la tabla CONTROL -->
INSERT INTO control VALUES (1,'titulo I de control I','2018-05-18','A');
INSERT INTO Control VALUES (2,'titulo II de control II','2018-05-18','A');
INSERT INTO Control VALUES (3,'titulo III de control III','2018-05-18','A');
INSERT INTO Control VALUES (4,'titulo IV de control IV','2019-05-19','A');


-- insertando registros a la tabla control detalle>

insert into ControlAsignacion values (1,1,1,'2018-05-18','2018-10-18','5','S1','20 %','libre','archivoI.docx','observacion I de control','A');
insert into ControlAsignacion values (2,2,2,'2018-05-18','2018-10-18','5','S2','20 %','libre','archivoII.docx','observacion II de control','A');
insert into ControlAsignacion values (3,3,3,'2018-05-18','2018-10-18','5','S3','20 %','libre','archivoIII.docx','observacion III de control','A');
insert into ControlAsignacion values (4,4,4,'2019-05-19','2019-10-19','5','S4','20 %','libre','archivoIV.docx','observacion IV de control','A');



-- insertando registros a la tabla actividad >

insert into Actividad values (1,1,'nombre de la actividad I','descripcion de la actividad I','2018-05-18','D:/proyecto','A');
insert into Actividad values (2,2,'nombre de la actividad II','descripcion de la actividad II','2018-05-19','D:/proyecto','A');
insert into Actividad values (3,3,'nombre de la actividad III','descripcion de la actividad III','2018-05-20','D:/proyecto','A');
insert into Actividad values (4,4,'nombre de la actividad IV','descripcion de la actividad IV','2018-05-21','D:/proyecto','A');



-- insertando registros a la tabla evidencia criterio>

insert into EvidenciaCriterio values (1,'importante','300','.docx','documento importante');


-- insertando registros a la tabla evidencia Actividad>

insert into EvidenciaCriterio values (1,'documento','300','.docx','archivo de actividad 1');



