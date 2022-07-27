using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConverter.Service.Extensions
{
    public static class StringHtmlExtensions
    {
        public static string GetTagWithValue(this string value,string tag)
        {
            return $"<{tag}>{value}</{tag}>";

        }
    }
}
