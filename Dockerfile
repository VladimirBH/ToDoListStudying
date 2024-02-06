FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ToDoList/ToDoList.csproj", "ToDoList/"]
RUN dotnet restore "ToDoList/ToDoList.csproj"
COPY . .
WORKDIR "/src/ToDoList"
RUN dotnet build "ToDoList.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ToDoList.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ToDoList.dll"]