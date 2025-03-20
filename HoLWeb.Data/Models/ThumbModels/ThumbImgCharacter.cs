namespace HoLWeb.DataLayer.Models.ThumbModels
{
    public class ThumbImgCharacter : ThumbnailImage
    {
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Character? Character { get; set; }

        /// <summary>
        /// Navigation id
        /// </summary>
        public int CharacterId { get; set; }
    }
}