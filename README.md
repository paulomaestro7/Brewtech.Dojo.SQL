1 - Iniciar o powershell

2 - Navegar até a pasta do projeto que contém o docker-compose
No meu caso está na pasta "C:\TuDu\Repository\Brewtech.Dojo.SQL\Brewtech.Dojo.SQL"

3 - Copiar o comando "docker-compose up -d" e colocar no powershell

Aqui o docker vai subir nossos containers para utilizar o Postgres e o PGAdmin ;-) 

Ao finalizar o comando, vai estar disponível para acesso o PGAdmin através do navegador no endereço "localhost:7777"


Gerador após ter criado o banco de dados
Scaffold-DbContext "Host=localhost;Port=25432;Database=DojoSQL;Username=postgres;Password=Dojo2021!" Npgsql.EntityFrameworkCore.PostgreSQL -v

Criar o banco de dados e as tabelas de acordo com o DER