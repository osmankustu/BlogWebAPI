using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryDal _categoryDal;

        public CategoryController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryDal.GetAll();
            
            return Ok(result);
        }
    }
}
