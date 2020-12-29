namespace StackOverflowClone.Repositories.Interfaces
{
    public interface IVotesRepository
    {
        void UpdateVote(int answerID, int userID, int value);
    }
}
