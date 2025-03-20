using System.ComponentModel.DataAnnotations;

namespace HoLWeb.DataLayer.Interfaces.ISkills
{
    public interface IBaseSkillData
    {
        [Key]
        public int Id { get; set; }
        [Range(1,32)]
        public int Level { get; set; }  // (Cz: Úroveň od které je možno skill umět)
        public string SpecificDescription { get; set; }
    }


}
