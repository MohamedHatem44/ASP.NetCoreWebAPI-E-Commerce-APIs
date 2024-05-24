using E_Commerce.BL.Dtos.Orders;
using E_Commerce.BL.Mapper.UnitMapper;
using E_Commerce.DAL;
using System.Security.Claims;

namespace E_Commerce.BL.Managers.Orders
{
    public class OrderManager : IOrderManager
    {
        /*------------------------------------------------------------------------*/
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUnitMapper _unitMapper;
        /*------------------------------------------------------------------------*/
        public OrderManager(IUnitOfWork unitOfWork, IUnitMapper unitMapper)
        {
            _unitOfWork = unitOfWork;
            _unitMapper = unitMapper;
        }
        /*------------------------------------------------------------------------*/
        // Get All Orders With Details
        public IEnumerable<OrderDetailsDto> GetAllOrdersWithDetails()
        {
            var orders = _unitOfWork.OrderRepository.GetAllOrdersWithDetails();
            var allOrders = orders.Select(order => _unitMapper.OrderMapper.MapModelToReadOrderDetails(order));
            return allOrders;
        }
        /*------------------------------------------------------------------------*/
        // Get Orders By User Clamis
        public IEnumerable<OrderDetailsDto> GetOrdersByUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if (userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }

            var orders = _unitOfWork.OrderRepository.GetOrdersByUserId(userId);
            if (orders.Count() == 0)
            {
                throw new InvalidOperationException($"No Orders for User with ID {userId}");
            }

            var allUserOrders = orders.Select(order => _unitMapper.OrderMapper.MapModelToReadOrderDetails(order));
            return allUserOrders;
        }
        /*------------------------------------------------------------------------*/
        // Get Orders By User Id
        public IEnumerable<OrderDetailsDto> GetOrdersByUserId(string userId)
        {
            var user = _unitOfWork.UserRepository.GetUserById(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"User with ID : {userId} not found");
            }

            var orders = _unitOfWork.OrderRepository.GetOrdersByUserId(user.Id);
            if (orders.Count() == 0)
            {
                throw new InvalidOperationException($"No Orders for User with ID {user.Id}");
            }

            var allUserOrders = orders.Select(order => _unitMapper.OrderMapper.MapModelToReadOrderDetails(order));
            return allUserOrders;
        }
        /*------------------------------------------------------------------------*/
        // Place Order
        public void CreateOrder(ClaimsPrincipal claimsPrincipal, List<ProductQuantityToCreateOrderDto> productQuantities)
        {
            if (productQuantities == null || productQuantities.Count == 0)
            {
                throw new ArgumentException("No products specified for order creation");
            }

            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            // Check if the user exists
            if (userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }

            // Create a new order instance
            var order = _unitMapper.OrderMapper.MapCreateOrderToModel(userId);

            foreach (var productQuantity in productQuantities)
            {
                var product = _unitOfWork.ProductRepository.GetById(productQuantity.productId);

                // Check if the product exists
                if (product == null)
                {
                    throw new InvalidOperationException($"Product with ID {productQuantity.productId} not found");
                }

                // Check if the product has enough quantity in stock
                if (product.Quantity < productQuantity.quantity)
                {
                    throw new ArgumentException($"Product with ID {productQuantity.productId} does not have enough quantity in stock");
                }

                // Create a new order item for the specified product and quantity
                var orderItem = _unitMapper.OrderMapper.MapCreateOrderItemToModel(productQuantity, product);

                // Add the order item to the order's list of order items
                order.OrderItems.Add(orderItem);

                // Update the product quantity and sold
                product.Quantity -= productQuantity.quantity;
                product.Sold += productQuantity.quantity;
                _unitOfWork.ProductRepository.Update(product);
            }
            _unitOfWork.OrderRepository.Create(order);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
        // Place Order From Shopping Cart
        public void CreateOrderFromCart(ClaimsPrincipal claimsPrincipal)
        {
            var userId = _unitOfWork.UserManager.GetUserId(claimsPrincipal);
            if (userId == null)
            {
                throw new InvalidOperationException($"User not found");
            }

            // Get the shopping cart items for the specified user
            var cartItems = _unitOfWork.OrderRepository.GetShoppingCartItemsByUserId(userId);
            // Check if the shopping cart contains any items
            if (cartItems.Count() == 0)
            {
                throw new InvalidOperationException($"Shopping cart for User with Id {userId} is empty, Unable to create order");
            }

            // Create a new order instance
            var order = _unitMapper.OrderMapper.MapCreateOrderToModel(userId);

            // Iterate through each cart item and create order items
            foreach (var cartItem in cartItems)
            {
                var orderItem = _unitMapper.OrderMapper.MapCreateOrderItemToModel(cartItem);
                order.OrderItems.Add(orderItem);
            }

            // Save the new order to the database
            _unitOfWork.OrderRepository.Create(order);

            // Update product quantities and sold amounts
            foreach (var cartItem in cartItems)
            {
                cartItem.Product.Quantity -= cartItem.Quantity;
                cartItem.Product.Sold += cartItem.Quantity;
                _unitOfWork.ProductRepository.Update(cartItem.Product);
            }
            _unitOfWork.OrderRepository.ClearCartItems(cartItems);
            _unitOfWork.SaveChanges();
        }
        /*------------------------------------------------------------------------*/
    }
}
