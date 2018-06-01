FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY IoC.TasksList/IoC.TasksList.csproj IoC.TasksList/
RUN dotnet restore IoC.TasksList/IoC.TasksList.csproj
COPY . .
WORKDIR /src/IoC.TasksList
RUN dotnet build IoC.TasksList.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish IoC.TasksList.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IoC.TasksList.dll"]
