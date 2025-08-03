using namespace System.IO;

$POSTGRES_VOLUME = "pg_data"
$RABBITMQ_VOLUME = "rabbitmq_data"

$root = (Get-Item .).FullName

$pgPath = [System.IO.Path]::Combine($root, $POSTGRES_VOLUME)
if (-not [Directory]::Exists($pgPath)) 
{
  [Directory]::CreateDirectory($pgPath) | Out-Null
}

$rabbitmqPath = [System.IO.Path]::Combine($root, $RABBITMQ_VOLUME)
if (-not [Directory]::Exists($rabbitmqPath)) 
{
  [Directory]::CreateDirectory($rabbitmqPath) | Out-Null
}

docker compose --env-file .env.docker -f docker-compose.yml up -d
