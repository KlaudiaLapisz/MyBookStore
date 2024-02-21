using Microsoft.EntityFrameworkCore;
using MyBookStore.DAL;
using MyBookStore.Repositories;
using MyBookStore.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["sqllServer:connectionString"];
builder.Services.AddDbContext<MyBookStoreDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookGenreRepository, BookGenreRepository>();
builder.Services.AddScoped<IBookGenreService, BookGenreService>();
builder.Services.AddScoped<IPublishingHouseRepository, PublishingHouseRepository>();
builder.Services.AddScoped<IPublishingHouseService, PublishingHouseService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IBorrowRepository, BorrowRepository>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
