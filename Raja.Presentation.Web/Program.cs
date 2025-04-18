using Raja.Infrastracture.Configuratin;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

RajaPersonelConfiguration.Configure(builder.Services, builder.Configuration.GetConnectionString("MainDb"));

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
