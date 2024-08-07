using emprestimo_livro.Database;
using emprestimo_livro.Repositories;
using emprestimo_livro.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<EmprestimoDbContext>(
        options => options.UseMySql(connectionString, serverVersion)
    );

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

