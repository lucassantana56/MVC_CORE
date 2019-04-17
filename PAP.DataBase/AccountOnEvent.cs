using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAP.DataBase
{
    public partial class AccountOnEvent
    {
        [Key]
        public int AccountOnEventId { get; set; }

        public int AccountId { get; set; }

        public int EventId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(EventId))]
        public virtual Event Event { get; set; }
    }
}
