using EksempelProsjektet.Repositories.Async;
using System;
using System.Threading.Tasks;

namespace ThreadConsole
{
    class OLD_Program
    {
        private static readonly IAsyncEksempler _asyncRepo = new AsyncEksempler();

        static async Task OLD_Main(string[] args)
        {
            Console.WriteLine("Starter!");

            // var result = await GetCorrectAsync();
            // var result = await GetContinueAsync();
            // var result = GetInCorrect();
            var result = ConfigureAwait();

            Console.WriteLine("2. <Gjør noe annet arbeid>");
            Console.WriteLine($"Ferdig! Result: {result}");
            Console.WriteLine("");
        }

        /// <summary>
        /// Korrekt implmentasjon av et async kall
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> GetCorrectAsync()
        {

            Console.WriteLine("Starter GetCorrectAsync()");
            try
            {
                var length = await _asyncRepo.GetHaikuLengthAsync(); // Kombinasjonen av async / await "keywordene" gjør dette til et asynkront kall. Kode vil nå kjøre i en egen tråd, og retunere når den er ferdig.
                Console.WriteLine("Ferdig await GetHaikuLengthAsync()");

                if (length > 0)
                {
                    Console.WriteLine($"Ferdig! Result: {length}");
                }

                Console.WriteLine("1. <Gjør noe annet arbeid>");
                return true;
            }
            catch (Exception e)
            {
                // Logg feil
                Console.WriteLine($"Exception kastet: {e.GetType().Name} - {e.GetBaseException().Message}");
                return false;
            }
        }

        /// <summary>
        /// Korrekt implmentasjon av et async kall som har påfølgende kode
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> GetContinueAsync()
        {
            Console.WriteLine("Starter GetContinueAsync()");
            try
            {
                var result = -1;

                await _asyncRepo.GetHaikuLengthAsync()
                    .ContinueWith((length) =>
                    {
                        if (length.Result > 0)
                        {
                            result = length.Result; // Result vil her inneholde ferdig kalkulert resultat. "ContinueWith" funker som en "Callback" funksjon; dvs. koden retunerer her når det asynkrone kallet er ferdig.
                        }
                        Console.WriteLine($"Ferdig! Result: {result}");
                    });

                Console.WriteLine("1. <Gjør noe annet arbeid>");
                return true;
            }
            catch (Exception e)
            {
                // Logg feil
                Console.WriteLine($"Exception kastet: {e.GetType().Name} - {e.GetBaseException().Message}");
                return false;
            }
        }

        /// <summary>
        /// Inkorrekt implmentasjon av et async kall
        /// </summary>
        /// <returns></returns>
        private static bool GetInCorrect()
        {
            Console.WriteLine("Starter GetInCorrect()");
            try
            {
                var length = _asyncRepo.GetHaikuLengthAsync().Result; // Result vil her IKKE inneholde ferdig kalkulert resultat. Dette vil føre til at nåværende tråd må ta seg av kalkuleringen, og så gå videre. Dette kalles "blocking" da det blokkerer nåværende tråd.
                Console.WriteLine("Ferdig GetHaikuLengthAsync().Result");

                if (length > 0)
                {
                    Console.WriteLine($"Ferdig! Result: {length}");
                }

                Console.WriteLine("1. <Gjør noe annet arbeid>");
                return true;
            }
            catch (Exception e)
            {
                // Logg feil
                Console.WriteLine($"Exception kastet: {e.GetType().Name} - {e.GetBaseException().Message}");
                return false;
            }
        }

        /// <summary>
        /// Korrekt implmentasjon av et async kall
        /// </summary>
        /// <returns></returns>
        private static bool ConfigureAwait()
        {

            Console.WriteLine("Starter ConfigureAwait()");
            try
            {
                var result = _asyncRepo.GetHaikuLengthAsync().ConfigureAwait(false);
                while (!result.GetAwaiter().IsCompleted)
                {
                    Console.Write(".");
                }

                Console.WriteLine("1. <Gjør noe annet arbeid>");
                Console.WriteLine($"Ferdig! Result: {result.GetAwaiter().GetResult()}");
                return true;
            }
            catch (Exception e)
            {
                // Logg feil
                Console.WriteLine($"Exception kastet: {e.GetType().Name} - {e.GetBaseException().Message}");
                return false;
            }
        }


    }
}
