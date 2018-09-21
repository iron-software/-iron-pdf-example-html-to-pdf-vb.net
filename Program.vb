'========================================================================
' This conversion was produced by the Free Edition of
' Instant VB courtesy of Tangible Software Solutions.
' Order the Premium Edition at https://www.tangiblesoftwaresolutions.com
'========================================================================

Imports System
Imports System.IO
Imports IronPdf

Friend Class Program
	Shared Sub Main(ByVal args() As String)
		Console.WriteLine("Hold on tight!")

		Example1()
		Example2()

		Console.WriteLine("Done. Please find results under '{0}' directory.", Directory.GetCurrentDirectory())
		Console.WriteLine("Press any key to continue.")
		Console.ReadKey()
	End Sub

	Public Shared Sub Example1()
		' read html from file
		Dim html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestInvoice1.html"))

		Dim htmlToPdf = New HtmlToPdf()
		Dim pdf = htmlToPdf.RenderHtmlAsPdf(html)
		pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "HtmlToPdfExample1.Pdf"))
	End Sub

	Public Shared Sub Example2()
		Dim html = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "TestInvoice1.html"))

		Dim pdfPrintOptions = New PdfPrintOptions() With {
			.MarginTop = 50,
			.MarginBottom = 50,
			.Header = New SimpleHeaderFooter() With {
				.CenterText = "{pdf-title}",
				.DrawDividerLine = True,
				.FontSize = 16
			},
			.Footer = New SimpleHeaderFooter() With {
				.LeftText = "{date} {time}",
				.RightText = "Page {page} of {total-pages}",
				.DrawDividerLine = True,
				.FontSize = 14
			},
			.CssMediaType = IronPdf.PdfPrintOptions.PdfCssMediaType.Print
		}

		Dim htmlToPdf = New HtmlToPdf(pdfPrintOptions)
		Dim pdf = htmlToPdf.RenderHtmlAsPdf(html)
		pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "HtmlToPdfExample2.Pdf"))
	End Sub
End Class