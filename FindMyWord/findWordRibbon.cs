using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;

namespace FindMyWord
{
    public partial class findWordRibbon
    {
        private void findWordRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            Globals.ThisAddIn.CustomTaskPanes.Add(new Controls.HostControl(), "Find My Word");
            Globals.ThisAddIn.CustomTaskPanes[0].Visible = false;
        }

        private void btnFindWord_Click(object sender, RibbonControlEventArgs e)
        {
          Globals.ThisAddIn.CustomTaskPanes[0].Visible = true;
        }
    }
}
