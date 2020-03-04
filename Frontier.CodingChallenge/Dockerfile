#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Frontier.CodingChallenge/Frontier.CodingChallenge.csproj", "Frontier.CodingChallenge/"]
RUN dotnet restore "Frontier.CodingChallenge/Frontier.CodingChallenge.csproj"
COPY . .
WORKDIR "/src/Frontier.CodingChallenge"
RUN dotnet build "Frontier.CodingChallenge.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Frontier.CodingChallenge.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Frontier.CodingChallenge.dll"]