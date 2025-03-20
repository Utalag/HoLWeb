namespace HoLWeb.DataLayer.Models.ThumbModels
{
    public class ThumbImgRace : ThumbnailImage
    {
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Race? Race { get; set; }

        /// <summary>
        /// Navigation id
        /// </summary>
        public int RaceId { get; set; }

    }
}