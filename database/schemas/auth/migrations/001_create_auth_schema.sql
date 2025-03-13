-- Criar o schema 'auth' caso não exista
CREATE SCHEMA IF NOT EXISTS auth;

-- Criar a tabela 'auth.tbl_users' caso não exista
\i database/schemas/auth/tables/tbl_users.sql