using PdfiumViewer;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
namespace PdfProcessor
{
    public partial class Form1 : Form
    {
        private PdfViewer pdfViewer;
        public Form1()
        {
            InitializeComponent();
            InitializePdfViewer();
        }

        private void InitializePdfViewer()
        {
            // Initialize PdfViewer
            pdfViewer = new PdfViewer
            {
                Dock = DockStyle.Fill
            };

            // Add the PdfViewer to the panel
            panel1.Controls.Add(pdfViewer);
        }

        private void loadPdf_Click(object sender, EventArgs e)
        {
            // Open a file dialog to select a PDF file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Open PDF file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfFilePath = openFileDialog.FileName;
                LoadPdf(pdfFilePath);
            }

        }

        private void LoadPdf(string pdfFilePath)
        {
            try
            {
                var pdfDocument = PdfDocument.Load(pdfFilePath);
                pdfViewer.Document = pdfDocument;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void navigatePdf_Click(object sender, EventArgs e)
        {
            string bookmarkName = pdfBookmark.Text;
            if (NavigateToBookmark(bookmarkName) == -1){
                //Provided value is a subheading. Search for subheading 
                //NavigateToSubheading(bookmarkName);
            }




        }

        private int NavigateToBookmark(string bookmarkName)
        {
            if (pdfViewer.Document == null) return -1;
            MessageBox.Show(string.Join(Environment.NewLine,pdfViewer.Document.Bookmarks));

            var bookmark = FindBookmark(pdfViewer.Document.Bookmarks, bookmarkName);
            if (bookmark != null)
            {
                pdfViewer.Renderer.ZoomMode = PdfViewerZoomMode.FitWidth;
                pdfViewer.Renderer.Page = bookmark.PageIndex;
                return 0;
            }
            else
            {
                MessageBox.Show("Bookmark not found");
                return -1;
            }
        }


        private PdfBookmark FindBookmark(PdfBookmarkCollection bookmarks, string bookmarkName)
        {
            foreach (var bookmark in bookmarks)
            {
                if (bookmark.Title.Equals(bookmarkName, StringComparison.OrdinalIgnoreCase))
                {
                    return bookmark;
                }
                var found = FindBookmark(bookmark.Children, bookmarkName);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }

        private void NavigateToSubheading(string subheading)
        {

            MessageBox.Show($"Trying to fins subheading {subheading}");
            if (pdfViewer.Document == null)
                return;

            // Search for the subheading in the PDF document
            int pageIndex = FindSubheadingPageIndex(pdfViewer.Document, subheading);
            if (pageIndex >= 0)
            {
                pdfViewer.Renderer.Page = pageIndex;
            }
            else
            {
                MessageBox.Show($"Subheading '{subheading}' not found in the PDF document.");
            }
        }

        private int FindSubheadingPageIndex(IPdfDocument document, string subheading)
        {
            // Iterate through bookmarks to find the subheading
            foreach (var bookmark in document.Bookmarks)
            {
                MessageBox.Show($"Finding subheading for bookmark {bookmark}");
                int pageIndex = FindSubheadingInBookmark(bookmark, subheading);
                if (pageIndex >= 0)
                {
                    return pageIndex;
                }
            }
            return -1; // Subheading not found
        }

        private int FindSubheadingInBookmark(PdfBookmark bookmark, string subheading)
        {
            
            // Check if the current bookmark matches the subheading
            if (bookmark.Title.Equals(subheading, StringComparison.OrdinalIgnoreCase))
            {
                return bookmark.PageIndex;
            }

            // Recursively search child bookmarks
            foreach (var childBookmark in bookmark.Children)
            {
                MessageBox.Show(childBookmark.Title);
                int pageIndex = FindSubheadingInBookmark(childBookmark, subheading);
                if (pageIndex >= 0)
                {
                    return pageIndex;
                }
            }

            return -1; // Subheading not found in this bookmark or its children
        }


    }




}
