using E_Commerce.BL.Mapper.AuthMapper;
using E_Commerce.BL.Mapper.BrandMapper;
using E_Commerce.BL.Mapper.CategoryMapper;
using E_Commerce.BL.Mapper.OrderMapper;
using E_Commerce.BL.Mapper.ProductMapper;
using E_Commerce.BL.Mapper.ShoppingCartMapper;
using E_Commerce.BL.Mapper.UserMapper;

namespace E_Commerce.BL.Mapper.UnitMapper
{
    public class UnitMapper : IUnitMapper
    {
        /*------------------------------------------------------------------------*/
        public IAuthMapper AuthMapper { get; }
        public ICategoryMapper CategoryMapper { get; }
        public IBrandMapper BrandMapper { get; }
        public IProductMapper ProductMapper { get; }
        public IUserMapper UserMapper { get; }
        public IShoppingCartMapper ShoppingCartMapper { get; }
        public IOrderMapper OrderMapper { get; }
        /*------------------------------------------------------------------------*/
        public UnitMapper
            (
            IAuthMapper authMapper,
            ICategoryMapper categoryMapper,
            IBrandMapper brandMapper,
            IProductMapper productMapper,
            IUserMapper userMapper,
            IShoppingCartMapper shoppingCartMapper,
            IOrderMapper orderMapper
            )
        {
            AuthMapper = authMapper;
            CategoryMapper = categoryMapper;
            BrandMapper = brandMapper;
            ProductMapper = productMapper;
            UserMapper = userMapper;
            ShoppingCartMapper = shoppingCartMapper;
            OrderMapper = orderMapper;
        }
        /*------------------------------------------------------------------------*/
    }
}
