1 - Iniciar o powershell

2 - Navegar at� a pasta do projeto que cont�m o docker-compose
No meu caso est� na pasta "C:\TuDu\Repository\Brewtech.Dojo.SQL\Brewtech.Dojo.SQL"

3 - Copiar o comando "docker-compose up -d" e colocar no powershell

Aqui o docker vai subir nossos containers para utilizar o Postgres e o PGAdmin ;-) 

Ao finalizar o comando, vai estar dispon�vel para acesso o PGAdmin atrav�s do navegador no endere�o "localhost:7777"


Gerador ap�s ter criado o banco de dados
Scaffold-DbContext "Host=localhost;Port=25432;Database=DojoSQL;Username=postgres;Password=Dojo2021!" Npgsql.EntityFrameworkCore.PostgreSQL -v

Criar o banco de dados e as tabelas de acordo com o DER