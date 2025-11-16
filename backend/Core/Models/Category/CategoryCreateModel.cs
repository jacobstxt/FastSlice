using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Category
{
    public class CategoryCreateModel
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; } = null;
    }
}
