using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace SealGame.Core.Dto
{
    public class SealDto
    {
        public string? Name { get; set; }
        public int SpeciesId { get; set; }
        public List<IFormFile>? Files { get; set; }
    }
}