using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled(gevşek bağlılık) bağlı ama soyuta bağlı (yani manageri değişirsem hiçbi sıkıntı yaşamıycam çünkü soyuta bağlandım)
        //IoC Container -- inversion of vontrol(değişimin kontrolü)
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //bunlara alias verdik ki kafası karışmasın postmanın veya serverin
        public IActionResult GetAll()
        {
            //swagger
            //dependency chain

            var result = _productService.GetAll();
            if(result.Success == true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
            

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success == true)
            {
                return Ok(result.Data);
            };

            return BadRequest(result.Success);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            //burda ıresult var yani data yok
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
