using AngleSharp.Html.Parser;

namespace Core;

public static class HtmlHelper
{
    public static IEnumerable<string> GetLinks(Stream source, string linkExtension)
    {
        var document = new HtmlParser(new HtmlParserOptions()).ParseDocument(source);
        return from element in document.QuerySelectorAll("a")
            select element.GetAttribute("href")
            into target
            where target != null && target.EndsWith(linkExtension)
            select target[..^linkExtension.Length];
    }
}