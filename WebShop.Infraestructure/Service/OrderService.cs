using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.DTO;
using WebShop.Core.Entity;
using WebShop.Core.Interfaces.Repository;
using WebShop.Core.Interfaces.Service;

namespace WebShop.Infraestructure.Service
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository, 
                            IRepository<OrderDetail> orderDetailRepository,
                            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDto> CreateOrderAsync(ProcessOrderDto processOrderDto)
        {
            // Crear la entidad Order
            var order = new Order
            {
                CustomerID = processOrderDto.CustomerID,
                OrderDate = DateTime.UtcNow
            };

            // Guardar la orden en la base de datos
            await _orderRepository.AddAsync(order);

            // Crear y guardar los detalles de la orden
            var orderDetailsTasks = processOrderDto.CartItems.Select(async item => new OrderDetail
            {
                OrderID = order.OrderID,
                ProductID = item.ProductId,
                Quantity = item.Quantity,
                PriceAtOrderTime = await GetProductPrice(item.ProductId) 
            }).ToList();
            var orderDetails = await Task.WhenAll(orderDetailsTasks);
            await _orderDetailRepository.AddRange(orderDetails.ToList());

            // Convertir a DTO para retornar
            var orderDto = new OrderDto
            {
                OrderID = order.OrderID,
                CustomerID = order.CustomerID,
                OrderDate = order.OrderDate,
                OrderDetails = orderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    Quantity = od.Quantity,
                    PriceAtOrderTime = od.PriceAtOrderTime
                }).ToList()
            };

            return orderDto;
        }

   
        private async Task<decimal> GetProductPrice(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception($"Product with ID {productId} not found.");
            }
            return product.Price;
        
        }

       
    }
}