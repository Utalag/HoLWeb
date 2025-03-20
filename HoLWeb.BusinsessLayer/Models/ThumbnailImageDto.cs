﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace HoLWeb.BusinessLayer.Models
{
    [DebuggerDisplay("ID:{Id}, WorldId:{WorldId}")]
    public class ThumbnailImageDto
    {
        public int Id { get; set; }
        public string? BaseImage { get; set; } = "Images/PlaceholderImg.png";
        public int X { get; set; } = 50;
        public int Y { get; set; } = 50;
        public int ScaleImage { get; set; } = 100;
        public string? ImageName { get; set; } = string.Empty; // Název obrázku
        public string? Patchname { get; set; } = string.Empty; // Název obrázku v databázi/složce  
        public string? Path { get; set; } = "Images/PlaceholderImg.png";     // cesta  
        public byte[]? ImageData { get; set; } // bitová reprezentace obrázku

        public int RaceId { get; set; } = 0;
        public int CharacterId { get; set; } = 0;
        public int WorldId { get; set; } = 0;
        public int NarrativeId { get; set; } = 0;

        [JsonIgnore] public  RaceDto? Race { get; set; }
        [JsonIgnore] public CharacterDto? Character { get; set; }
        [JsonIgnore] public WorldDto? World { get; set; }
        [JsonIgnore] public NarrativeDto? Narrative { get; set; }
    }
}
