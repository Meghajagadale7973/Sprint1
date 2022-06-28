using EcommerceWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        EcommerceDB1Context db;
        public ProductController(EcommerceDB1Context _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<TblProduct> GetProducts()
        {
            return db.TblProducts;
        }
        [HttpPost]
        public string Post([FromBody] TblProduct product)
        {
            TblProduct s = new TblProduct();
            s.Id = product.Id;
            s.ProductName = product.ProductName;
            s.ProductDescription = product.ProductDescription;
            s.CatId = product.CatId;
            s.ProductMrp = product.ProductMrp;
            s.ProductDiscount = product.ProductDiscount;
            s.ProductFinal = product.ProductFinal;
            s.ProductQuality = product.ProductQuality;
            db.TblProducts.Add(s);
            db.SaveChanges();
            return "Success";
        }
    }
}