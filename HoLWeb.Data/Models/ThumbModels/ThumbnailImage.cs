using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoLWeb.DataLayer.Models.ThumbModels
{
    public abstract class ThumbnailImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }
        public int X { get; set; } = 50;
        public int Y { get; set; } = 50;
        public int ScaleImage { get; set; } = 100;
        public string? ImageName { get; set; } = string.Empty; // Název obrázku
        public string? Patchname { get; set; } = string.Empty; // Název obrázku v databázi/složce  
        public string? Path { get; set; } = "Images/PlaceholderImg.png";     // cesta  
        public byte[]? ImageData { get; set; } // bitová reprezentace obrázku


    }
}
