using HoLWeb.DataLayer.Models.IdentityModels;
using HoLWeb.DataLayer.Models.ThumbModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoLWeb.DataLayer.Models
{

    public class World
    {
        public World()
        {
            // info pro debugování
            Console.WriteLine("Vytvořená instance");
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string WorldName { get; set; } = string.Empty;
        public string WorldDescription { get; set; } = string.Empty;
        [Range(0,100)]
        public int AmountOfMagicInTheWorld { get; set; }



        public virtual List<Race>? Races { get; set; } = new List<Race>();
        public virtual List<Narrative>? Narratives { get; set; } = new List<Narrative>();

        public virtual ThumbImgWorld? ThumbnailImage { get; set; }

        public virtual List<ApplicationUser>? Players { get; set; } = new List<ApplicationUser>();
        public virtual ApplicationUser? GameMaster { get; set; }
        public Guid? GameMasterId { get; set; }

        public List<World> Initial()
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
