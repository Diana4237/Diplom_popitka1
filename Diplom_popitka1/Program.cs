using Microsoft.AspNetCore.Hosting;
using Diplom_popitka1;
using System;
using System.Linq;
using Diplom_popitka1.Models;

var builder = WebApplication.CreateBuilder(args);

var startup = new DB(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment, app.Services.CreateScope().ServiceProvider);

app.Run();