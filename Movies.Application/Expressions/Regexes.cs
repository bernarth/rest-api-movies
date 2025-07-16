using System.Text.RegularExpressions;

namespace Movies.Application.Expressions;

public static partial class Regexes
{
    [GeneratedRegex(@"[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 5)]
    public static partial Regex SlugRegex();
}