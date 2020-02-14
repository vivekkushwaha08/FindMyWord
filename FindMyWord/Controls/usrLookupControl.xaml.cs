using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                Microsoft.Office.Interop.Word.Document document = Globals.ThisAddIn.Application.ActiveDocument;
                if (document != null)
                {
                    object missing = null;
                    Microsoft.Office.Interop.Word.Range rng = document.Content;
                    rng.Find.ClearFormatting();
                    rng.Find.Forward = true;
                    rng.Find.Text = textToSearch;
                    object highlightColor = System.Drawing.Color.Yellow;
                    if(rng.Find.HitHighlight( 
                        textToSearch, ref highlightColor, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing, ref missing))
                    {
                        
                    }
                }
            }
        }
    }
}
