using Matgr.UI.Models.Dtos;
using Matgr.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Matgr.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBlobService _blobService;

        public ProductController(IProductService productService, IBlobService blobService)
        {
            _productService = productService;
            _blobService = blobService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetAllProducts<ResponseDto>(accessToken);
            if (response != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                //upload image and get url
                var imageUrl = await _blobService.UploadBlob(product.Image.FileName, product.Image, "images");
                var model = new ProductDto()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryName = product.CategoryName,
                    ImageUrl = imageUrl,
                    Quantity = product.Quantity
                };
                var response = await _productService.CreateProduct<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }
            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProduct<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                var product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _productService.UpdateProduct<ResponseDto>(model, accessToken);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("ProductIndex");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.GetProduct<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                var product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDto model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _productService.DeleteProduct<ResponseDto>(model.ProductId, accessToken);
            if (response != null && response.IsSuccess)
            {
                //delete blob 
                if (model.ImageUrl.Contains('/'))
                {
                    int pos = model.ImageUrl.LastIndexOf("/") + 1;
                    var blobName = model.ImageUrl[pos..];
                    await _blobService.DeleteBlob(blobName, "images");
                }
                return RedirectToAction("ProductIndex");
            }
            return View(model);
        }
    }
}
