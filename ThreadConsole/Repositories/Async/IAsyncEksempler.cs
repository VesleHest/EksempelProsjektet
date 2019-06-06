using System.Threading.Tasks;

namespace EksempelProsjektet.Repositories.Async
{
    public interface IAsyncEksempler
    {
        Task<int> GetHaikuLengthAsync();
    }
}
