 -- Criar o schema 'projects' caso não exista
 CREATE SCHEMA IF NOT EXISTS projects;

-- Criar a tabela 'projects.tbl_projects' caso não exista
\i database/schemas/projects/tables/tbl_projects.sql

-- Criar a tabela 'projects.tbl_project_users' caso não exista
\i database/schemas/projects/tables/tbl_project_users.sql

-- Criar a tabela 'projects.tbl_project_invites' caso não exista
\i database/schemas/projects/tables/tbl_project_invites.sql

-- Criar a tabela 'projects.tbl_project_tasks' caso não exista
\i database/schemas/projects/tables/tbl_tasks.sql

-- Criar a tabela 'projects.tbl_task_regist' caso não exista
\i database/schemas/projects/tables/tbl_task_regist.sql

-- Criar View de Resumo de Horas por Projeto
\i database/schemas/projects/views/vw_project_hours_summary.sql

-- Criar View de Progresso de Tarefas por Projeto
\i database/schemas/projects/views/vw_project_task_progress.sql

-- Criar View de Tarefas por Usuário
\i database/schemas/projects/views/vw_user_project_hours.sql