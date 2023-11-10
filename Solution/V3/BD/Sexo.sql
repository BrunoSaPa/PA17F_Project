--
-- Archivo generado con SQLiteStudio v3.4.4 el jue. nov. 9 22:08:56 2023
--
-- Codificación de texto usada: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Tabla: almacenistas
DROP TABLE IF EXISTS almacenistas;

CREATE TABLE IF NOT EXISTS almacenistas (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_usuario       INTEGER  REFERENCES usuarios (id) ON DELETE CASCADE
                                                       ON UPDATE CASCADE,
    nomina           INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             1,
                             27,
                             20300707,
                             X'd779f57deed7db08',
                             NULL,
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             2,
                             30,
                             20300709,
                             X'38c541cfeed7db08',
                             NULL,
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             3,
                             31,
                             20400708,
                             X'18f6fff8eed7db08',
                             NULL,
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             4,
                             33,
                             12345678,
                             '2023-10-28 23:18:07.0380387',
                             NULL,
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             5,
                             38,
                             20300686,
                             '2023-10-29 17:43:34.1093338',
                             '2023-10-30 07:22:20.2373121',
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             6,
                             41,
                             123,
                             '2023-10-31 19:07:03.713941',
                             NULL,
                             NULL
                         );

INSERT INTO almacenistas (
                             id,
                             id_usuario,
                             nomina,
                             fch_creacion,
                             fch_modificacion,
                             fch_eliminacion
                         )
                         VALUES (
                             7,
                             43,
                             20300683,
                             '2023-11-04 09:39:00.8577859',
                             NULL,
                             NULL
                         );


-- Tabla: coordinadores
DROP TABLE IF EXISTS coordinadores;

CREATE TABLE IF NOT EXISTS coordinadores (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_usuario       INTEGER  REFERENCES usuarios (id) ON DELETE CASCADE
                                                       ON UPDATE CASCADE,
    nomina           INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Tabla: divisiones
DROP TABLE IF EXISTS divisiones;

CREATE TABLE IF NOT EXISTS divisiones (
    id               INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion      TEXT,
    fch_creacion     TEXT    DEFAULT (datetime('now') ),
    fch_modificacion TEXT    DEFAULT '0000-00-00 00:00:00',
    fch_eliminacion  TEXT    DEFAULT '0000-00-00 00:00:00'
);

INSERT INTO divisiones (
                           id,
                           descripcion,
                           fch_creacion,
                           fch_modificacion,
                           fch_eliminacion
                       )
                       VALUES (
                           1,
                           'Software',
                           NULL,
                           NULL,
                           NULL
                       );


-- Tabla: equipos
DROP TABLE IF EXISTS equipos;

CREATE TABLE IF NOT EXISTS equipos (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    cnt_disponible   INTEGER,
    nombre           TEXT,
    descripcion      TEXT,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    num_inventario   INTEGER,
    anio_material    INTEGER
);

INSERT INTO equipos (
                        id,
                        cnt_disponible,
                        nombre,
                        descripcion,
                        fch_creacion,
                        fch_modificacion,
                        fch_eliminacion,
                        num_inventario,
                        anio_material
                    )
                    VALUES (
                        1,
                        2,
                        'Multimetro',
                        '2',
                        NULL,
                        NULL,
                        NULL,
                        24029,
                        2018
                    );

INSERT INTO equipos (
                        id,
                        cnt_disponible,
                        nombre,
                        descripcion,
                        fch_creacion,
                        fch_modificacion,
                        fch_eliminacion,
                        num_inventario,
                        anio_material
                    )
                    VALUES (
                        2,
                        2,
                        'Cables',
                        '2',
                        NULL,
                        NULL,
                        NULL,
                        24029,
                        2018
                    );


-- Tabla: equipos_prm
DROP TABLE IF EXISTS equipos_prm;

CREATE TABLE IF NOT EXISTS equipos_prm (
    id              INTEGER PRIMARY KEY,
    id_equipos      INTEGER REFERENCES equipos (id) ON DELETE CASCADE
                                                    ON UPDATE CASCADE,
    id_prm_prestamo INTEGER REFERENCES prm_prestamos (id) ON DELETE CASCADE
                                                          ON UPDATE CASCADE
);

INSERT INTO equipos_prm (
                            id,
                            id_equipos,
                            id_prm_prestamo
                        )
                        VALUES (
                            1,
                            1,
                            1
                        );

INSERT INTO equipos_prm (
                            id,
                            id_equipos,
                            id_prm_prestamo
                        )
                        VALUES (
                            2,
                            2,
                            1
                        );

INSERT INTO equipos_prm (
                            id,
                            id_equipos,
                            id_prm_prestamo
                        )
                        VALUES (
                            3,
                            1,
                            1
                        );


-- Tabla: est_prm_prestamos
DROP TABLE IF EXISTS est_prm_prestamos;

CREATE TABLE IF NOT EXISTS est_prm_prestamos (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  1,
                                  'Aprobado'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  2,
                                  'Pendiente'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  3,
                                  'Rechazado'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  4,
                                  'Pre-Aprobado'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  5,
                                  'Entregado'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  6,
                                  'No entregado'
                              );

INSERT INTO est_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  7,
                                  'En prestamoo'
                              );


