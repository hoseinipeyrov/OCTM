FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OCTM.Services.Api/OCTM.Services.Api.csproj", "OCTM.Services.Api/"]
RUN dotnet restore "OCTM.Services.Api/OCTM.Services.Api.csproj"
COPY . .
WORKDIR "/src/OCTM.Services.Api"
RUN dotnet build "OCTM.Services.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OCTM.Services.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OCTM.Services.Api.dll"]
