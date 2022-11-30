using System.ComponentModel;

class Errors
{
    private List<string> errorList = new List<string>();
    public void Add(string error)
    {
        errorList.Add(error);
    }
    public bool Have()
    {
        return errorList.Count > 0;
    }
    public string ToString()
    {
        string text = "";
        foreach (string error in errorList) { text += error + "\n"; }
        return text; 
    }
}
class TestClass
{
    static List<List<string>> ReadDelimitedFile(string docPath, Errors errors)
    {
        var recList = new List<List<string>>();

        // Read the file and display it line by line.

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
            errors.Add(e.Message);
        }
        return recList;
    }

    static void Main(string[] args)
    {
        Errors errors = new Errors();
        List<List<string>> lines = ReadDelimitedFile("cards.db", errors);
        if (errors.Have())
            Console.WriteLine("errors: " + errors.ToString());
        else
            Console.WriteLine("read " + lines.Count + " lines");
        int a = 1;
    }
}
