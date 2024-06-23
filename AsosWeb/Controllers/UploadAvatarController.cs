using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AsosWeb.Controllers
{
    public class UpdateImageModel
    {
        public IFormFile Image { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    
    public class UploadAvatarController : ControllerBase
    {
        private readonly IFotoAvatar _image;
        public UploadAvatarController(IFotoAvatar image)
        {
            _image = image;
        }
        [HttpPost("CreateAvatar")]
        public async Task<IActionResult> CreateAvatar([FromForm] UpdateImageModel model)
        {
            var result = await _image.SaveFoto(model.Image);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("UpdateAvatar")]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateImageModel model)
        {
            string oldFoto = User.Claims.ToList()[5].Value.ToString();

            var result = await _image.UpdateFoto(model.Image, oldFoto);
            return Ok(result);
        }
    }
}
