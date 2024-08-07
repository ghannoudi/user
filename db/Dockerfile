# Use the official Microsoft SQL Server image as a base
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=YourStrong!Passw0rd
ENV MSSQL_PID=Express

USER root

# Expose the SQL Server port
EXPOSE 1433

# Start SQL Server
CMD /opt/mssql/bin/sqlservr
