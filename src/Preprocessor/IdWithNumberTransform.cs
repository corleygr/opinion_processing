using System;
using System.Text.RegularExpressions;

public class IdWithNumberTransform : ICommand
{
    private string _pattern = @"(\d+Id)\.";

    public string Execute(string data){
        var rgx = new Regex(_pattern);
        var output = rgx.Replace(data,"$1");
        return output;
    }
}