using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EksempelProsjektet.Repositories.Async
{
    public interface IAsyncEksempler
    {
        Task<int> GetHaikuLength();
    }
}
