# readme

Перед запуском стори изменить настройки в ".env.docker" файле подходящим образом (например, PGADMIN_DEFAULT_EMAIL, PGADMIN_DEFAULT_PASSWORD).

Для запуска нужно

1. открыть консоль, перейти в директорию где лежит данный readme.md файл.

2. Команда для запуска.

```ps1
docker compose --env-file .env.docker -f docker-compose.yml up -d
```

Или если открыта PowerShell консоль запустить файл ./start.ps1

```sp1
./start.ps1
```

Проверял под windows с установленным Docker Desktop.
