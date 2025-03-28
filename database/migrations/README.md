# Migrations

Este diretório contém os scripts de migração da base de dados. As migrações são usadas para:
- Controlar as alterações no esquema da base de dados
- Manter um histórico de mudanças
- Permitir rollback de alterações quando necessário

O diretório `versions` contém as diferentes versões das migrações aplicadas.

## 🚀 Como Montar a Migration

Siga os passos abaixo:

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
Agora, basta executar o seguinte comando para criar todas as tabelas do migration:
```sh
docker exec -it freelance_manager-postgres psql -U es2_user -d freelancemanager_db_dev -f /database/migrations/<nome>.sql
```

### **3️⃣ Verificar se as Tabelas Foram Criadas**
Dentro do psql, verifica as tabelas do schema auth:

```sql
SELECT table_name FROM information_schema.tables WHERE table_schema = 'schema_name';
```
Agora o schema **auth** está pronto para ser utilizado! 🚀🔥