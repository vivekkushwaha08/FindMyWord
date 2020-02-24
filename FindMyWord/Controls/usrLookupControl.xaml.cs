using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;

namespace FindMyWord.Controls
{
    /// <summary>
    /// Interaction logic for usrLookupControl.xaml
    /// </summary>
    public partial class usrLookupControl : UserControl
    {
        public usrLookupControl()
        {
            InitializeComponent();            
            this.btnSearch.Click += BtnSearch_Click;           
        }

        const string SHAPE_NAME = "FoundHighlight";

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        private void Search()
        {
            string textToSearch = txtLookupText.Text;
            if (!string.IsNullOrEmpty(textToSearch))
            {
                try
                {
                    Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
                    if (document != null)
                    {
                        //TODO
                        //Draw shapes on other pages on scroll
                        IntPtr handle = new IntPtr(document.ActiveWindow.Hwnd);
                        ScrollEvent scrollEvent = new ScrollEvent();
                        scrollEvent.AssignHandle(handle);

                        document.BeforeSave += Document_BeforeSave;
                        document.BeforeClose += Document_BeforeClose;

                        DeleteShapes();

                        Range currentlyVisibleRange = GetCurrentlyVisibleRange();

                        foreach (Range word in document.Words)
                        {
                            if (word.Text.Trim().ToLower() == textToSearch.Trim().ToLower())
                            {
                                if (Intersects(currentlyVisibleRange, word))
                                {
                                    float leftPosition = (float)word.Information[WdInformation.wdHorizontalPositionRelativeToPage];
                                    float topPosition = (float)word.Information[WdInformation.wdVerticalPositionRelativeToPage];

                                    document.ActiveWindow.GetPoint(out int left, out int top, out int width, out int height, word);
                                    var wordWidth = width - (width * 28 / 100);
                                    var wordHeight = word.Font.Size + (word.Font.Size * 28 / 100);
                                    DrawIt(word, leftPosition, topPosition, wordWidth, wordHeight);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Document_BeforeClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DeleteShapes();
        }

        private void Document_BeforeSave(object sender, Microsoft.Office.Tools.Word.SaveEventArgs e)
        {
            DeleteShapes();
        }

        private void DeleteShapes()
        {
            Microsoft.Office.Tools.Word.Document document = Globals.Factory.GetVstoObject(Globals.ThisAddIn.Application.ActiveDocument);
            if (document != null)
            {
                var shapes = document.Shapes;
                var shapesCount = shapes.Count;
                int deletedCount = 0;
                for (var i = 1; i <= shapesCount; i++)
                {
                    var shape = shapes[i - deletedCount];
                    if (shape.Name == SHAPE_NAME)
                    {
                        shape.Delete();
                        deletedCount++;
                    }
                }                             
            }
        }

        private void DrawIt(object rangeObject, float left, float top, float width, float height)
        {
            var document = Globals.ThisAddIn.Application.ActiveDocument;
            var shape = document.Shapes.AddShape((int)Microsoft.Office.Core.MsoAutoShapeType.msoShapeRoundedRectangle, left, top, width, height, ref rangeObject);            
            if (shape == null) return;
            shape.Name = SHAPE_NAME;
            shape.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            shape.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            shape.Fill.Transparency = .7f;
            shape.ConvertToInlineShape();            
            shape.WrapFormat.Type = WdWrapType.wdWrapBehind;
        }

        private Range GetCurrentlyVisibleRange()
        {
            try
            {
                var application = Globals.ThisAddIn.Application;
                var activeWindow = application.ActiveWindow;
                var left = application.PointsToPixels(activeWindow.Left);
                var top = application.PointsToPixels(activeWindow.Top);
                var width = application.PointsToPixels(activeWindow.Width);
                var height = application.PointsToPixels(activeWindow.Height);
                var usableWidth = application.PointsToPixels(activeWindow.UsableWidth);
                var usableHeight = application.PointsToPixels(activeWindow.UsableHeight);
                var startRangeX = left;
                var startRangeY = top;
                var endRangeX = startRangeX + width;
                var endRangeY = startRangeY + height;
                Range start = (Range)activeWindow.RangeFromPoint((int)startRangeX, (int)startRangeY);
                Range end = (Range)activeWindow.RangeFromPoint((int)endRangeX, (int)endRangeY);
                Range r = application.ActiveDocument.Range(start.Start, end.Start);
                return r;
            }
            catch (COMException)
            {
                return null;
            }
        }
        private bool Intersects(Range a, Range b)
        {
            return a.Start <= b.End && b.Start <= a.End;
        }        
    }
}
