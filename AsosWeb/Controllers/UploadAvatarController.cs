using Core.DTO.Authentication;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        private readonly IRepository<UserEntity> _userEntity;
        private readonly AsosDbContext _context;
        public UploadAvatarController(AsosDbContext context, IRepository<UserEntity> userEntity, IFotoAvatar image, UserManager<UserEntity> userManager, IJwtTokenService jwtTokenService)
        {
            _image = image;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _userEntity= userEntity;
            _context = context;
        }
        [HttpPost("CreateAvatar")]
        public async Task<IActionResult> CreateAvatar([FromForm] UpdateImageModel model)
        {
            var result = await _image.SaveFotoAvatar(model.Image);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("UpdateAvatar")]
        public async Task<IActionResult> UpdateAvatar([FromForm] UpdateImageModel model)
        {
            string oldFoto = User.Claims.ToList()[5].Value.ToString();

            var newFoto = await _image.UpdateFoto(model.Image, oldFoto);

            string id = User.Claims.ToList()[0].Value.ToString();

            var user = _context.Users
                .Include(x => x.Address)
                .Include(x => x.Address.Town)
                .FirstOrDefault(x => x.Id == int.Parse(id));

            var roles = await _userManager.GetRolesAsync(user);

            if (user!=null)
            {
                user.Image = newFoto;
                await _userManager.UpdateAsync(user);

                var userTokenInfo = new UserTokenInfoDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Birthday = user.Birthday?.ToString("dd-MM-yyyy"),
                    Image = user.Image,
                    PhoneNumber = user.PhoneNumber,
                    Country = user.Address?.Town.CountryId,
                    Town = user.Address?.Town.NameTown,
                    Address = user.Address?.Street,
                    PostCode = user.PostCode,
                    Roles = roles.ToList(),
                };

                var token = await _jwtTokenService.CreateToken(userTokenInfo);

                //var token = await _jwtTokenService.CreateToken(user);

                return Ok(new{image= newFoto, token});

            }

            return Ok(newFoto);
        }
    }
}
