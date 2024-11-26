using Microsoft.AspNetCore.Mvc;

namespace SealGame.Models.Seals
{
    public class SealImageViewModel : Controller
    {
        public Guid ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public string Image {  get; set; }
        public Guid? SealId { get; set; }

    }
}
