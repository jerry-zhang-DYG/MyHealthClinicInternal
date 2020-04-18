FROM microsoft/aspnetcore-build:1.0-2.0 AS build-env
WORKDIR /app

# Copy everything because the CSPROJ's are deep
COPY . ./
RUN dotnet restore ./MHC_ASPNetCore.sln
RUN dotnet publish ./MHC_ASPNetCore.sln -c Release -o out

FROM microsoft/aspnetcore:1.0
WORKDIR /app
COPY --from=build-env /app/src/MyHealth.Web/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "MyHealth.Web.dll"]
