--
-- File generated with SQLiteStudio v3.4.4 on mié. oct. 25 19:10:34 2023
--
-- Text encoding used: UTF-8
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Table: almacenistas
DROP TABLE IF EXISTS almacenistas;

CREATE TABLE IF NOT EXISTS almacenistas (
    id               INTEGER  PRIMARY KEY,
    id_usuario       INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Table: coordinadores
DROP TABLE IF EXISTS coordinadores;

CREATE TABLE IF NOT EXISTS coordinadores (
    id               INTEGER  PRIMARY KEY,
    id_usuario       INTEGER,
    nomina           INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Table: divisiones
DROP TABLE IF EXISTS divisiones;

CREATE TABLE IF NOT EXISTS divisiones (
    id               INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion      TEXT,
    fch_creacion     TEXT    DEFAULT (datetime('now') ),
    fch_modificacion TEXT    DEFAULT '0000-00-00 00:00:00',
    fch_eliminacion  TEXT    DEFAULT '0000-00-00 00:00:00'
);


-- Table: ensena
DROP TABLE IF EXISTS ensena;

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
DROP TABLE IF EXISTS equipos;

CREATE TABLE IF NOT EXISTS equipos (
    id             INTEGER PRIMARY KEY,
    cnt_disponible INTEGER,
    nombre         TEXT,
    descripcion    TEXT
);


-- Table: est_usuarios
DROP TABLE IF EXISTS est_usuarios;

CREATE TABLE IF NOT EXISTS est_usuarios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO est_usuarios (id, descripcion) VALUES (1, 'Activo');
INSERT INTO est_usuarios (id, descripcion) VALUES (2, 'Inactivo');

-- Table: estudiantes
DROP TABLE IF EXISTS estudiantes;

CREATE TABLE IF NOT EXISTS estudiantes (
    id               INTEGER  PRIMARY KEY,
    id_usuario       INTEGER,
    id_grupo         INTEGER,
    registro         INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id),
    FOREIGN KEY (
        id_grupo
    )
    REFERENCES grupos (id) 
);


-- Table: grupos
DROP TABLE IF EXISTS grupos;

CREATE TABLE IF NOT EXISTS grupos (
    id     INTEGER PRIMARY KEY,
    nombre TEXT
);


-- Table: imparte
DROP TABLE IF EXISTS imparte;

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

-- Table: materias
DROP TABLE IF EXISTS materias;

CREATE TABLE IF NOT EXISTS materias (
    id               INTEGER PRIMARY KEY AUTOINCREMENT,
    id_division      INTEGER,
    descripcion      TEXT,
    fch_creacion     TEXT    DEFAULT (datetime('now') ),
    fch_modificacion TEXT    DEFAULT '0000-00-00 00:00:00',
    fch_eliminacion  TEXT    DEFAULT '0000-00-00 00:00:00',
    FOREIGN KEY (
        id_division
    )
    REFERENCES divisiones (id) 
);


-- Table: prm_prestamos
DROP TABLE IF EXISTS prm_prestamos;

CREATE TABLE IF NOT EXISTS prm_prestamos (
    id                  INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_tpo_prm_prestamo INTEGER,
    id_usuario          INTEGER,
    fch_inicio          DATETIME DEFAULT (datetime('now') ),
    fch_fin             DATETIME,
    fch_creacion        DATETIME DEFAULT (datetime('now') ),
    fch_modificacion    DATETIME,
    fch_eliminacion     DATETIME,
    FOREIGN KEY (
        id_tpo_prm_prestamo
    )
    REFERENCES tps_prm_prestamos (id),
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Table: profesores
DROP TABLE IF EXISTS profesores;

CREATE TABLE IF NOT EXISTS profesores (
    id               INTEGER  PRIMARY KEY,
    id_usuario       INTEGER,
    nomina           INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Table: rlc_prs_equipo
DROP TABLE IF EXISTS rlc_prs_equipo;

CREATE TABLE IF NOT EXISTS rlc_prs_equipo (
    id              INTEGER PRIMARY KEY,
    id_prm_prestamo INTEGER,
    id_equipo       INTEGER,
    FOREIGN KEY (
        id_prm_prestamo
    )
    REFERENCES prm_prestamos (id),
    FOREIGN KEY (
        id_equipo
    )
    REFERENCES equipos (id) 
);


-- Table: salones
DROP TABLE IF EXISTS salones;

CREATE TABLE IF NOT EXISTS salones (
    id          INTEGER PRIMARY KEY,
    id_division INTEGER,
    nmr_salon   INTEGER,
    FOREIGN KEY (
        id_division
    )
    REFERENCES divisiones (id) 
);


-- Table: tps_mantenimiento
DROP TABLE IF EXISTS tps_mantenimiento;

CREATE TABLE IF NOT EXISTS tps_mantenimiento (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_mantenimiento (id, descripcion) VALUES (1, 'Preventido');
INSERT INTO tps_mantenimiento (id, descripcion) VALUES (2, 'Correctivo');
INSERT INTO tps_mantenimiento (id, descripcion) VALUES (3, 'Predictivo');

-- Table: mantenimiento
DROP TABLE IF EXISTS mantenimiento;

CREATE TABLE IF NOT EXISTS mantenimiento (
    id                   INTEGER  PRIMARY KEY,
    id_tpo_mantenimiento INTEGER,
    id_equipo            INTEGER,
    descripciones        TEXT,
    refaccion            TEXT,
    fch_inicio           DATETIME,
    fch_fin              DATETIME,
    fch_creacion         DATETIME DEFAULT (datetime('now') ),
    fch_modificacion     DATETIME,
    fch_eliminacion      DATETIME,
    FOREIGN KEY (
        id_tpo_mantenimiento
    )
    REFERENCES tps_mantenimiento (id),
    FOREIGN KEY (
        id_equipo
    )
    REFERENCES equipos (id) 
);

-- Table: tps_prm_prestamos
DROP TABLE IF EXISTS tps_prm_prestamos;

CREATE TABLE IF NOT EXISTS tps_prm_prestamos (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_prm_prestamos (id, descripcion) VALUES (1, 'Generado por un estudiante');
INSERT INTO tps_prm_prestamos (id, descripcion) VALUES (2, 'Generado por un profesor');

-- Table: tps_usuarios
DROP TABLE IF EXISTS tps_usuarios;

CREATE TABLE IF NOT EXISTS tps_usuarios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_usuarios (id, descripcion) VALUES (1, 'Almacenista');
INSERT INTO tps_usuarios (id, descripcion) VALUES (2, 'Estudiante');
INSERT INTO tps_usuarios (id, descripcion) VALUES (3, 'Profesor');
INSERT INTO tps_usuarios (id, descripcion) VALUES (4, 'Coordinador');

-- Table: usuarios
DROP TABLE IF EXISTS usuarios;

CREATE TABLE IF NOT EXISTS usuarios (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT
                              NOT NULL,
    id_tpo_usuario   INTEGER  NOT NULL,
    id_est_usuario   INTEGER  NOT NULL,
    contrasena       BLOB,
    nombre           TEXT     NOT NULL
                              DEFAULT '',
    apl_materno      TEXT,
    apl_paterno      TEXT,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_tpo_usuario
    )
    REFERENCES tps_usuario (id),
    FOREIGN KEY (
        id_est_usuario
    )
    REFERENCES est_usuario (id) 
);


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
