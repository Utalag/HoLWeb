using System.ComponentModel.DataAnnotations.Schema;

namespace HoLWeb.DataLayer.Models.GeneralAttributes
{
    public abstract class GeneralAttribut
    {


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual AtributEnum Atribut { get; set; }
        public virtual int RangeLow { get; set; }
        public virtual int RangeHigh { get; set; }
        public virtual int NumberOfDice { get; set; } // počet kostek
        public abstract GeneralAttribut[] Initial(int firstId);

    }
}