using System.Net;
using AutoMapper;
using EShoppingAPI.Business.Abstract;
using EShoppingAPI.Entity.DTO.Category;
using EShoppingAPI.Entity.DTO.Product;
using EShoppingAPI.Entity.Poco;
using EShoppingAPI.Entity.Result;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.Apı.Controllers
{
    [ApiController]
    [Route("EShoppingAPI/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }


        [HttpGet("/Products")]
        [ProducesResponseType(typeof(Sonuç<List<ProductDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync(q=>q.IsActive==true && q.IsDeleted==false, "Category");
            if (products != null)
            {
                List<ProductDTOResponse> productDtoResponseList = new List<ProductDTOResponse>();
                foreach (var product in products)
                {
                    productDtoResponseList.Add(_mapper.Map<ProductDTOResponse>(product));
                }


                return Ok(Sonuç<List<ProductDTOResponse>>.SuccessWithData(productDtoResponseList));
            }
            else
            {
                return NotFound(Sonuç<List<ProductDTOResponse>>.SuccessNoDataFound());

            }

        }


        [HttpGet("/Product/{productGUID}")]
        [ProducesResponseType(typeof(Sonuç<List<ProductDTOResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProduct(Guid productGUID)
        {
            var product = await _productService.GetAllAsync(q => q.GUID==productGUID, "Category");
           
            if (product != null)
            {
                ProductDTOResponse productDtoResponse= _mapper.Map<ProductDTOResponse>(product);
               

                return Ok(Sonuç<ProductDTOResponse>.SuccessWithData(productDtoResponse));
            }
            else
            {
                return NotFound(Sonuç<List<ProductDTOResponse>>.SuccessNoDataFound());

            }

        }


        [HttpPost("/AddProduct")]
        [ProducesResponseType(typeof(Sonuç<bool>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddProduct(ProductDTORequest productDTORequest)
        {
            var category = await _categoryService.GetAsync(q => q.GUID == productDTORequest.CategoryGuid);
            productDTORequest.CategoryID=category.ID;


            Product product= _mapper.Map<Product>(productDTORequest);
            product.Category=category;

            await _productService.AddAsync(product);

            return Ok(Sonuç<bool>.SuccessWithData(true));
        }


        [HttpPost("/UpdateProduct")]
        [ProducesResponseType(typeof(Sonuç<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(ProductDTORequest productDTORequest)
        {

            Product product = await _productService.GetAsync(q => q.GUID == productDTORequest.Guid);

            string featuredImage = product.FeaturedImage;

            var category = await _categoryService.GetAsync(q => q.GUID == productDTORequest.CategoryGuid);

            //_mapper.Map<Product>(productDTORequest);

            product.UnitPrice = productDTORequest.UnitPrice;
            product.Name = productDTORequest.Name;
            product.Description = productDTORequest.Description;
            product.FeaturedImage = featuredImage;

            if (productDTORequest.FeaturedImage is null)
            {
                product.FeaturedImage = featuredImage;
            }

            product.Category = category;
            await _productService.UpdateAsync(product);

            return Ok(Sonuç<bool>.SuccessWithData(true));
        }


        [HttpPost("/RemoveProduct/{productGUID}")]
        [ProducesResponseType(typeof(Sonuç<bool>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> RemoveProduct(Guid productGUID)
        {
            Product product = await _productService.GetAsync(q => q.GUID == productGUID);

            product.IsActive = false;
            product.IsDeleted = true;
            await _productService.UpdateAsync(product);
            return Ok(Sonuç<bool>.SuccessWithData(true));
        }



    }
}
