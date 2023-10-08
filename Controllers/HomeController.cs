using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PDFView.Helper;
using PDFView.Models;
using Razor.Templating.Core;

namespace PDFView.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IConverter _convert;
        public HomeController(IConverter converter) { 
            _convert = converter;
        }
        public async Task<IActionResult> Index()
        {
            String fileName = "persons.pdf";
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Top = 20,
                    Left = 20,
                    Right = 20
                },
                DocumentTitle = "Person",
                Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PersonHelper.ToHtmlFile(Person.GEtData()),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            _convert.Convert(pdf);
            String result = $"Files{fileName}";
            await Task.Yield();
            return Ok(result);
        }


        public IActionResult download()
        {
            String fileName = "persons.pdf";
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Top = 20,
                    Left = 20,
                    Right = 20
                },
                DocumentTitle = "Person",
                //Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PersonHelper.ToHtmlFile(Person.GEtData()),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            byte[] pdfView = _convert.Convert(pdf);
            Response.Headers.ContentType = "application/pdf";
            return File(pdfView, "application/pdf", "generated.pdf");
        }


        public IActionResult view()
        {
            String fileName = "persons.pdf";
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Top = 20,
                    Left = 20,
                    Right = 20
                },
                DocumentTitle = "Person",
                //Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = PersonHelper.ToHtmlFile(Person.GEtData()),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            byte[] pdfView = _convert.Convert(pdf);
            Response.Headers.ContentType = "application/pdf";
            return File(pdfView, "application/pdf");
        }





        public async Task<IActionResult> pdf() {
            var viewPdf = await RazorTemplateEngine.RenderAsync("~/Views/Home/pdf.cshtml");


            String fileName = "persons.pdf";
            var glb = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings()
                {
                    Bottom = 20,
                    Top = 20,
                    Left = 20,
                    Right = 20
                },
                DocumentTitle = "Person",
                //Out = Path.Combine(Directory.GetCurrentDirectory(), "Exports", fileName)

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = viewPdf,
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = null }
            };

            var pdf = new HtmlToPdfDocument
            {
                GlobalSettings = glb,
                Objects = { objectSettings }
            };

            byte[] pdfView = _convert.Convert(pdf);
            Response.Headers.ContentType = "application/pdf";
            return File(pdfView, "application/pdf");


        }

    }
}
