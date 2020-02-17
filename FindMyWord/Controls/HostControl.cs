using System.Windows.Forms;

namespace FindMyWord.Controls
{
    /// <summary>
    /// Used to host wpf controls
    /// </summary>
    public partial class HostControl : UserControl
    {
        public HostControl()
        {
            InitializeComponent();
        }

        public HostControl(System.Windows.UIElement child)
        {
            InitializeComponent();
            this.wpfElementHost.Child = child;
        }
    }
}
