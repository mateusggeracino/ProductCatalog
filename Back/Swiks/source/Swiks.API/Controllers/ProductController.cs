using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swiks.API.Controllers.Base;
using Swiks.API.ViewModels.Request;
using Swiks.API.ViewModels.Response;
using Swiks.Domain.Entities;
using Swiks.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swiks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices, ILogger<ProductController> logger, IMapper mapper)
        {
            _productServices = productServices;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all product registered on memory
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> GetAll()
        {
            try
            {
                _logger.LogInformation("Get all products", "Send a current user");
                var result = _productServices.GetAll();

                return Ok(_mapper.Map<ICollection<ProductResponseViewModel>>(result));
            }catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
        
        /// <summary>
        /// Insert a new product on memory
        /// </summary>
        /// <param name="product">Properties of product</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post(ProductRequestViewModel product)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(product);

                _logger.LogInformation("Insert a new product", product);
                var result = _productServices.Insert(_mapper.Map<Product>(product));
                if (result.ValidationResult.Errors.Any()) return AddErrors(result.ValidationResult.Errors);

                return Ok("product inserted");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new StatusCodeResult(500);
            }
        }
    }
}