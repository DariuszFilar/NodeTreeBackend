using NodeTree.API.Handlers.Commands;
using NodeTree.DB;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Repositories.Concrete;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<NodeTreeDbContext>();
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<IRequestHandler<CreateNodeRequest, CreateNodeResponse>, CreateNodeHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
