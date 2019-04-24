using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableValuedParametersExample.DataLayer;

namespace TableValuedParametersExample
{
    static class Program
    {
        static void Main(string[] args)
        {
            DeployFreshDatabase();
            var movieDataManager = new MovieDataManager();

            var allMovies = movieDataManager.GetImdbMoviesFromInMemory();

            /*
             * All Of the CreateMoviesTvpXXX methods (below) use a Table Valued Parameter
             * However the stored procedures are implemented in 4 different ways.
             * The method below calls stored procedures with the same name.
             * Please take a look at the stored procedures for the details.
             * Each of the storped procedures have different performance characterizrics
             * For small sets of records (< 50) the CreateMoviesTvpUsingCursor stored proecdure
             * is fastest
            */

            ////movieDataManager.CreateMoviesTvpUsingCursor(allMovies);
            ////movieDataManager.CreateMoviesTvpDistinctInsertInto(allMovies);
            ////movieDataManager.CreateMoviesTvpMergeInsertInto(allMovies);
            movieDataManager.CreateMoviesTvpMergeMerge(allMovies);

            RetrieveAndDisplayMovies(movieDataManager);
        }

        private static void RetrieveAndDisplayMovies(MovieDataManager movieDataManager)
        {
            PrintHeading("All Movies");
            var imdbMovies = movieDataManager.GetAllMovies();
            PrintImdbMovies(imdbMovies);

            PrintHeading("Movies By Year - 2013");
            imdbMovies = movieDataManager.GetMoviesByYear(2013);
            PrintImdbMovies(imdbMovies);

            PrintHeading("Movies By Genre - Sci-Fi");
            imdbMovies = movieDataManager.GetMoviesByGenre(Genre.SciFi);
            PrintImdbMovies(imdbMovies);
        }

        private static void PrintHeading(string message)
        {
            var originalForegroundColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = originalForegroundColor;
            }
        }

        private static void PrintImdbMovies(IEnumerable<ImdbMovie> imdbMovies)
        {
            foreach (var imdnMovie in imdbMovies)
            {
                Console.WriteLine($"Title: {imdnMovie.Title}\tGenre: {imdnMovie.Genre}\tYear: {imdnMovie.Year}\tImageUrl:{imdnMovie.ImageUrl}");
            }

            Console.WriteLine("\r\n");
        }

        private static void DeployFreshDatabase()
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + "\"..\\..\\PublishMovieDbToLocalDb.bat\"");
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();
        }

    }
}