-- Tabla: est_usuarios
DROP TABLE IF EXISTS est_usuarios;

CREATE TABLE IF NOT EXISTS est_usuarios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO est_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             1,
                             'Activo'
                         );

INSERT INTO est_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             2,
                             'Inactivo'
                         );


-- Tabla: estudiantes
DROP TABLE IF EXISTS estudiantes;

CREATE TABLE IF NOT EXISTS estudiantes (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_usuario       INTEGER  REFERENCES usuarios (id) ON DELETE CASCADE
                                                       ON UPDATE CASCADE,
    id_grupo         INTEGER  REFERENCES grupos (id) ON DELETE CASCADE
                                                     ON UPDATE CASCADE,
    registro         INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            1,
                            28,
                            NULL,
                            20300708,
                            X'bccce09deed7db08',
                            NULL,
                            NULL
                        );

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            2,
                            32,
                            NULL,
                            20300710,
                            X'90330318efd7db08',
                            NULL,
                            NULL
                        );

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            3,
                            34,
                            1,
                            12348765,
                            X'c3f992420cd8db08',
                            NULL,
                            NULL
                        );

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            4,
                            36,
                            1,
                            12345678,
                            '2023-10-28 23:46:25.0591981',
                            NULL,
                            NULL
                        );

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            5,
                            39,
                            1,
                            20300545,
                            '2023-10-30 12:43:10.9560738',
                            NULL,
                            NULL
                        );

INSERT INTO estudiantes (
                            id,
                            id_usuario,
                            id_grupo,
                            registro,
                            fch_creacion,
                            fch_modificacion,
                            fch_eliminacion
                        )
                        VALUES (
                            6,
                            40,
                            1,
                            20300658,
                            '2023-10-31 18:48:08.647713',
                            NULL,
                            NULL
                        );


-- Tabla: grupos
DROP TABLE IF EXISTS grupos;

CREATE TABLE IF NOT EXISTS grupos (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    nombre           TEXT,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME
);

INSERT INTO grupos (
                       id,
                       nombre,
                       fch_creacion,
                       fch_modificacion,
                       fch_eliminacion
                   )
                   VALUES (
                       1,
                       'Prueba',
                       '2023-10-29 04:36:39',
                       NULL,
                       NULL
                   );


-- Tabla: interfaces
DROP TABLE IF EXISTS interfaces;

CREATE TABLE IF NOT EXISTS interfaces (
    id                INTEGER PRIMARY KEY AUTOINCREMENT,
    id_tpo_usr_acceso INTEGER REFERENCES tps_usuarios (id) ON DELETE CASCADE
                                                           ON UPDATE CASCADE,
    nombre            TEXT,
    FOREIGN KEY (
        id_tpo_usr_acceso
    )
    REFERENCES tps_usuarios (id) 
);

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           1,
                           0,
                           'Inicio'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           2,
                           0,
                           'Login'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           3,
                           0,
                           'Default'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           4,
                           4,
                           'MantenimientoAlmacenistas'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           5,
                           4,
                           'MantenimientoCoordinadores'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           6,
                           4,
                           'MantenimientoProfesores'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           7,
                           4,
                           'MantenimientoEstudiantes'
                       );

INSERT INTO interfaces (
                           id,
                           id_tpo_usr_acceso,
                           nombre
                       )
                       VALUES (
                           8,
                           4,
                           'MantenimientoUsuarios'
                       );


-- Tabla: mantenimiento
DROP TABLE IF EXISTS mantenimiento;

