namespace HoLWeb.DataLayer.Models.ThumbModels
{
    public class ThumbImgNarrative : ThumbnailImage
    {
        /// <summary>
        /// Navigation property
        /// </summary>
        public virtual Narrative? Narrative { get; set; }

        /// <summary>
        /// Navigation id
        /// </summary>
        public int NarrativeId { get; set; }

    }
}