using Microsoft.EntityFrameworkCore;
using ProductsApi.Application.Stories.Categories;
using ProductsApi.Application.Stories.Products;
using ProductsApi.Domain.Interfaces;
using ProductsApi.Infrastructure.Data;
using ProductsApi.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Database
builder.Services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Stories
builder.Services.AddScoped<GetProducts>();
builder.Services.AddScoped<GetProductById>();
builder.Services.AddScoped<SearchProducts>();
builder.Services.AddScoped<GetCategories>();
builder.Services.AddScoped<GetProductsByCategory>();

// CORS
builder.Services.AddCors(opts =>
    opts.AddPolicy("RNPOLICY", p => 
        p.WithOrigins("http://localhost:8081")
         .AllowAnyMethod()
         .AllowAnyHeader()
    )
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "Products API", Version = "v1" });
});

var app = builder.Build();
// Middleware Pipeline
app.UseExceptionHandler(err => err.Run(async ctx => {
    ctx.Response.StatusCode = 500;
    ctx.Response.ContentType = "application/json";
    await ctx.Response.WriteAsJsonAsync(new { message = "An unexpected error occurred." });
}));


app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("RNPolicy");
app.MapControllers();

// Apply migrations on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();    
}

app.Run();



