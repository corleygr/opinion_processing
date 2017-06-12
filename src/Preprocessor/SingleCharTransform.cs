using System;
using System.Text.RegularExpressions;

public class SingleCharTransform : ICommand
{
    private string _whiteSpace = @"\s";
    private string _pattern = @"([A-Z])\.";

    public string Execute(string data)
    {
        var output = data;
        var rgx = new Regex(_pattern);
        output = rgx.Replace(data,"$1");
/* 
        for( int i=1; i < 7; i++)
        {
            output = Replace(output, i);
        }
        */
        return output;
    }
/* 
    private string Replace(string data, int cnt)
    {
        var pat = _whiteSpace;
        var rep = string.Empty;
        for( int i = 1; i <= cnt; i++)
        {
            pat += _pattern;
            rep += "$"+i.ToString();
        }
        var rgx = new Regex(pat);
        var output = rgx.Replace(data,rep);
        return output;
    }
    */
}