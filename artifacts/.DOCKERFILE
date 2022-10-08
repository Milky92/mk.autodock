FROM mcr.microsoft.com/dotnet/sdk:6.0 
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
RUN ["dotnet","build"]
RUN ["dotnet","test"]
EXPOSE 5188/tcp
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
