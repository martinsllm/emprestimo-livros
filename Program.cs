using emprestimo_livro.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<EmprestimoDbContext>(
        options => options.UseMySql(connectionString, serverVersion)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

