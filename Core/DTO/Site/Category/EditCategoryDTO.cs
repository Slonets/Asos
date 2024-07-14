using Microsoft.AspNetCore.Http;

namespace Core.DTO
{
    public class EditCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}