using AcopioExpress.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ineyccion de las depedencias que tenemos en la capa ioc
builder.Services.InyectarDependencias(builder.Configuration);

//configuracion de cors
builder.Services.AddCors(options => {
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

//aqui ya estamos utilizando el cors que se declaro en la parte superior
app.UseCors("NuevaPolitica");
 
app.Run();
