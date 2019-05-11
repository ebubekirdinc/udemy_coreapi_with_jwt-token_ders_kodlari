using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UdemyApiWithToken.Domain.Responses;
using UdemyApiWithToken.Domain.Services;

namespace UdemyApiWithToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            ProductListResponse productListResponse = await productService.ListAsync();

            if (productListResponse.Success)
            {
                return Ok(productListResponse.productList);
            }
            else
            {
                return BadRequest(productListResponse.Message);
            }
        }
    }
}