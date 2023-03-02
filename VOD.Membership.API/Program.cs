using Microsoft.EntityFrameworkCore;
using VOD.common.DTOs;
using VOD.Membership.Data.Context;
using VOD.Membership.Data.Entities;
using VOD.Membership.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Policies go here
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
        opt.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IDbService, VOD_Service>();

// Automapper config
var MapConfig = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap()
        .ForMember(dest => dest.Films, src => src.Ignore());
    cfg.CreateMap<Film, FilmDTO>()
        .ReverseMap()
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());
    cfg.CreateMap<Genre, GenreDTO>()
        .ReverseMap()
        .ForMember(dest => dest.Films, src => src.Ignore());
});

var mapper = MapConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VOD_Context>(
    options => options
    .UseSqlServer(
        builder.Configuration
        .GetConnectionString("VODConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsAllAccessPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
