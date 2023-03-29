CREATE DATABASE pruebaPractica;
//Creando base de datos bajo el usuario de AdminPruebaPractcia
CREATE SCHEMA salario;
//Creando esquema salario para mejor manejo y manipulacion
CREATE SCHEMA usuario;
//creando esquema usuario para mejor manejo y manipulacion
REVOKE USAGE ON SCHEMA salario FROM PUBLIC 
REVOKE USAGE ON SCHEMA usuario FROM PUBLIC
//Removiendo el acceso desde PUBLIC a los esquemas con informasion 


GRANT ALL ON SCHEMA salario TO "AdminPruebaPractica"
GRANT ALL ON ALL tables IN SCHEMA salario TO "AdminPruebaPractica" 
GRANT ALL ON SCHEMA usuario TO "AdminPruebaPractica"
GRANT ALL ON ALL tables IN SCHEMA usuario TO "AdminPruebaPractica"
GRANT CREATE ON SCHEMA usuario TO "AdminPruebaPractica"
GRANT ALL ON SCHEMA usuario TO "AdminPruebaPractica"
//dando permisos a los esquemas con informacion

CREATE extension pgcrypto;
//creando extension generica para el almacenamiento encriptado de password

CREATE TABLE usuario.persona(
	idPersona SERIAL PRIMARY KEY,
	idTipoUsuario INTEGER,
	nombres VARCHAR NOT NULL,
	apellidos VARCHAR NOT NULL,
	email VARCHAR NOT NULL UNIQUE,
	nacimiento DATE NOT NULL,
	pass TEXT NOT NULL,
	dpi BIGINT NOT NULL UNIQUE,
	numHijos INTEGER NOT NULL,
	salarioBase NUMERIC(15,2) NOT NULL,
	fechaCreacion TIMESTAMP NOT NULL,
	usuarioLogin VARCHAR NOT NULL UNIQUE,
	puedeLogear BOOLEAN NOT NULL,
	CONSTRAINT persona_fk_tipoUsuario FOREIGN KEY (idTipoUsuario) REFERENCES usuario.tipousuario(idTipoUsuario)
)SELECT * FROM usuario.persona 
//Luego de que aumente unpoco el coidgo usando dos tablas, se elimina el CONSTRAINT y se procede a usar unicamente a IDTipoUsuario como INT
//quedando 0 como adimn, y 1 como usuario regular, quedando la consulta de la siguiente manera

CREATE TABLE usuario.persona(
	idPersona SERIAL PRIMARY KEY,
	tipoUsuario INTEGER,
	nombres VARCHAR NOT NULL,
	apellidos VARCHAR NOT NULL,
	email VARCHAR NOT NULL UNIQUE,
	nacimiento DATE NOT NULL,
	pass TEXT NOT NULL,
	dpi BIGINT NOT NULL UNIQUE,
	numHijos INTEGER NOT NULL,
	salarioBase NUMERIC(15,2) NOT NULL,
	fechaCreacion TIMESTAMP NOT NULL,
	usuarioLogin VARCHAR NOT NULL UNIQUE,
	puedeLogear BOOLEAN NOT NULL
)


//Creando tabla de almacenamiento de informacion de las personas en este ejercicio
INSERT INTO usuario.persona(nombres, apellidos, email, nacimiento, pass, dpi, numhijos, salarioBase, fechaCreacion, usuarioLogin,tipoUsuario, puedeLogear)
VALUES ('Nombre Usuario1', 'Apellido Usuario1', 'correo@usuario1.com', '01/01/1950', crypt('user1_password', gen_salt('md5')), 4444555554444, 2, 7000.09, NOW(), 'usu1',1,TRUE)
//Creando el usuario de Administrador con datos miscelaneos
SELECT * FROM usuario.persona
SELECT (pass = crypt('user1_password', pass)) AS pswmatch FROM usuario.persona WHERE usuario.persona.email = 'correo@usuario1.com';
//realizando prueba de login con usuario y contrase;a correcta, devuelve TRUE si ambos objetos son correcots y falso o NULL si los parametros son incorrectos 
CREATE TABLE usuario.tipousuario(
	idTipoUsuario SERIAL PRIMARY KEY,
	nombre VARCHAR NOT NULL
)
//tabla dedicada al almacenamiento del rol que tendra cada uno de los usuarios

INSERT INTO usuario.tipousuario(nombre) VALUES ('Admin'),('Colaborador')
SELECT * FROM usuario.tipousuario
//a;adiendo los tipos de usuario que seran viables por el momento en el programa







