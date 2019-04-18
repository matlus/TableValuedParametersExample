﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample.DataLayer
{
    internal static class ModelAdapterMovies
    {
        public static IEnumerable<ImdbMovie> ToImdbMovies(DbDataReader dbDataReader)
        {
            while (dbDataReader.Read())
            {
                yield return new ImdbMovie(
                    title: (string)dbDataReader[0],
                    genre: GenreParser.Parse((string)dbDataReader[1]),
                    year: (int)dbDataReader[2],
                    imageUrl: (string)dbDataReader[3]
                    );
            }
        }
    }
}
