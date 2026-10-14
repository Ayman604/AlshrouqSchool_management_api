using AlshrouqSchool.Api.Controllers;
using AlshrouqSchool.Application.Features.Gallery.Mapping;
using AlshrouqSchool.Core.Interfaces;
using AlshrouqSchool.Domain.Contracts;
using AlshrouqSchool.Presistence.Data.DbContexts;
using AlshrouqSchool.Presistence.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MediatR;
using AlshrouqSchool.Application.Features.Gallery.Behaviors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddApplicationPart(typeof(PostsController).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AlshrouqDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(GalleryMappingProfile).Assembly));
builder.Services.AddAutoMapper(typeof(GalleryMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(GalleryMappingProfile).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();
if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();