namespace PDFView.Helper
{
    public class PersonHelper
    {
        public static string ToHtmlFile(List<Models.Person> data) {
            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "HtmlTemplates" , "htmlpage.html");
            string tempHtml = File.ReadAllText(templatePath);
            return tempHtml;
        }
    }
}
