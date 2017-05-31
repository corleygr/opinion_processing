using System;
using System.Text.RegularExpressions;

public class NumberTransform : ICommand
{
    private string _pattern = @"(\d+)\.(\d*)";

    public string Execute(string data){
        var rgx = new Regex(_pattern);
        var output = rgx.Replace(data," $1$2");
        return output;
    }
}