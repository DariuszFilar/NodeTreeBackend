using Microsoft.OpenApi.Models;
using NodeTree.API.Handlers;
using NodeTree.API.Handlers.Commands;
using NodeTree.API.Handlers.Queries;
using NodeTree.DB;
using NodeTree.INFRASTRUCTURE;
using NodeTree.INFRASTRUCTURE.Middleware;
using NodeTree.INFRASTRUCTURE.Repositories.Abstract;
using NodeTree.INFRASTRUCTURE.Repositories.Concrete;
using NodeTree.INFRASTRUCTURE.Requests;
using NodeTree.INFRASTRUCTURE.Responses;
using NodeTree.INFRASTRUCTURE.Services.Abstract;
using NodeTree.INFRASTRUCTURE.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.ParameterFilter<DefaultValueParameterFilter>();
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<NodeTreeDbContext>();
builder.Services.AddScoped<NodeTreeSeeder>();
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<ITreeRepository, TreeRepository>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<IExceptionLogRepository, ExceptionLogRepository>();
builder.Services.AddScoped<IExceptionLogService, ExceptionLogService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IRequestHandler<CreateNodeRequest, CreateNodeResponse>, CreateNodeHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteNodeRequest, DeleteNodeResponse>, DeleteNodeHandler>();
builder.Services.AddScoped<IRequestHandler<RenameNodeRequest, RenameNodeResponse>, RenameNodeHandler>();
builder.Services.AddScoped<IRequestHandler<GetTreeRequest, GetTreeResponse>, GetTreeHandler>();
builder.Services.AddScoped<IRequestHandler<GetSingleExceptionLogRequest, GetSingleExceptionLogResponse>, GetSingleExceptionLogHandler>();
builder.Services.AddScoped<IRequestWithSkipAndTakeHandler<GetRangeExceptionLogRequest, GetRangeExceptionLogResponse>, GetRangeExceptionLogHandler>();
var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<NodeTreeSeeder>();

seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TreeNode API");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
