CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE clientes (
    id uuid NOT NULL,
    bairro text NOT NULL,
    cidade text NOT NULL,
    uf character varying(2) NOT NULL,
    logradouro text NOT NULL,
    numero text NOT NULL,
    cep text NOT NULL,
    nome text NOT NULL,
    data_criacao timestamp with time zone NOT NULL,
    CONSTRAINT "PK_clientes" PRIMARY KEY (id)
);

CREATE TABLE usuarios (
    id uuid NOT NULL,
    login text NOT NULL,
    senha text NOT NULL,
    tipo_usuario integer NOT NULL,
    nome text NOT NULL,
    data_criacao timestamp with time zone NOT NULL,
    CONSTRAINT "PK_usuarios" PRIMARY KEY (id)
);

CREATE TABLE chamados (
    id uuid NOT NULL,
    titulo text NOT NULL,
    descricao text NOT NULL,
    data_prevista timestamp with time zone NOT NULL,
    data_criacao timestamp with time zone NOT NULL,
    tipo integer NOT NULL,
    id_criador uuid NOT NULL,
    id_responsavel uuid NOT NULL,
    id_cliente uuid NOT NULL,
    status integer NOT NULL,
    CONSTRAINT "PK_chamados" PRIMARY KEY (id),
    CONSTRAINT "FK_chamados_clientes_id_cliente" FOREIGN KEY (id_cliente) REFERENCES clientes (id) ON DELETE CASCADE,
    CONSTRAINT "FK_chamados_usuarios_id_criador" FOREIGN KEY (id_criador) REFERENCES usuarios (id) ON DELETE CASCADE,
    CONSTRAINT "FK_chamados_usuarios_id_responsavel" FOREIGN KEY (id_responsavel) REFERENCES usuarios (id) ON DELETE CASCADE
);

CREATE TABLE historicos_chamados (
    id uuid NOT NULL,
    anotacao text NOT NULL,
    id_usuario uuid NOT NULL,
    data_ocorrencia timestamp with time zone NOT NULL,
    id_chamado uuid NOT NULL,
    CONSTRAINT "PK_historicos_chamados" PRIMARY KEY (id),
    CONSTRAINT "FK_historicos_chamados_chamados_id_chamado" FOREIGN KEY (id_chamado) REFERENCES chamados (id) ON DELETE CASCADE,
    CONSTRAINT "FK_historicos_chamados_usuarios_id_usuario" FOREIGN KEY (id_usuario) REFERENCES usuarios (id) ON DELETE CASCADE
);

CREATE TABLE tempo_gasto (
    id uuid NOT NULL,
    tempo_gasto interval NOT NULL,
    atividade text NOT NULL,
    data_criacao timestamp with time zone NOT NULL,
    id_chamado uuid NOT NULL,
    CONSTRAINT "PK_tempo_gasto" PRIMARY KEY (id),
    CONSTRAINT "FK_tempo_gasto_chamados_id_chamado" FOREIGN KEY (id_chamado) REFERENCES chamados (id) ON DELETE CASCADE
);

CREATE INDEX "IX_chamados_id_cliente" ON chamados (id_cliente);

CREATE INDEX "IX_chamados_id_criador" ON chamados (id_criador);

CREATE INDEX "IX_chamados_id_responsavel" ON chamados (id_responsavel);

CREATE INDEX "IX_historicos_chamados_id_chamado" ON historicos_chamados (id_chamado);

CREATE INDEX "IX_historicos_chamados_id_usuario" ON historicos_chamados (id_usuario);

CREATE INDEX "IX_tempo_gasto_id_chamado" ON tempo_gasto (id_chamado);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20221030030706_Primeira_migracao', '6.0.10');

COMMIT;