CREATE TABLE IF NOT EXISTS mantenimiento (
    id                   INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_tpo_mantenimiento INTEGER  REFERENCES tps_mantenimiento (id) ON DELETE CASCADE
                                                                    ON UPDATE CASCADE,
    id_equipo            INTEGER  REFERENCES equipos (id) ON DELETE CASCADE
                                                          ON UPDATE CASCADE,
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


-- Tabla: prm_prestamos
DROP TABLE IF EXISTS prm_prestamos;

CREATE TABLE IF NOT EXISTS prm_prestamos (
    id                   INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_tpo_prm_prestamo  INTEGER  REFERENCES tps_prm_prestamos (id) ON DELETE CASCADE
                                                                    ON UPDATE CASCADE,
    id_usuario           INTEGER  REFERENCES usuarios (id) ON DELETE CASCADE
                                                           ON UPDATE CASCADE,
    fch_inicio           DATETIME DEFAULT (datetime('now') ),
    fch_fin              DATETIME,
    fch_creacion         DATETIME DEFAULT (datetime('now') ),
    fch_modificacion     DATETIME,
    fch_eliminacion      DATETIME,
    id_est_prm_prestamos INTEGER  REFERENCES est_prm_prestamos (id) ON DELETE CASCADE
                                                                    ON UPDATE CASCADE,
    id_salon             INTEGER  REFERENCES salones (id) ON DELETE CASCADE
                                                          ON UPDATE CASCADE,
    FOREIGN KEY (
        id_tpo_prm_prestamo
    )
    REFERENCES tps_prm_prestamos (id),
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);

INSERT INTO prm_prestamos (
                              id,
                              id_tpo_prm_prestamo,
                              id_usuario,
                              fch_inicio,
                              fch_fin,
                              fch_creacion,
                              fch_modificacion,
                              fch_eliminacion,
                              id_est_prm_prestamos,
                              id_salon
                          )
                          VALUES (
                              1,
                              2,
                              36,
                              '2023-10-31 18:48:08.516438',
                              NULL,
                              '2023-10-31 18:48:08.516438',
                              NULL,
                              NULL,
                              2,
                              1
                          );


-- Tabla: profesores
DROP TABLE IF EXISTS profesores;

CREATE TABLE IF NOT EXISTS profesores (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT,
    id_usuario       INTEGER  REFERENCES usuarios (id) ON DELETE CASCADE
                                                       ON UPDATE CASCADE,
    nomina           INTEGER,
    fch_creacion     DATETIME DEFAULT (datetime('now') ),
    fch_modificacion DATETIME,
    fch_eliminacion  DATETIME,
    id_grupo         INTEGER  REFERENCES grupos (id) ON DELETE CASCADE
                                                     ON UPDATE CASCADE,
    FOREIGN KEY (
        id_usuario
    )
    REFERENCES usuarios (id) 
);


-- Tabla: salones
DROP TABLE IF EXISTS salones;

CREATE TABLE IF NOT EXISTS salones (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    id_division INTEGER REFERENCES divisiones (id) ON DELETE CASCADE
                                                   ON UPDATE CASCADE,
    nmr_salon   INTEGER,
    FOREIGN KEY (
        id_division
    )
    REFERENCES divisiones (id) 
);

INSERT INTO salones (
                        id,
                        id_division,
                        nmr_salon
                    )
                    VALUES (
                        1,
                        1,
                        23
                    );


-- Tabla: tps_mantenimiento
DROP TABLE IF EXISTS tps_mantenimiento;

CREATE TABLE IF NOT EXISTS tps_mantenimiento (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_mantenimiento (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  1,
                                  'Preventido'
                              );

INSERT INTO tps_mantenimiento (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  2,
                                  'Correctivo'
                              );

INSERT INTO tps_mantenimiento (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  3,
                                  'Predictivo'
                              );


-- Tabla: tps_prm_prestamos
DROP TABLE IF EXISTS tps_prm_prestamos;

CREATE TABLE IF NOT EXISTS tps_prm_prestamos (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  1,
                                  'Generado por un estudiante'
                              );

INSERT INTO tps_prm_prestamos (
                                  id,
                                  descripcion
                              )
                              VALUES (
                                  2,
                                  'Generado por un profesor'
                              );


-- Tabla: tps_usuarios
DROP TABLE IF EXISTS tps_usuarios;

CREATE TABLE IF NOT EXISTS tps_usuarios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    descripcion TEXT
);

INSERT INTO tps_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             0,
                             'Default'
                         );

INSERT INTO tps_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             1,
                             'Almacenista'
                         );

INSERT INTO tps_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             2,
                             'Estudiante'
                         );

INSERT INTO tps_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             3,
                             'Profesor'
                         );

INSERT INTO tps_usuarios (
                             id,
                             descripcion
                         )
                         VALUES (
                             4,
                             'Coordinador'
                         );


-- Tabla: usuarios
DROP TABLE IF EXISTS usuarios;

