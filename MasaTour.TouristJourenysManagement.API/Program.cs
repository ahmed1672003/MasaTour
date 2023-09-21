
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAPIDependencies(builder.Configuration);

var app = builder.Build();
Startup.Build(app);
