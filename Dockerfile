# Define an image for BUILD environment
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as BUILD

# Define work directory
WORKDIR /build

# Copy all content
COPY . .

# Add packages
RUN apk update \
    && apk add grpc-plugins

# Set environment variables for the tools
ENV PROTOBUF_PROTOC=/usr/bin/protoc
ENV GRPC_PROTOC_PLUGIN=/usr/bin/grpc_csharp_plugin

# Restore and build application
RUN dotnet restore
RUN dotnet build Poc.Net.Grpc -r linux-musl-x64 -p:PublishReadyToRun=true -p:PublishSingleFile=true --self-contained true -c Release -o /app

# Defines an image for RUNTIME environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS RUNTIME

# Add needed packages
RUN apk add --no-cache icu-libs 

# Defines the work directory
WORKDIR /app

# Expose ports
#ENV ASPNETCORE_URLS=https://+:8080

# Defines globalization invariant to FALSE
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Copy builded files to runtime workdir
COPY --from=BUILD /app .

ENTRYPOINT ["./Poc.Net.Grpc"]
