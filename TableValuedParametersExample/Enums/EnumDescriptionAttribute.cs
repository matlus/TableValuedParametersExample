using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableValuedParametersExample
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    internal sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; }
        public EnumDescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
