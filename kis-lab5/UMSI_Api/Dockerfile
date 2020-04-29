FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
COPY ["UMIS.BLL.Models/UMIS.BLL.Contracts.xml", "./"]
COPY ["UMIS.Api/UMIS.Api.xml", "./"]
COPY ["Common/Common.xml", "./"]

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UMIS.Api/UMIS.Api.csproj", "UMIS.Api/"]
COPY ["UMIS.BLL.ApplicationServices/UMIS.DbSeed.csproj", "UMIS.BLL.ApplicationServices/"]
COPY ["UMIS.DAL.Domain.Models/UMIS.DAL.Domain.Contracts.csproj", "UMIS.DAL.Domain.Models/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["StartUpExtensions/StartUpExtensions.csproj", "StartUpExtensions/"]
COPY ["UMIS.DAL.Domain/UMIS.DAL.Domain.csproj", "UMIS.DAL.Domain/"]
COPY ["TokenService/TokenAuthentication.csproj", "TokenService/"]
COPY ["UMIS.DAL.DomainAuth/UMIS.DAL.DomainAuth.csproj", "UMIS.DAL.DomainAuth/"]
COPY ["UMIS.BLL.AppServices/UMIS.BLL.AppServices.csproj", "UMIS.BLL.AppServices/"]
COPY ["UMIS.BLL.Models/UMIS.BLL.Contracts.csproj", "UMIS.BLL.Models/"]
COPY ["UMIS.DAL.RepositoriesAbstraction/UMIS.DAL.Repositories.csproj", "UMIS.DAL.RepositoriesAbstraction/"]
RUN dotnet restore "UMIS.Api/UMIS.Api.csproj"
COPY . .
WORKDIR "/src/UMIS.Api"
RUN dotnet build "UMIS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UMIS.Api.csproj" -c Release -o /app/publish

FROM base AS final
ARG -seed
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS http://*:5000
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UMIS.Api.dll"]