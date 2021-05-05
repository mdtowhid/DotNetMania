using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Interfaces;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repo;

        public ProductsController(IProductsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_repo.GeAll("SELECT * FROM Products").ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            return Ok(_repo.GetById("SELECT * FROM Products WHERE ProdId=@id",id));
        }

        //[HttpDelete]
        //public IActionResult DeleteEmployee(int id)
        //{
        //    return Ok(_repo.RemoveById("", id));
        //}
    }
}
