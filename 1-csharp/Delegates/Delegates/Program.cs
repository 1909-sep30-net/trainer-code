using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var movie = "Frozen";

            var moviePlayer = new MoviePlayer { CurrentMovie = movie };

            moviePlayer.PlayMovie();
        }
    }
}
