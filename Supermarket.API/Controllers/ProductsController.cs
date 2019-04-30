using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Resources;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> ListAsync(){
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return resources;
        }
    }
}
