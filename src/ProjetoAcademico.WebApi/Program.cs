using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Domain.Interfaces.Services;
using ProjetoAcademico.Domain.Services;
using ProjetoAcademico.Infra.Data.Context;
using ProjetoAcademico.Infra.Data.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceCurso, ServiceCurso>();
builder.Services.AddScoped<IRepositoryCurso, RepositoryCurso>();

//ProjetoAcademicoConnection
builder.Services.AddDbContext<ProjetoAcademicoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProjetoAcademicoConnection"));

});

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters
    .Add(new JsonStringEnumConverter()));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

// =====================CURSO=========================
// Adicionar 
app.MapPost("/adicionar", ([FromServices] IServiceCurso serviceCurso, CursoAdicionarDto cursoAdicionarDto) =>
{
    var response = serviceCurso.Adicionar(cursoAdicionarDto);
    return response.Sucesso ? Results.Created("created", response) : Results.BadRequest(response);
})
.WithTags("Curso");

// Listar
app.MapGet("/listar", ([FromServices] IServiceCurso serviceCurso) =>
{
    var response = serviceCurso.Listar();
    return Results.Ok(response);
})
.WithTags("Curso");

// Obter
app.MapGet("/obter/{id:guid}", ([FromServices] IServiceCurso serviceCurso, Guid id) =>
{
    var response = serviceCurso.Obter(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");

// Atualizar
app.MapPut("/atualizar", ([FromServices] IServiceCurso serviceCurso, CursoAtualizarDto cursoAtualizarDto) =>
{
    var response = serviceCurso.Atualizar(cursoAtualizarDto);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");

// Remover
app.MapDelete("/remover/{id:guid}", ([FromServices] IServiceCurso serviceCurso, Guid id) =>
{
    var response = serviceCurso.Remover(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");


// =====================PROFESSOR=========================

// Adicionar 
app.MapPost("/adicionarprof", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAdicionarDto professorAdicionarDto) =>
{
    var response = serviceProfessor.Adicionar(professorAdicionarDto);
    return response.Sucesso ? Results.Created("created", response) : Results.BadRequest(response);
})
.WithTags("Professor");

// Listar
app.MapGet("/listarprof", ([FromServices] IServiceProfessor serviceProfessor) =>
{
    var response = serviceProfessor.Listar();
    return Results.Ok(response);
})
.WithTags("Professor");

// Obter
app.MapGet("/obterprof/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Obter(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

// Atualizar
app.MapPut("/atualizarprof", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAtualizarDto professorAtualizarDto) =>
{
    var response = serviceProfessor.Atualizar(professorAtualizarDto);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

// Remover
app.MapDelete("/removerprof/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Remover(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");


app.UseHttpsRedirection();

app.Run();
