using System;
using System.Windows;
using System.Windows.Controls;

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

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string textToSearch = txtLookupText.Text;
            if (!string.IsNullOrEmpty(textToSearch))
            {
                try
                {
                    Microsoft.Office.Interop.Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                    if (document != null)
                    {

                        Microsoft.Office.Interop.Word.Range rng = document.Content;
                        rng.Find.ClearFormatting();
                        rng.Find.Forward = true;
                        rng.Find.Text = textToSearch;
                        object highlightColor = System.Drawing.Color.Yellow;

                        var rndForScroll = document.Content;
                        // Find fist occurence
                        if (rndForScroll.Find.Execute(FindText: textToSearch, MatchWholeWord: true) && rndForScroll.Paragraphs.First != null)
                        {
                            // scroll to first occurence
                            Globals.ThisAddIn.Application.ActiveWindow.ScrollIntoView(rndForScroll.Paragraphs.First.Range, true);
                            //Highlight all occurence
                            rng.Find.HitHighlight(FindText: textToSearch, HighlightColor: highlightColor, MatchWholeWord: true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
