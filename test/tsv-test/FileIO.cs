using System.ComponentModel;

namespace TSV_test
{
    class FileIO
    {
        public static List<List<string>> ReadDelimitedFile(string docPath, Errors errors)
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
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
            return recList;
        }
    }
}