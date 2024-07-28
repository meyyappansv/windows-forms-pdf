namespace PdfProcessor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            loadPdf = new Button();
            pdfBookmark = new TextBox();
            navigatePdf = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(34, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(504, 262);
            panel1.TabIndex = 0;
            // 
            // loadPdf
            // 
            loadPdf.Location = new Point(658, 52);
            loadPdf.Name = "loadPdf";
            loadPdf.Size = new Size(113, 29);
            loadPdf.TabIndex = 1;
            loadPdf.Text = "loadFile";
            loadPdf.UseVisualStyleBackColor = true;
            loadPdf.Click += loadPdf_Click;
            // 
            // pdfBookmark
            // 
            pdfBookmark.Location = new Point(658, 107);
            pdfBookmark.Name = "pdfBookmark";
            pdfBookmark.Size = new Size(124, 23);
            pdfBookmark.TabIndex = 2;
            // 
            // navigatePdf
            // 
            navigatePdf.Location = new Point(658, 154);
            navigatePdf.Name = "navigatePdf";
            navigatePdf.Size = new Size(119, 25);
            navigatePdf.TabIndex = 3;
            navigatePdf.Text = "navigateBookmark";
            navigatePdf.UseVisualStyleBackColor = true;
            navigatePdf.Click += navigatePdf_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(navigatePdf);
            Controls.Add(pdfBookmark);
            Controls.Add(loadPdf);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button loadPdf;
        private TextBox pdfBookmark;
        private Button navigatePdf;
    }
}
