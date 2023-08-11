# CashFlow API

## Patterns Used In This Application

- [Domain Driven Design](https://balta.io/cursos/modelando-dominios-ricos)
- [Folder By Feature Structure](https://github.com/tfsantosbr/dotnet-folder-by-feature-structure)
- [CQRS + Mediator](https://balta.io/blog/aspnet-core-cqrs-mediator)
- [Repository](https://learning.eximia.co/videos/repositorios)

## Application Architecture Diagram

- [Database Diagram](https://viewer.diagrams.net/index.html?tags=%7B%7D&highlight=0000ff&edit=_blank&layers=1&nav=1&title=cashflow-app#R3VndcqIwGH0aL9sRCBQvLdp2Z9xpt%2B5Mt73ZiRAxbSRsiD%2F06TdAUDBR2xGtuzdOchIgOefLyZfYsrzp8pbBePKdBoi0zHawbFm9lmm6HUP8ZkBaAFcduwBChoMCMtbAEL8jCbYlOsMBSmodOaWE47gO%2BjSKkM9rGGSMLurdxpTUvxrDECnA0IdERZ9wwCdyWubVGr9DOJyUXzacTtEyhWVnOZNkAgO6qEBWv2V5jFJelKZLD5GMu5KX4rmbLa2rgTEU8Y88cDeHz%2Fb76w8vxS8vzE5eXAQu5GDnkMzkhOVgeVoywOgsClD2knbLul5MMEfDGPpZ60JILrAJnxJRM0RRHZQc5xwxjpYVSA7yFtEp4iwVXWRrR%2FKVlozK%2BmJNP3AlNqlSXz4IpeTh6tVrVkRBEvMJkkyFJK87vLsZ3D8JtPvwoFAmZsrrvCSc0TfkUUKZQCIaiZ7XY0zIBgQJDiNR9QV%2FSODXGW9YhGNXNkxxEGSf0QpRl2pMIz6Ug9JEy6eFcevC2KouhqXRxTqWLFcK7ygQa1dWKeMTGtIIkv4a3WBo3WdAaSylekWcp9KI4IzTupCCPpb%2Bks%2FnleescmmX1d6y2thLq7UHxLCYeyZsDm4VJaEz5qMdcwfSCiELEd%2FRT5ptRsxOiRkikON53fQaVwwoC%2BkJjfI19G2H7RgnsR0DbPiOa17aSoTrjAfYR6LLVujqQQ5HMEEt0yGZw4yYKIVZaZokf4hCothz4qzopwQLNpm1n8pRwftgtAKg%2FxbmatzPuHgNKi2tWCKG3Qz%2FwNng31HZdzTsu8eyF0O1ffg%2BYygbUh61MI7P1PmPsBxMoNq9bjEcze0Na6scQaZGgtgcC0r%2BW0WAvaGIczpFfrfR4LH%2FcwC79%2Fe9t5HN7x5fLwxFkB0m%2FuHcUSFEQ9tHc0dLQ5E2d2zERbQkOQpJHoFJMibiKCA3vnaX%2BRkzPs%2FD%2BSzjV5NLHiSUueH2lqvJJsFJo9lWqD%2FjdLKlS%2Bv2ppLaics0uppK6gk6Veq4a5S7zEa8BcfJtniukA6TuLgqGONlJl4TzmPaoBbQQLNfGrr8ZQU2TpmrUNajU4ijMyOus0Gcxgl0ln00x1avRLpxTIRvckxV7s7DnhvQwWpv6KA53%2Bvi93iGDL7CkBs01vLiaq%2BzXn2lsZajrMZ7npV4YstnlBDEEvW42Q1gzPOWw4%2FtB4WtAZx62HY0YQvUsD2a6xrOv5RH7LiWamYNlHf2e7ML80sXgXqWeUQxTTCnDKOvj3IA3L1R7p40ytXLkfO%2BmzqIfsesn1Z0OUpDd1Oiuv5LKG%2Br%2FK9m9f8C)

## Applying Development Certifications

Necessary for run application in HTTPS, locally and docker

- [ASP.NET With Docker and HTTPS](https://josiahmortenson.dev/blog/2020-06-08-aspnetcore-docker-https)

Run this commands to apply development certifications:

```bash
dotnet dev-certs https --clean
dotnet dev-certs https -ep $USERPROFILE/.aspnet/https/aspnetapp.pfx -p dev@123
dotnet dev-certs https --trust
```

## Migrations

You will need [.NET EF Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) to run this commands

```bash
# add migration
dotnet ef migrations add {MIGRATION_NAME} -p src/CashFlow.Infrastructure/ -c CashFlowContext -s src/CashFlow.Api -o Migrations

# remove migration
dotnet ef migrations remove -p src/CashFlow.Infrastructure/ -c CashFlowContext -s src/CashFlow.Api

# update database
dotnet ef database update -p src/CashFlow.Infrastructure -c CashFlowContext -s src/CashFlow.Api

# generate scripts for manual database update
dotnet ef migrations script -p src/CashFlow.Infrastructure/ -c CashFlowContext -s src/CashFlow.Api -o ./scripts/migrations.sql
```

## Running API Locally

You will need [.NET CLI](https://dotnet.microsoft.com/en-us/download) to run this commands

```bash
dotnet restore
dotnet build
dotnet run --project src/CashFlow.Api
```

## Running Docker Infrastructure Dependencies

You will need [Docker Desktop](https://docs.docker.com/desktop/install/windows-install/) to run this commands

```bash
docker-compose up -d
```

## Accessing API

- Docker -> https://localhost:8001/swagger/index.html
- Locally ->  https://localhost:7198/swagger/index.html