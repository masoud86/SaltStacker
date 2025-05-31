using Markdig;

namespace SaltStacker.Common.Helper
{
    public static class HtmlHelper
    {
        public static string MarkdownToHtml(string markdown)
        {
            return Markdown.ToHtml(markdown);
        }
    }
}
