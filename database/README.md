# Base de dados - ES2

Este é o local onde será desenvolvido o código para a criação da base de dados do projeto.

## 🚀 Como Executar os Seeds

### **1️⃣ Certificar-se de que o Docker está em execução**
Se estiveres a usar o PostgreSQL dentro de um contêiner Docker, verifica se ele está rodando:
```sh
docker ps
```
Se o contêiner não estiver ativo, inicia-o com:
```sh
docker-compose up -d
```

### **2️⃣ Executar Todos os Seeds**
Agora, basta executar o seguinte comando para criar todas as tabelas dentro do schema auth:
```sh
docker exec -it gooddoctor-postgres psql -U gooddoctor_user -d gooddoctor_db_dev -f /database/seeds/development/seed_all.sql
```

### **2️⃣ Executar os Seeds Individualmente (Opcional)**
Se quiseres rodar apenas um seed específico, usa:
```sh
docker exec -it gooddoctor-postgres psql -U gooddoctor_user -d gooddoctor_db_dev -f /database/seeds/development/insert_tbl_users.sql
```
