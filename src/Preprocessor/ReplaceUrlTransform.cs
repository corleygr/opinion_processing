using System;
using System.Collections;
using System.Text.RegularExpressions;


public class ReplaceUrlTransform:ICommand 
{
   private string _pattern = @"(http|https).+?(com|COM|htm|HTML|org|ORG|edu|EDU|net|NET|gov|GOV)";
   private string _fileEndings = @"\.(html|HTML|htm|HTM|pdf|PDF|txt|TXT)";

    public string Execute(string data){
        var rgx = new Regex(_pattern);
        var output = rgx.Replace(data,"website");
        rgx = new Regex(_fileEndings);
        output = rgx.Replace(data,"$1");
        return output;
    }
}