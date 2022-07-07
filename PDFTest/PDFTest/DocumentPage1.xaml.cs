using Syncfusion.Pdf.Parsing;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace PDFTest
{
	public partial class DocumentPage1 : ContentPage
	{
        private Stream m_pdfDocumentStream;

        public DocumentPage1()
		{
			InitializeComponent();
            //Points to the file location of the PDF that's being loaded in to the application, PDF is stored on the app and not locally in this instance
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("PDFTest.Assets.FormFillingDocument.pdf");
            pdfViewerControl.LoadDocument(m_pdfDocumentStream);

        }

        //Calling on Save function implemented on the local devices
        private void SavePDFSignature(object sender, EventArgs e)
        {
            Xamarin.Forms.Image image = new Xamarin.Forms.Image();
            signaturePadControl.Save();
            //Defining the image source directly within the function
            image.Source = signaturePadControl.ImageSource;
            PdfLoadedDocument loadedDocument = new PdfLoadedDocument(m_pdfDocumentStream);
            
            PdfLoadedForm loadedForm = loadedDocument.Form;
            //Requires fields on form to work
            Syncfusion.Drawing.Rectangle bounds = (loadedForm.Fields[6] as PdfLoadedStyledField).Bounds;    
            
            pdfViewerControl.AddStamp(image, 1, new Xamarin.Forms.Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height));
        }

        private async void SveButton(object sender, EventArgs e)
        {
            string outputFilePath = "/Files/sdk_gphone_x86_64_arm64/Download";

            try
            {
                using (var pdfStream = await pdfViewerControl.SaveDocumentAsync())
                {
                    pdfStream.Seek(0, SeekOrigin.Begin);
                    using (var outputStream = File.OpenWrite(outputFilePath))
                    {
                        await pdfStream.CopyToAsync(outputStream);
                    }
                }
            }
            catch (Exception exc)
            {
                //do something to handle this
            }
        }

        private async void BackButton(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
