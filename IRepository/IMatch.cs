using Tazaker.Models;

namespace Tazaker.IRepository
{
    public interface IMatch
    {
        List<Match> ReadAll();
        Match GetById(int id);
        void Update(Match match);   
        void Delete(int id);
        void Create (Match match);  
    }
}
