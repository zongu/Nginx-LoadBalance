using System.Text.Json;
using System.Text.RegularExpressions;
using WebApiUnit.Applibs;

var argsStr = string.Join("_", args);

Console.WriteLine($"args: {argsStr}");

var dic = ArgvFormat().ToDictionary();

Console.WriteLine($"args format:{JsonSerializer.Serialize(dic)}");

ConfigHelper.Port = dic.TryGetValue("PORT", out var _portStr) && int.TryParse(_portStr, out var _port) ? _port : 9000;
ConfigHelper.Number = dic.TryGetValue("NO", out var _noStr) && int.TryParse(_noStr, out var _no) ? _no : 0;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

builder.WebHost.UseUrls($"http://*:{ConfigHelper.Port}");

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();


IEnumerable<(string key, string value)> ArgvFormat()
{
    foreach(var argv in args)
    {
        var reg = @"\w*\=\w*";

        if (Regex.IsMatch(argv, reg))
        {
             yield return (argv.Split('=')[0], argv.Split('=')[1]);
        }
    }
}