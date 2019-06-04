using System;
using System.Threading.Tasks;
using EksempelProsjektet.Repositories.Async;
using Microsoft.AspNetCore.Mvc;

namespace EksempelProsjektet.Controllers
{
    /// <summary>
    /// Inneholder kodeeksempler for å illustrere en enkel implementasjon av et asynkront API endepunkt.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AsyncController : ControllerBase
    {
        private readonly IAsyncEksempler _asyncRepo;

        public AsyncController(IAsyncEksempler asyncRepo)
        {
            _asyncRepo = asyncRepo;
        }

        /// <summary>
        /// Korrekt implmentasjon av et async kall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCorrect")]
        public async Task<IActionResult> GetCorrect()
        {
            try
            {
                var length = await _asyncRepo.GetHaikuLength(); // Kombinasjonen av async / await "keywordene" gjør dette til et asynkront kall. Kode vil nå kjøre i en egen tråd, og retunere når den er ferdig.

                if (length > 0)
                {
                    return new OkObjectResult(length);
                }

                return new NotFoundResult();

            }
            catch (Exception e)
            {
                // Logg feil
                return new BadRequestObjectResult(e);
            }
        }

        /// <summary>
        /// Korrekt implmentasjon av et async kall som har påfølgende kode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetContinue")]
        public async Task<IActionResult> GetContinue()
        {
            try
            {
                var result = -1;

                await _asyncRepo.GetHaikuLength()
                    .ContinueWith((length) =>
                    {
                        if (length.Result > 0)
                        {
                            result = length.Result; // Result vil her inneholde ferdig kalkulert resultat. "ContinueWith" funker som en "Callback" funksjon; dvs. koden retunerer her når det asynkrone kallet er ferdig.
                        }
                    });

                return new OkObjectResult(result);

            }
            catch (Exception e)
            {
                // Logg feil
                return new BadRequestObjectResult(e);
            }
        }

        /// <summary>
        /// Inkorrekt implmentasjon av et async kall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetIncorrect")]
        public IActionResult GetInCorrect()
        {
            try
            {
                var length = _asyncRepo.GetHaikuLength().Result; // Result vil her IKKE inneholde ferdig kalkulert resultat. Dette vil føre til at nåværende tråd må ta seg av kalkuleringen, og så gå videre. Dette kalles "blocking" da det blokkerer nåværende tråd.

                if (length > 0)
                {
                    return new OkObjectResult(length);
                }

                return new NotFoundResult();

            }
            catch (Exception e)
            {
                // Logg feil
                return new BadRequestObjectResult(e);
            }
        }
    }
}
