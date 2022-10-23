using Business.Abstract;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
            //losely coupled
            //naming convention
            IArticleService _articleService;

            public ArticlesController(IArticleService articleService)
            {
                _articleService = articleService;
            }

            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {

                var result = _articleService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpPost("Add")]
            public IActionResult Post(Article article)
            {
                var result = _articleService.add(article);

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("GetById")]
            public IActionResult Get(int id)
            {
                var result = _articleService.GetById(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

            [HttpGet("GetArticleDetail")]
            public IActionResult GetArticleDetail()
            {
                var result = _articleService.GetArticleDetails();

                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }




        }
    }



