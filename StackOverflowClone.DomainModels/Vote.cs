using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowClone.DomainModels
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VotesID { get; set; }
        public int UserID { get; set; }
        public int AnswerID { get; set; }
        public int VoteValue { get; set; }

    }
}
