using Application.DIServiceExtension;
using Infrastrcture.DIServiceExtension;
using Persistance.DIServiceExtension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddPersistance();
builder.Services.AddInfrastrcture();

var app = builder.Build();


app.Run();
