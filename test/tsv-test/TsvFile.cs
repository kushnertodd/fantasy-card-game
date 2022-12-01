using fantasy_card_game_lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace fantasy_card_game_lib
{
    public class TsvFile
    {
        public static List<List<string>> ReadFile(string docPath, Errors errors)
        {
            var recList = new List<List<string>>();

            try
            {
                using (var file = new StreamReader(docPath))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        var delimiters = new char[] { '\t' };
                        var segments = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        recList.Add(segments.ToList());
                    }

                    file.Close();
                }
            }
            catch (IOException e)
            {
                errors.Add(Errors.MessageId.MISC_TEXT, e.Message);
            }
            return recList;
        }
    }
}
