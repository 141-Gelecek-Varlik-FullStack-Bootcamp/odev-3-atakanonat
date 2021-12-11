using AutoMapper;
using Comm.DB.Entities;
using Comm.Model;

namespace Comm.Service.Product
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        public ProductService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public Common<Model.Product.Product> Add(Model.Product.Product newProduct)
        {
            var result = new Common<Model.Product.Product>() { IsSuccess = false };
            var mappedProduct = mapper.Map<DB.Entities.Product>(newProduct);
            using (var srv = new CommContext())
            {
                mappedProduct.Idate = System.DateTime.Now;
                srv.Product.Add(mappedProduct);
                srv.SaveChanges();
                result.Entity = mapper.Map<Model.Product.Product>(mappedProduct);
                result.IsSuccess = true;
            }

            return result;
        }

        public bool Update()
        {
            var result = false;
            return result;
        }
        public bool Delete()
        {
            var result = false;
            return result;
        }

    }
}