CREATE TABLE IF NOT EXISTS usuarios (
    id               INTEGER  PRIMARY KEY AUTOINCREMENT
                              NOT NULL
                              UNIQUE,
    id_tpo_usuario   INTEGER  REFERENCES tps_usuarios (id) ON DELETE CASCADE
                                                           ON UPDATE CASCADE
                              NOT NULL,
    id_est_usuario   INTEGER  NOT NULL
                              REFERENCES est_usuarios (id) ON DELETE CASCADE
                                                           ON UPDATE CASCADE
                                                           MATCH SIMPLE,
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
    REFERENCES tps_usuarios (id),
    FOREIGN KEY (
        id_est_usuario
    )
    REFERENCES est_usuarios (id) 
);

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         27,
                         1,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Lino',
                         'Murguia',
                         'Ponce',
                         X'4412817ceed7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         28,
                         2,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Oscar',
                         'Brandon',
                         'Pepenas',
                         X'08b39d9ceed7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         29,
                         3,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Mario',
                         NULL,
                         NULL,
                         X'd223bebfeed7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         30,
                         1,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Mario',
                         'Muro',
                         'Brandon',
                         X'a72b22cfeed7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         31,
                         1,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Lolazo',
                         'Gomez',
                         'Perez',
                         X'32a1e1f8eed7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         32,
                         2,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'Omar',
                         'Hernandez',
                         'Mendoza',
                         X'46654317efd7db08',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         33,
                         1,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'qw',
                         'qw',
                         'qw',
                         '2023-10-28 23:18:06.4453527',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         34,
                         2,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'as',
                         'as',
                         'as',
                         '2023-10-28 23:18:56.929927',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         35,
                         3,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'sd',
                         NULL,
                         NULL,
                         '2023-10-28 23:19:08.5826762',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         36,
                         2,
                         1,
                         X'30336163363734323136663365313563373631656531613565323535663036373935333632336338623338386234343539653133663937386437633834366634',
                         'josefina',
                         'si',
                         'gaylord',
                         '2023-10-28 23:46:24.4684003',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         37,
                         1,
                         1,
                         X'65336230633434323938666331633134396166626634633839393666623932343237616534316534363439623933346361343935393931623738353262383535',
                         '',
                         '',
                         '',
                         '2023-10-29 02:02:34.0061061',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         38,
                         1,
                         1,
                         X'32323730653733613836653530376637613939643938653733396136326639366563383132633161313962333761306462323737383565363230353138353636',
                         'Albert',
                         'Pena',
                         'Wachi',
                         '2023-10-29 17:43:33.9131477',
                         '2023-10-30 07:22:20.0506245',
                         NULL
                     );

INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         39,
                         2,
                         1,
                         X'61363635613435393230343232663964343137653438363765666463346662386130346131663366666631666130376539393865383666376637613237616533',
                         '20300688',
                         'ibarra',
                         'gael',
                         '2023-10-30 12:43:10.5266872',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (id, id_tpo_usuario, id_est_usuario, contrasena, nombre, apl_materno, apl_paterno, fch_creacion, fch_modificacion, fch_eliminacion) VALUES (40, 2, 1, X'61363635613435393230343232663964343137653438363765666463346662386130346131663366666631666130376539393865383666376637613237616533', 'Bruno', 'Padilla', 'S nchez', '2023-10-31 18:48:08.516438', NULL, NULL);
INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         41,
                         1,
                         1,
                         X'61363635613435393230343232663964343137653438363765666463346662386130346131663366666631666130376539393865383666376637613237616533',
                         'Juan',
                         'Fernandez',
                         'Vicente',
                         '2023-10-31 19:07:03.59727',
                         NULL,
                         NULL
                     );

INSERT INTO usuarios (id, id_tpo_usuario, id_est_usuario, contrasena, nombre, apl_materno, apl_paterno, fch_creacion, fch_modificacion, fch_eliminacion) VALUES (42, 3, 1, X'61363635613435393230343232663964343137653438363765666463346662386130346131663366666631666130376539393865383666376637613237616533', 'Sergio', 'D az', 'Ausente', '2023-10-31 19:07:31.2316955', NULL, NULL);
INSERT INTO usuarios (
                         id,
                         id_tpo_usuario,
                         id_est_usuario,
                         contrasena,
                         nombre,
                         apl_materno,
                         apl_paterno,
                         fch_creacion,
                         fch_modificacion,
                         fch_eliminacion
                     )
                     VALUES (
                         43,
                         1,
                         1,
                         X'36623836623237336666333466636531396436623830346566663561336635373437616461346561613232663164343963303165353264646237383735623462',
                         'Mario',
                         'Muro',
                         'Muro Ramos',
                         '2023-11-04 09:39:00.6943784',
                         NULL,
                         NULL
                     );


COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
