using NodeTree.DB;
using NodeTree.DB.Repositories.Abstract;
using NodeTree.DB.Repositories.Concrete;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<NodeTreeDbContext>();
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<INodeService, NodeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
