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
            movieDataManager.CreateMovies(allMovies);

            var imdbMovies = movieDataManager.GetMoviesByGenre(Genre.SciFi);

            foreach (var movie in imdbMovies)
            {
                Console.WriteLine($"Title: {movie.Title}\tGenre: {movie.Genre}\tYear: {movie.Year}\tImageUrl:{movie.ImageUrl}");
            }

            imdbMovies = movieDataManager.GetMoviesByYear(2013);

            Console.WriteLine("");

            foreach (var movie in imdbMovies)
            {
                Console.WriteLine($"Title: {movie.Title}\tGenre: {movie.Genre}\tYear: {movie.Year}\tImageUrl:{movie.ImageUrl}");
            }
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
