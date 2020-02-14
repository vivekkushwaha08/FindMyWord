using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindMyWord.Controls
{
    public partial class HostControl : UserControl
    {
        public HostControl()
        {
            InitializeComponent();
            this.elementHost1.Child = new usrLookupControl();
        }
    }
}
