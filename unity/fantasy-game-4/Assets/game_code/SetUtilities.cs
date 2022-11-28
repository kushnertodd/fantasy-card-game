using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fantasy_card_game_lib
{
    public class SetUtilities<T>
    {
        public static string ToString(HashSet<T> set, string prefix = "", string separator = " ", string suffix = "")
        {
            string description = prefix;
            bool first = true;

            foreach (T t in set)
            {
                if (first)
                {
                    first = false;
                    if (t != null) description += separator + t.ToString();
                }
                else
                    if (t != null) description += separator + t.ToString();
            }
            return description + suffix;
        }
    }
}