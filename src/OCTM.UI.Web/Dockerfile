FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OCTM.UI.Web/OCTM.UI.Web.csproj", "OCTM.UI.Web/"]
RUN dotnet restore "OCTM.UI.Web/OCTM.UI.Web.csproj"
COPY . .
WORKDIR "/src/OCTM.UI.Web"
RUN dotnet build "OCTM.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OCTM.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OCTM.UI.Web.dll"]
