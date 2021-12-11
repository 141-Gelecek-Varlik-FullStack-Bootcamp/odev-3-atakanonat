using Comm.Model;

namespace Comm.Service.Product
{
    public interface IProductService
    {
        Common<Model.Product.Product> Add(Model.Product.Product newProduct);
        bool Update();
        bool Delete();
    }
}