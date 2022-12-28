using BasketService.Business.Abstract;
using BasketService.Business.Concrete;
using BasketService.Business.Consumers;
using BasketService.DataAccess.Abstract;
using BasketService.DataAccess.Concrete.EntityFramework;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProductNameChangedEventConsumer>();
    // Default Port : 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        
        cfg.ReceiveEndpoint("product-name-changed-event-order-service", e =>
        {
            e.ConfigureConsumer<ProductNameChangedEventConsumer>(context);
        });
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BasketDbContext>();

builder.Services.AddScoped<IBasketDal, BasketDal>();
builder.Services.AddScoped<IBasketService, BasketManager>();


builder.Services.AddScoped<IBasketItemDal, BasketItemDal>();
builder.Services.AddScoped<IBasketItemService, BasketItemManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
