FROM mcr.microsoft.com/dotnet/core/sdk:3.0

WORKDIR /app

COPY . ./

# this version would compile when each container starts -
# waste of time
# CMD [ "dotnet", "run" ]

# RUN command: run some shell commands (bash usually)
RUN dotnet build -c Release

RUN dotnet publish -c Release -o publish

WORKDIR /app/publish

# if you get an error about "unrecognized dotnet command"
# that just means you mistyped the name of your dll here
CMD [ "dotnet", "ContainerizedConsoleBuild.dll" ]
