# Auth Schema

Este schema é responsável por toda a gestão de autenticação e autorização do sistema.

Inclui:
- `functions`: Funções para gestão de autenticação e permissões
- `indexes`: Índices para otimização de consultas de autenticação
- `migrations`: Migrações específicas do schema de autenticação
- `tables`: Definições das tabelas de usuários, roles e permissões
- `triggers`: Triggers para automação de processos de autenticação
- `views`: Views para consultas relacionadas a autenticação


## 🚀 Como Montar o Schema `auth`

Para criar e configurar o schema `auth`, siga os passos abaixo:

### **1️⃣ Certificar-se de que o Docker está em execução**
Se estiveres a usar o PostgreSQL dentro de um contêiner Docker, verifica se ele está rodando:
```sh
docker ps
```
Se o contêiner não estiver ativo, inicia-o com:
```sh
docker-compose up -d
```

### **2️⃣ Executar a Migração do Schema**
Agora, basta executar o seguinte comando para criar todas as tabelas dentro do schema auth:
```sh
docker exec -it freelance_manager-postgres psql -U es2_user -d freelancemanager_db_dev -f /database/schemas/auth/migrations/001_create_auth_schema.sql
```

### **3️⃣ Verificar se as Tabelas Foram Criadas**
Dentro do psql, verifica as tabelas do schema auth:

```sql
SELECT table_name FROM information_schema.tables WHERE table_schema = 'auth';
```

### **4️⃣ Atualizar as Migrações Sempre que Houver Mudanças**
Se precisares adicionar ou modificar tabelas, basta editar os arquivos dentro da pasta `database/schemas/auth/` e depois rodar novamente o script de migração:
```sh
docker exec -it freelance_manager-postgres psql -U es2_user -d freelancemanager_db_dev -f /database/schemas/auth/migrations/001_create_auth_schema.sql
```
Agora o schema **auth** está pronto para ser utilizado! 🚀🔥


