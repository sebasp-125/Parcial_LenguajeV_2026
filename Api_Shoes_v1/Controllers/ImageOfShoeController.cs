using Api_Shoes_v1.Dtos.Images;
using Api_Shoes_v1.RealModels;
using Api_Shoes_v1.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api_Shoes_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageOfShoeController : ControllerBase
    {
        private readonly IImageOfShoe _imageOfShoeService;

        public ImageOfShoeController(IImageOfShoe imageOfShoeService)
        {
            _imageOfShoeService = imageOfShoeService;
        }

        [HttpPost("AddImage")]
        public async Task<IActionResult> AddImage([FromBody] ImageOfShoeCreateDto imageDto)
        {
            if (imageDto == null)
            {
                return BadRequest("La información de la imagen es nula.");
            }

            var imageInfo = new Imageofshoe
            {
                Imagetype = imageDto.Imagetype,
                Esprincipal = imageDto.Esprincipal ?? false,
                Url = imageDto.Url,
                Idshoe = imageDto.Idshoe
            };

            var createdImage = await _imageOfShoeService.CreateImageOfShoe(imageInfo);
            return Ok(createdImage);
        }
    }
}
