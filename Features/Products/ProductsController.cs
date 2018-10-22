using System.Threading.Tasks;
using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreVue.Features.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly EcommerceContext _db;
        public ProductsController(EcommerceContext db){
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Find(){
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug){
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Slug == slug);
            if(product == null) return NotFound();
            return Ok(product);
        }
    }
}