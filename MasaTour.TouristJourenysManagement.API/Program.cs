
var builder = WebApplication.CreateBuilder(args);
await builder.Services.AddAPIDependencies(builder.Configuration);
var app = builder.Build();
Startup.Build(app);
