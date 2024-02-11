using ConsoleApp.Services;

namespace ConsoleApp
{
    internal class ConsoleUI
    {
        private readonly ProductService _productService;

        public ConsoleUI(ProductService productService)
        {
            _productService = productService;
        }


    }
}
