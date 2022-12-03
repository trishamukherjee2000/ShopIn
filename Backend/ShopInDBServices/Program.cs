var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p=>p.AddPolicy("corspolicy", build=>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//enable single domain
//multiple domain
//any domain


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
//.AllowAnyOrigin()
//.AllowAnyMethod()
//.AllowAnyHeader()
//.AllowCredentials()



app.UseAuthorization();

app.MapControllers();

app.Run();
