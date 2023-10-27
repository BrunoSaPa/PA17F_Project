--
-- File generated with SQLiteStudio v3.4.4 on jue. oct. 26 18:55:54 2023
--
-- Text encoding used: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: almacenistas
CREATE TABLE IF NOT EXISTS almacenistas (id INTEGER PRIMARY KEY, id_usuario INTEGER REFERENCES usuarios (id), FOREIGN KEY (id_usuario) REFERENCES usuarios (id));

-- Table: contiene
CREATE TABLE IF NOT EXISTS contiene (id INTEGER PRIMARY KEY, id_prm_prestamo INTEGER, id_equipo INTEGER, FOREIGN KEY (id_prm_prestamo) REFERENCES prm_prestamos (id), FOREIGN KEY (id_equipo) REFERENCES equipos (id));

-- Table: coordinadores
CREATE TABLE IF NOT EXISTS coordinadores (id INTEGER PRIMARY KEY, id_usuario INTEGER REFERENCES usuarios (id), FOREIGN KEY (id_usuario) REFERENCES usuarios (id));

-- Table: divisiones
CREATE TABLE IF NOT EXISTS divisiones (id INTEGER PRIMARY KEY, nombre VARCHAR (50));

-- Table: ensena
CREATE TABLE IF NOT EXISTS ensena (
    id          INTEGER PRIMARY KEY,
    id_grupo    INTEGER,
    id_profesor INTEGER,
    FOREIGN KEY (
        id_grupo
    )
    REFERENCES grupos (id),
    FOREIGN KEY (
        id_profesor
    )
    REFERENCES profesores (id) 
);

-- Table: equipos
CREATE TABLE IF NOT EXISTS equipos (id INTEGER PRIMARY KEY, cnt_disponible INTEGER, nombre VARCHAR (70), descripcion TEXT);

-- Table: estudiantes
CREATE TABLE IF NOT EXISTS estudiantes (id INTEGER PRIMARY KEY, id_usuario INTEGER, id_grupo INTEGER, FOREIGN KEY (id_usuario) REFERENCES usuarios (id), FOREIGN KEY (id_grupo) REFERENCES grupos (id));

-- Table: grupos
CREATE TABLE IF NOT EXISTS grupos (
    id     INTEGER PRIMARY KEY,
    nombre TEXT
);

-- Table: imparte
CREATE TABLE IF NOT EXISTS imparte (
    id          INTEGER PRIMARY KEY,
    id_profesor INTEGER,
    id_materia  INTEGER,
    FOREIGN KEY (
        id_profesor
    )
    REFERENCES profesores (id),
    FOREIGN KEY (
        id_materia
    )
    REFERENCES materias (id) 
);

-- Table: maneja
CREATE TABLE IF NOT EXISTS maneja (id INTEGER PRIMARY KEY, id_tps_mantenimiento REFERENCES tps_mantenimiento (id), id_mantenimiento INTEGER REFERENCES mantenimiento (id));

-- Table: mantenimiento
CREATE TABLE IF NOT EXISTS mantenimiento (id INTEGER PRIMARY KEY, id_tpo_mantenimiento INTEGER, id_equipo INTEGER REFERENCES equipos (id), descripcion TEXT, refaccion TEXT, fch_inicio DATETIME, fch_fin DATETIME);

-- Table: materias
CREATE TABLE IF NOT EXISTS materias (id INTEGER PRIMARY KEY AUTOINCREMENT, id_division INTEGER, nombre VARCHAR (60), FOREIGN KEY (id_division) REFERENCES divisiones (id));

-- Table: prm_prestamos
CREATE TABLE IF NOT EXISTS prm_prestamos (
    id                  INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_salones          INTEGER  REFERENCES salones (id),
    id_tpo_prm_prestamo INTEGER,
    fch_inicio          DATETIME DEFAULT (datetime('now') ),
    fch_fin             DATETIME,
    fch_modificacion    DATETIME,
    fch_eliminacion     DATETIME,
    fch_creacion        DATETIME,
    FOREIGN KEY (
        id_tpo_prm_prestamo
    )
    REFERENCES tps_prm_prestamos (id));

-- Table: profesores
CREATE TABLE IF NOT EXISTS profesores (id INTEGER PRIMARY KEY, id_usuario INTEGER, FOREIGN KEY (id_usuario) REFERENCES usuarios (id));

-- Table: puede
CREATE TABLE IF NOT EXISTS puede (id INTEGER PRIMARY KEY, id_usuario INTEGER REFERENCES usuarios (id), id_prm_prestamo INTEGER REFERENCES prm_prestamos (id));

-- Table: recibe
CREATE TABLE IF NOT EXISTS recibe (id INTEGER PRIMARY KEY, id_mantenimiento INTEGER REFERENCES tps_mantenimiento (id), id_equipo INTEGER REFERENCES equipos (id));

-- Table: salones
CREATE TABLE IF NOT EXISTS salones (id INTEGER PRIMARY KEY, nombre VARCHAR (40));

-- Table: tps_mantenimiento
CREATE TABLE IF NOT EXISTS tps_mantenimiento (id INTEGER PRIMARY KEY AUTOINCREMENT, descripcion VARCHAR (40));
INSERT INTO tps_mantenimiento (id, descripcion) VALUES (1, 'Preventido');
INSERT INTO tps_mantenimiento (id, descripcion) VALUES (2, 'Correctivo');
INSERT INTO tps_mantenimiento (id, descripcion) VALUES (3, 'Predictivo');

-- Table: tps_prm_prestamos
CREATE TABLE IF NOT EXISTS tps_prm_prestamos (id INTEGER PRIMARY KEY AUTOINCREMENT, descripcion VARCHAR (40));
INSERT INTO tps_prm_prestamos (id, descripcion) VALUES (1, 'Generado por un estudiante');
INSERT INTO tps_prm_prestamos (id, descripcion) VALUES (2, 'Generado por un profesor');

-- Table: usuarios
CREATE TABLE IF NOT EXISTS usuarios (id INTEGER PRIMARY KEY, nombre VARCHAR (40), apellido_P VARCHAR (50), apellido_M VARCHAR (50), contrasena VARCHAR (15) NOT NULL);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
