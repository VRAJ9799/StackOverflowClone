using StackOverflowClone.DomainModels;

using StackOverflowClone.Repositories.Interfaces;
using System.Linq;
namespace StackOverflowClone.Repositories
{
    class VotesRepository : IVotesRepository
    {
        StackOverflowDatabaseDbContext db;
        public VotesRepository()
        {
            db = new StackOverflowDatabaseDbContext();
        }
        public void UpdateVote(int answerID, int userID, int value)
        {
            int updatevote;
            if (value > 0) updatevote = 1;
            else if (value < 0) updatevote = -1;
            else updatevote = 0;
            Vote vote = db.Votes.Where(temp => temp.AnswerID == answerID && temp.UserID == userID).FirstOrDefault();
            if (vote != null)
            {
                vote.VoteValue = updatevote;
            }
            else
            {
                Vote vote1 = new Vote() { AnswerID = answerID, UserID = userID, VoteValue = updatevote };
            }
            db.SaveChanges();
        }
    }
}
