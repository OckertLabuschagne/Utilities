using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Microsoft.Office.Interop.Word;

namespace com.GPA.OfficeIntegration
{
    /// <summary>
    /// This user control encaptulates Microsoft Word.
    /// </summary>
    [Description("A user control encaptulating Microsoft Word")]
    public partial class MSWordControl : UserControl
    {
        Microsoft.Office.Interop.Word.Application Word = null;
        int wordWnd = 0,
            borderWidth = 2,
            borderHeight = 1;
        object newTemplate = false,
            readOnly = true,
            isVisible = true,
            boolFalse = false;
        object docType = 0;
        object missing = System.Reflection.Missing.Value;
        Document _ActiveDocument;

        public Document ActiveDocument
        {
            get { return _ActiveDocument; }
            set
            {
                _ActiveDocument = value;
            }
        }

        [Category("Layout")]
        [Description("The top and bottom margin")]
        public int BorderHeight
        {
            get { return borderHeight; }
            set { borderHeight = value; }
        }

        [Category("Layout")]
        [Description("The left and right margin")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; }
        }

        #region "API usage declarations"

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
            );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        static extern bool MoveWindow(
            int hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint
            );

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        static extern Int32 DrawMenuBar(
            Int32 hWnd
            );

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        static extern Int32 GetMenuItemCount(
            Int32 hMenu
            );

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern Int32 GetSystemMenu(
            Int32 hWnd,
            bool bRevert
            );

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern Int32 RemoveMenu(
            Int32 hMenu,
            Int32 nPosition,
            Int32 wFlags
            );


        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;

        #endregion

        public MSWordControl()
        {
            InitializeComponent();
            //StartWord();
        }

        public Document StartWord(string FileName)
        {
            object fileName = FileName;
            if (Word != null)
                Word = null;
            Word = new Microsoft.Office.Interop.Word.Application();
            BindWord();
            if ((FileName == null) || (FileName.Length == 0))
                _ActiveDocument = Word.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);
            else if (FileName.Contains(".dotx") || FileName.Contains(".dotm"))
                if (File.Exists(FileName))
                    _ActiveDocument = Word.Documents.Add(ref fileName, ref missing, ref missing, ref isVisible);
                else
                    _ActiveDocument = Word.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);
            else
                    _ActiveDocument = OpenDocument(FileName);
            return _ActiveDocument;
        }

        public Document AddDocument(string FileName)
        {
            if (string.IsNullOrEmpty(FileName))
                _ActiveDocument = Word.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);
            else
                _ActiveDocument = OpenDocument(FileName);
            return _ActiveDocument;
        }

        public Document StartWord()
        {
            if (Word != null)
                Word = null;
            Word = new Microsoft.Office.Interop.Word.Application();
            BindWord();
            _ActiveDocument = Word.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);
            return _ActiveDocument;
        }

        public Document StartWord(Document document)
        {
            if (Word != null) 
                Word = null;
            Word = new Microsoft.Office.Interop.Word.Application();
            _ActiveDocument = document;
            BindWord();
            return _ActiveDocument;
        }

        private void BindWord()
        {
            Word.WindowSize += new ApplicationEvents4_WindowSizeEventHandler(Word_WindowSize);
            Word.DocumentBeforeClose += new ApplicationEvents4_DocumentBeforeCloseEventHandler(Word_DocumentBeforeClose);
            Word.DocumentOpen += new ApplicationEvents4_DocumentOpenEventHandler(Word_DocumentOpen);
            Word.Visible = true;
            Word.Top = 0;
            Word.Left = 0;
            Word.Width = Width - 2;
            Word.Height = Height - 2;
            Word.Activate();

            wordWnd = FindWindow("Opusapp", null);
            if (wordWnd != 0)
            {
                SetParent(wordWnd, this.Handle.ToInt32());
                SetWindowPos(wordWnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height - 50, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);
                MoveWindow(
                    wordWnd,
                    borderWidth,
                    borderHeight + borderHeight,
                    this.Bounds.Width - 2 * borderWidth,
                    this.Bounds.Height - 4 * borderHeight,
                    true);
            }
        }

        void Word_DocumentBeforeClose(Document Doc, ref bool Cancel)
        {
            OnBeforeDocumentClose(Doc, ref Cancel);
        }

        void Word_WindowSize(Document Doc, Window Wn)
        {
            if (WordResize != null)
                WordResize(Doc, Wn);
        }

        bool Resizing = false;
        protected virtual void OnSizeChange(Document Doc, Window Wn)
        {
            if (!Resizing)
            {
                Resizing = true;
                if (WordResize != null)
                    WordResize(Doc, Wn);
                Resizing = false;
            }
        }

        protected virtual void OnBeforeDocumentClose(Document Doc, ref bool Cancel)
        {
            if (BeforeDocumentClose != null)
                BeforeDocumentClose(Doc, ref Cancel);
        }

        public event ApplicationEvents4_DocumentBeforeCloseEventHandler BeforeDocumentClose;
        public event ApplicationEvents4_WindowSizeEventHandler WordResize;

        void Word_DocumentOpen(Document Doc)
        {
            _ActiveDocument = Doc;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Resizing = true;
            if (wordWnd != 0)
                MoveWindow(
                                wordWnd,
                                borderWidth,
                                borderHeight,
                                this.BorderStyle == BorderStyle.Fixed3D ? this.Width - 3 * borderWidth : this.Width - 2 * borderWidth,
                                this.BorderStyle == BorderStyle.Fixed3D ? this.Height - 3 * borderHeight : this.Height - 2 * borderHeight,
                                true);
            Resizing = false;
        }

        public void CloseDocument()
        {
            CloseDocument(false);
        }

        public void CloseDocument(bool save)
        {
            try
            {
                object _save = save;
                Word.Quit(ref _save, ref missing, ref missing);
            }
            catch (COMException excp)
            {
            }
        }

        /// <summary>
        /// Open an existing word document
        /// </summary>
        /// <param name="path">The path to the document to be opened</param>
        public Document OpenDocument(string path)
        {
            try
            {
                object fileName = path;
                return Word.Documents.Open(ref fileName,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref isVisible,
                    ref missing,
                    ref missing,
                    ref missing,
                    ref missing);
            }
            catch (Exception excp)
            {
                Word.Quit(ref boolFalse, ref missing, ref missing);
                //Utilities.HandleException(excp);
                return null;
            }
        }

        /// <summary>
        /// Create and show a new document using the standard template
        /// </summary>
        public void NewDocument()
        {
            _ActiveDocument = (Document)Word.Documents.Add(ref missing, ref missing, ref missing, ref isVisible);
        }

        /// <summary>
        /// Create a new document based on the provided template
        /// </summary>
        /// <param name="templatePath">The path to the template</param>
        public void NewDocument(string templatePath)
        {
            object tp = templatePath;
            _ActiveDocument = (Document)Word.Documents.Add(ref tp, ref missing, ref missing, ref isVisible);
        }

        /// <summary>
        /// Save the current Document
        /// </summary>
        public void Save()
        {
            _ActiveDocument.Save();
        }

        /// <summary>
        /// Save the current document as another file
        /// </summary>
        /// <param name="fileName">The new file name of the document</param>
        public void SaveAs(string fileName)
        {
            object FileName = fileName;
            object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
            switch (Path.GetExtension(fileName).ToLower())
            {
                case ".pdf":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                    break;
                case ".xml":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXML;
                    break;
                case ".docx":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument;
                    break;
                case ".doc":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument97;
                    break;
                case ".rtf":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;
                    break;
                case ".html":
                    FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;
                    break;
            }
            object LockComments = false;
            object AddToRecentFiles = true;
            object ReadOnlyRecommended = false;
            object EmbedTrueTypeFonts = false;
            object SaveNativePictureFormat = true;
            object SaveFormsData = true;
            object SaveAsAOCELetter = false;
            object Encoding = Microsoft.Office.Core.MsoEncoding.msoEncodingUSASCII;
            object InsertLineBreaks = false;
            object AllowSubstitutions = false;
            object LineEnding = Microsoft.Office.Interop.Word.WdLineEndingType.wdCRLF;
            object AddBiDiMarks = false;

            _ActiveDocument.SaveAs(ref FileName, ref FileFormat, ref LockComments,
                ref missing, ref AddToRecentFiles, ref missing,
                ref ReadOnlyRecommended, ref EmbedTrueTypeFonts,
                ref SaveNativePictureFormat, ref SaveFormsData,
                ref SaveAsAOCELetter, ref Encoding, ref InsertLineBreaks,
                ref AllowSubstitutions, ref LineEnding, ref AddBiDiMarks);
        }

        /// <summary>
        /// Save the document as a Word 2000 compatable document
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs2000(string fileName)
        {
            object FileName = fileName;
            object FileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF;
            object LockComments = false;
            object AddToRecentFiles = true;
            object ReadOnlyRecommended = false;
            object EmbedTrueTypeFonts = false;
            object SaveNativePictureFormat = true;
            object SaveFormsData = true;
            object SaveAsAOCELetter = false;

            _ActiveDocument.SaveAs2000(ref FileName, ref FileFormat, ref LockComments,
                ref missing, ref AddToRecentFiles, ref missing,
                ref ReadOnlyRecommended, ref EmbedTrueTypeFonts,
                ref SaveNativePictureFormat, ref SaveFormsData,
                ref SaveAsAOCELetter);
        }

        public void AddRange(Range range)
        {
            object direction = WdCollapseDirection.wdCollapseEnd;
            _ActiveDocument.ActiveWindow.Selection.Collapse(ref direction);
            _ActiveDocument.ActiveWindow.Selection.InsertXML(range.WordOpenXML, ref missing);
        }

        public void AddRange(string openXML)
        {
            object direction = WdCollapseDirection.wdCollapseEnd;
            _ActiveDocument.ActiveWindow.Selection.Collapse(ref direction);
            _ActiveDocument.ActiveWindow.Selection.InsertXML(openXML, ref missing);
        }

        public Table AddTable(int rows, int columns)
        {
            return _ActiveDocument.Tables.AddOld(_ActiveDocument.ActiveWindow.Selection.Range, rows, columns);
        }

        public Selection Selection
        {
            get{ return _ActiveDocument.ActiveWindow != null && _ActiveDocument.ActiveWindow.Selection != null ? _ActiveDocument.ActiveWindow.Selection : null; }
        }

        public Range SelectedRange
        {
            get { return _ActiveDocument.ActiveWindow != null && _ActiveDocument.ActiveWindow.Selection != null ? _ActiveDocument.ActiveWindow.Selection.Range : null; }
        }

        public string SelectedText
        {
            get { return _ActiveDocument.ActiveWindow != null && _ActiveDocument.ActiveWindow.Selection != null ? _ActiveDocument.ActiveWindow.Selection.Text : string.Empty; }
        }
    }
}