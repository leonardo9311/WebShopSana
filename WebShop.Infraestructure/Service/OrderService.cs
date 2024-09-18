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
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderService(IRepository<Order> orderRepository, 
                            IRepository<OrderDetail> orderDetailRepository,
                            ICustomerService customerService,
                            IProductService productService)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _customerService = customerService;
            _productService = productService;
        }

        public async Task<OrderDto> ProcessOrdeer(ProcessOrderDto processOrderDto)
        {
          
            var customer = await GetCustomerAsync(processOrderDto.CustomerID);         
            var order = await CreateOrderAsync(customer);           
            var orderDetails = await CreateOrderDetailsAsync(processOrderDto.CartItems, order);
            await _productService.UpdateStockAsync(orderDetails);
            return ConvertToOrderDto(order, orderDetails);
        }

        private async Task<CustomerDto> GetCustomerAsync(int customerId)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerId);
            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }

        private async Task<Order> CreateOrderAsync(CustomerDto customer)
        {
            var order = new Order
            {
                CustomerID = customer.CustomerID,
                OrderDate = DateTime.UtcNow
            };

            return await _orderRepository.AddAsync(order);
        }

        private async Task<List<OrderDetail>> CreateOrderDetailsAsync(List<CartItemDto> cartItems, Order createdOrder)
        {
            var productIds = cartItems.Select(item => item.ProductId).ToList();
            var productDtos = await _productService.GetProductsByIdsAsync(productIds);

            var orderDetails = new List<OrderDetail>();

            foreach (var item in cartItems)
            {
                var productDto = productDtos.FirstOrDefault(p => p.ProductID == item.ProductId);
                if (productDto == null)
                {
                    throw new ArgumentException($"Product with ID {item.ProductId} not found.");
                }

                if (productDto.StockQuantity < item.Quantity)
                {
                    throw new InvalidOperationException($"Insufficient stock for product ID {item.ProductId}.");
                }

                var orderDetail = new OrderDetail
                {
                    OrderID = createdOrder.OrderID,
                    ProductID = item.ProductId,
                    Quantity = item.Quantity,
                    PriceAtOrderTime = productDto.Price
                };

                orderDetails.Add(orderDetail);
            }

            await _orderDetailRepository.AddRange(orderDetails);
            return orderDetails;
        }

        private OrderDto ConvertToOrderDto(Order order, List<OrderDetail> orderDetails)
        {
            return new OrderDto
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
        }
    }
}