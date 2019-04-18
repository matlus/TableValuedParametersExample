using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample
{
    internal enum Genre
    {
        Action,
        Animation,
        Drama,
        Musical,
        [EnumDescription("Sci-Fi")]
        [EnumDescription("SciFi")]
        SciFi,
        Thriller
    }
}
