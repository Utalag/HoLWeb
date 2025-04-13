using HoLWeb.DataLayer.Models.IdentityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoLWeb.DataLayer.Models
{

    public class World
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WorldName { get; set; } = string.Empty;
        public string WorldDescription { get; set; } = string.Empty;
        public int AmountOfMagicInTheWorld { get; set; }



        public virtual IList<Race>? Races { get; set; } 
        public virtual IList<Narrative>? Narratives { get; set; } 

        //public virtual ThumbnailImage? ThumbnailImage { get; set; }
        //public int? ThumbnailImageId { get; set; }

        //public virtual IList<ApplicationUser>? PlayersInWorld { get; set; } 
        //public virtual IList<ApplicationUser>? GameMastersInWorld { get; set; }

        public virtual ApplicationUser? Founder { get; set; }
        public Guid? FounderId { get; set; }

        public IList<World> Initial()
        {

            return new World[]
            {
                new World
                {
                    Id = 1,
                    WorldName = "Fantasy svět",
                    AmountOfMagicInTheWorld = 100,
                    WorldDescription = "Svět plný magie a kouzel, kde se můžete setkat s draky, elfy, trpaslíky a dalšími bytostmi.",
                },

                new World
                {
                    Id=2,
                    WorldName = "Postapo",
                    AmountOfMagicInTheWorld = 25,
                    WorldDescription = "Svět, který prošel apokalypsou a kde se lidstvo snaží přežít v nepřátelském prostředí.",
                },

                new World
                {
                    Id=3,
                    WorldName = "Reálný svět",
                    AmountOfMagicInTheWorld = 0,
                    WorldDescription = "Svět, který známe, kde neexistuje magie a kouzla.",

                }
            }.ToList();

        }
    }
}
