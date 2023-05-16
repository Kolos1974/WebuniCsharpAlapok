using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ConsoleApp
{
    /// <summary>
    /// Egy <see cref="MovieCatalog.Database"/> típusú adatbázison megfogalmazott lekérdezések futtatásáért felelős objektum.
    /// </summary>
    public class MovieQueries
    {
        /// <summary>
        /// Az adatbázis, amin a lekérdezések futnak
        /// </summary>
        public Database Database { get; }

        /// <summary>
        /// Egy <see cref="MovieQueries"/> példány létrehozása a megadott <paramref name="database"/> adatbázissal.
        /// </summary>
        /// <param name="database">Az "adatbázis", amin a lekérdezések futni fognak.</param>
        public MovieQueries(Database database) => Database = database;

        /// <summary>
        /// A legnépszerűbb film lekérdezése (ahol legalább 1000 szavazatot adtak, a legmagasabb átlagos értékelés szerint).
        /// </summary>
        /// <returns>A megadottaknak megfelelő film példány.</returns>
        public Movie GetTheBestPopularMovie()
        {
            return Database.Movies.Where(m => m.VoteCount > 1000).OrderByDescending(m => m.VoteAverage).First();
        }

        /// <summary>
        /// A megadott <paramref name="year"/> évben megjelent filmek számának lekérdezése.
        /// </summary>
        /// <param name="year">A kérdéses év, amelyre a szűrés történik.</param>
        /// <returns>A megadott <paramref name="year"/> évben megjelent filmek száma.</returns>
        public int GetNumberOfMoviesInYear(int year)
        {
            // return Database.Movies.Where(m => m.ReleaseDate.Value.Year==year).Count();
            // return Database.Movies.Count(m => !(m.ReleaseDate.Value.Year== null) &&  m.ReleaseDate.Value.Year == year);
            //throw new NotImplementedException();

            // Hagyományos módon:
            /*
            var sum = 0;
            foreach (var movie in Database.Movies)
            {
                if (movie.ReleaseDate.HasValue)
                {
                    if (movie.ReleaseDate.Value.Year == year)
                    {
                        sum++;
                    }

                }
            }
            return sum;
            */

            // Ez a megoldás is jó:
            // return Database.Movies.Count(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == year);

            return Database.Movies.Where(m => m.ReleaseDate.HasValue && m.ReleaseDate.Value.Year == year).Count();
        }

        /// <summary>
        /// A 2010 és 2015 (inkluzív) intervallumba eső 5 (filmek száma szerinti) legnépszerűbb műfaj lekérdezése.
        /// </summary>
        /// <returns>Egy megszámlálható példány (pl. lista), amelyben a műfaj nevét és a hozzá tartozó 2010 és 2015 (inkluzív) között megjelent filmek számát tartalmazó tuple példányok találhatók.</returns>
        public IEnumerable<(string Genre, int NumberOfMovies)> GetTop5MostPopularGenresFrom2010To2015()
        {
            (string genre, int numberOfMovies) = ("", 0);

            var movie = Database.Movies.First();
            // return Database.Genres.OrderByDescending(x => x).Take(5).Select(x => ("", 0)).ToList();
            
            // From Novák Péter
            return Database.Genres.Select(x => (x.Value, Database.Movies.Count(m => m.ReleaseDate.HasValue && m.ReleaseDate >= new DateTime(2010, 1, 1) &&
            m.ReleaseDate <= new DateTime(2015, 12, 31) && m.Genres.ContainsKey(x.Key)))).OrderByDescending(y => y.Item2).Take(5);

            // throw new NotImplementedException();
        }

        /// <summary>
        /// A 10 legnagyobb költségvetésű film lekérdezése.
        /// </summary>
        /// <returns>A 10 legnagyobb költségvetésű film.</returns>
        public IEnumerable<Movie> GetTop10BiggestBudgetMovies()
        {
            // return Database.Movies.OrderByDescending(m => m.Budget).Take(10).ToList();
            return Database.Movies.OrderByDescending(m => m.Budget).Take(10);

            // throw new NotImplementedException();
        }

        /// <summary>
        /// Az 5 legtöbb műfajjal rendelkező film lekérdezése.
        /// </summary>
        /// <returns>Az 5 legtöbb műfajjal rendelkező film kollekciója.</returns>
        public IEnumerable<Movie> GetTop5MoviesWithTheMostNumberOfGenres()
        {
            // return Database.Movies.OrderByDescending(m => m.Genres.Count).Take(5).ToList();
            return Database.Movies.OrderByDescending(m => m.Genres.Count).Take(5);

            // throw new NotImplementedException();
        }

        /// <summary>
        /// A megadott <paramref name="country"/> országban megjelent legnagyobb költségvetésű film lekérdezése.
        /// </summary>
        /// <param name="country">Az ország kódja (pl. "US" vagy "HU").</param>
        /// <returns>A legnagyobb költségvetésű film a megadott országban, vagy null, ha nem található az országhoz tartozó film.</returns>
        public Movie? GetHighestBudgetMovieMadeInCountry(string country)
        {
            // szűrés, rendezés, első elem lekérdezése
            // FirstOrDefault-t kell használni!!

            //return Database.Movies.Where(m => m.ProductionCountries.Values == country)

            // From Novák Péter
            return Database.Movies.Where(m => m.ProductionCountries.ContainsKey(country)).OrderByDescending(g => g.Budget).FirstOrDefault();

            // throw new NotImplementedException();
        }

        /// <summary>
        /// A legnagyobb profitot realizáló film lekérdezése. A profit a film <see cref="Movie.Revenue"/> bevételének és <see cref="Movie.Budget"/> büdzséjének különbsége.
        /// </summary>
        /// <returns>Egy tuple (ennes), melyben a film és az általa realizált profit (USD) található.</returns>
        public (Movie Movie, long Profit) GetHighestProfitMovieEverMade()
        {
            // order by descending, select, first

            // return Database.Movies.OrderByDescending(m => m.Revenue - m.Budget).Take(1).Select(m => (m.Title, (m.Revenue - m.Budget)));
            /// return Database.Movies.OrderByDescending(m => m.Revenue - m.Budget).Take(1).Select(m => new Tuple<Movie, long>(m, 10));
            ////return Database.Movies.OrderByDescending(m => m.Revenue - m.Budget).First().Select(m => new Tuple<Movie, long>(m, 10));

            // From Novák Péter
            Movie TempMovie = Database.Movies.Where(m => m.Revenue != null && m.Budget != null).OrderByDescending(m => m.Revenue - m.Budget).First();
            long TempProfit = (long) TempMovie.Revenue - (long) TempMovie.Budget;

            return (TempMovie, TempProfit);
                        
            // throw new NotImplementedException();
        }

        /// <summary>
        /// A legnagyobb bukás (legkisebb profitot realizáló film profit értéke) mértékének lekérdezése.
        /// </summary>
        /// <returns>A legnagyobb bukás mértéke USD-ben.</returns>
        public long GetBiggestMovieFlopEver()
        {

            // return (long)Database.Movies.OrderByDescending(m => m.Revenue - m.Budget).Take(1).Sum(m => m.Revenue - m.Budget);

            // From Novák Péter
            Movie TempMovie = Database.Movies.Where(m => m.Revenue != null && m.Budget != null).OrderBy(m => m.Revenue - m.Budget).First();
            long TempProfit = (long)TempMovie.Revenue - (long)TempMovie.Budget;

            return (TempProfit);

            // throw new NotImplementedException();
        }

        /// <summary>
        /// Filmek keresése cím szerint.
        /// </summary>
        /// <param name="titleContains">A megadott címnek kis-nagybetűtől függetlenül, és ékezetek nélkül (lásd: <see cref="String.Contains(string, StringComparison)"/> és <see cref="StringComparison.OrdinalIgnoreCase"/>) kell szerepelnie a film <see cref="Movie.Title"/> címében.</param>
        /// <param name="page">A megadott oldalméretű oldal száma, 0-tól indexelve.</param>
        /// <param name="pageSize">Az oldalméret szabályozza, hány elem található az eredményhalmazban, illetve azt, hogy hány elemet hagyunk ki a szűretlen eredményhalmaz elejéről.</param>
        /// <returns>A (legfeljebb) <paramref name="pageSize"/> méretű kollekció a(z) <paramref name="page"/>. oldalról, amely filmek címe tartalmazza a megadott <paramref name="titleContains"/> paraméteret.</returns>
        public IEnumerable<Movie> GetMoviesOrderByPopularityWithTitleMatchPaged(string titleContains, int page = 0, int pageSize = 5)
        {
            // rendezzük popularity, 

            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            list.Skip(page * pageSize).Take(pageSize);


            // From Novák Péter
            /*
            return Database.Movies.Where(m => m.Title.RemoveDiacritics().Contains(titleContains, StringComparison.OrdinalIgnoreCase)).
                OrderByDescending(m => m.Popularity).Skip(page * pageSize).Take(pageSize);
            */
            // RemoveDiacritics-hez nuget csomag kell!!

            throw new NotImplementedException();
        }
    }
}
