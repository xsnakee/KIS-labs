FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["UMIS.CommonApi/UMIS.CommonApi.csproj", "UMIS.CommonApi/"]
RUN dotnet restore "UMIS.CommonApi/UMIS.CommonApi.csproj"
COPY . .
WORKDIR "/src/UMIS.CommonApi"
RUN dotnet build "UMIS.CommonApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "UMIS.CommonApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "UMIS.CommonApi.dll"]