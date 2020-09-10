FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/IConsumer.Microservices.IamMicroservice.Admin.Api/IConsumer.Microservices.IamMicroservice.Admin.Api.csproj", "src/IConsumer.Microservices.IamMicroservice.Admin.Api/"]
COPY ["src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.Shared/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.Shared.csproj", "src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.Shared/"]
COPY ["src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer.csproj", "src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.SqlServer/"]
COPY ["src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL.csproj", "src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.MySql/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.MySql.csproj", "src/IConsumer.Microservices.IamMicroservice.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/IConsumer.Microservices.IamMicroservice.Admin.Api/IConsumer.Microservices.IamMicroservice.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/IConsumer.Microservices.IamMicroservice.Admin.Api"
RUN dotnet build "IConsumer.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IConsumer.Microservices.IamMicroservice.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "IConsumer.Microservices.IamMicroservice.Admin.Api.dll"]