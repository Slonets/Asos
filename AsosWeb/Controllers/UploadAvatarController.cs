using Core.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public UploadAvatarController(IFotoAvatar image, UserManager<UserEntity> userManager, IJwtTokenService jwtTokenService)
        {
            _image = image;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService; 
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

            var newFoto = await _image.UpdateFoto(model.Image, oldFoto);

            string id = User.Claims.ToList()[0].Value.ToString();

            var user = _userManager.FindByIdAsync(id).Result;

            if (user!=null)
            {
                user.Image = newFoto;
                await _userManager.UpdateAsync(user);

                var token = await _jwtTokenService.CreateToken(user);

                return Ok(new{image= newFoto, token});

            }

            return Ok(newFoto);
        }
    }
}
