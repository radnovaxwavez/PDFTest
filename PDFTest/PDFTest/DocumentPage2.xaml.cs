using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.SfPdfViewer.XForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDFTest
{
	public partial class DocumentPage2 : ContentPage
	{
        private Stream m_pdfDocumentStream;
        public DocumentPage2()
		{
			InitializeComponent();
            //Points to the file location of the PDF that's being loaded in to the application, PDF is stored on the app and not locally in this instance
            m_pdfDocumentStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("PDFTest.Assets.FormFillingDocument.pdf");
            pdfViewerControl.LoadDocument(m_pdfDocumentStream);
           
        }
       
        //Calling on Save function implemented on the local devices
        private void Button_Clicked(object sender, EventArgs e)
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
    }
}
