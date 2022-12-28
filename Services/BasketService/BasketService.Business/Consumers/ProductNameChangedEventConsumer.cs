using BasketService.DataAccess.Concrete.EntityFramework;
using EventBusMessages.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketService.Business.Consumers
{
    public class ProductNameChangedEventConsumer : IConsumer<ProductNameChangedEvent>
    {
        private readonly BasketDbContext _context;

        public ProductNameChangedEventConsumer(BasketDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ProductNameChangedEvent> context)
        {
            var basketItem = await _context.BasketItems.Where(x => x.ProductId == context.Message.ProductId).ToListAsync();

            foreach (var item in basketItem)
            {
                item.ProductName = context.Message.UpdatedName;
            }
            await _context.SaveChangesAsync();

        }

        
    }
}
