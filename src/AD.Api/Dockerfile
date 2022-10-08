FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5188/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AD.Api/AD.Api.csproj", "src/AD.Api/"]
COPY ["src/AD.Business/AD.Business.csproj","src/AD.Business/"]
COPY ["src/AD.Business.Services/AD.Business.Services.csproj","ssrc/AD.Business.Services/"]
COPY ["src/AD.Commons/AD.Commons.csproj","src/AD.Commons/"]
COPY ["src/AD.Persistence.DataAccess/AD.Persistence.DataAccess.csproj","src/AD.Persistence.DataAccess/"]
COPY ["src/AD.Persistence.Domain/AD.Persistence.Domain.csproj","src/AD.Persistence.Domain/"]
COPY . .
RUN dotnet restore "src/AD.Api/AD.Api.csproj"

WORKDIR "/src/src/AD.Api"
RUN dotnet build "AD.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AD.Api.csproj" -c Release -o /app/publish

FROM base AS final
RUN apt-get update && apt-get install -y iputils-ping
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AD.Api.csproj"] 