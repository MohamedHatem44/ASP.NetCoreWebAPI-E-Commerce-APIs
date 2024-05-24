using E_Commerce.BL.Dtos.Users;
using E_Commerce.DAL.Data.Models;

namespace E_Commerce.BL.Mapper.UserMapper
{
    public class UserMapper : IUserMapper
    {
        /*------------------------------------------------------------------------*/
        public ReadUserDto MapModelToReadUser(User user)
        {
            return new ReadUserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Address = user.Address,
                PhoneNumber = user.PhoneNumber ?? "",
                CreatedAt = user.CreatedAt,
            };
        }
        /*------------------------------------------------------------------------*/
        public ReadUserOrdersDto MapModelToReadUserOrder(User user)
        {
            return new ReadUserOrdersDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Address = user.Address,
                PhoneNumber = user.PhoneNumber ?? "",
                CreatedAt = user.CreatedAt,
                OrdersCount = user.Orders.Count(),
                Orders = user.Orders.Select(order => new OrdersBelongToUserDto
                {
                    Id = order.Id,
                    OrderItemsCount = order.OrderItems.Count(),
                    ShippingPrice = order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * 0.05m,
                    TaxPrice = order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * 0.14m,
                    TotalOrderPrice = order.OrderItems.Sum(item => item.Product.Price * item.Quantity)
                                      + order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * 0.05m
                                      + order.OrderItems.Sum(item => item.Product.Price * item.Quantity) * 0.14m,
                    OrderStatus = order.OrderStatus,
                    PaymentMethod = order.PaymentMethod,
                    CreatedAt = order.CreatedAt,
                    OrderItems = order.OrderItems.Select(orderItem => new OrderItemsBelongToUserOrderDto
                    {
                        Id = orderItem.Id,
                        Quantity = orderItem.Quantity,
                        Color = orderItem.Color,
                        ProductId = orderItem.Product.Id,
                        ProductTitle = orderItem.Product.Title,
                        ItemPrice = orderItem.Product.Price * orderItem.Quantity,
                    })
                })
            };
        }
        /*------------------------------------------------------------------------*/
        public ReadUserShoppingCartDto MapModelToReadUserShoppingCart(User user)
        {
            return new ReadUserShoppingCartDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email ?? "",
                Address = user.Address,
                PhoneNumber = user.PhoneNumber ?? "",
                CreatedAt = user.CreatedAt,
                ShoppingCart = new ShoppingCartBelongToUserDto
                {
                    Id = user.ShoppingCart?.Id ?? 0,
                    ItemsCount = user.ShoppingCart?.CartItems?.Count() ?? 0,
                    TotalPrice = user.ShoppingCart?.CartItems?.Sum(item => item.Product.Price * item.Quantity) ?? 0,
                    CartItems = user.ShoppingCart?.CartItems?.Select(item => new CartItemsBelongToUserShoppingCartDto
                    {
                        Id = item.Id,
                        Quantity = item.Quantity,
                        Color = item.Color,
                        CreatedAt = item.CreatedAt,
                        ProductId = item.ProductId,
                        ProductTitle = item.Product.Title,
                        ItemPrice = item.Product.Price
                    }).ToList() ?? new List<CartItemsBelongToUserShoppingCartDto>()
                }
            };
        }
        /*------------------------------------------------------------------------*/
        public User MapCreateUserToModel(CreateUserDto createUserDto)
        {
            return new User
            {
                FullName = createUserDto.FullName,
                Email = createUserDto.Email,
                UserName = createUserDto.Email,
                Address = createUserDto.Address,
                PhoneNumber = createUserDto.PhoneNumber,
            };
        }
        /*------------------------------------------------------------------------*/
        public void MapUpdateUserToModel(UpdateUserDto updateUserDto, User user)
        {
            user.FullName = updateUserDto.FullName;
            user.Email = updateUserDto.Email;
            user.UserName = updateUserDto.Email;
            user.Address = updateUserDto.Address;
            user.PhoneNumber = updateUserDto.PhoneNumber;
        }
        /*------------------------------------------------------------------------*/
    }
}
