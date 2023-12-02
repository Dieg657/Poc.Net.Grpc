using Microsoft.OpenApi.Models;
using Poc.Net.Grpc.Interceptors;
using Poc.Net.Grpc.Services;
using Poc.Net.Grpc.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc(opt =>
{
    opt.Interceptors.Add<ServerLoggerInterceptor>();
}).AddJsonTranscoding();
builder.Services.AddGrpcSwagger();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poc.Net.Grpc", Version = "v1" });
});
builder.Services.RegisterContainer(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poc.Net.Grpc");
});
app.MapGrpcService<EmployeeGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
