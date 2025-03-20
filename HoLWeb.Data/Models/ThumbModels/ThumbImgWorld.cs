namespace HoLWeb.DataLayer.Models.ThumbModels
{
    public class ThumbImgWorld : ThumbnailImage
    {
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual World? World { get; set; }

        /// <summary>
        /// Navigation id
        /// </summary>
        public int WorldId { get; set; }

    }

}
