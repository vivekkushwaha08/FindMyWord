namespace FindMyWord
{
    partial class findWordRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public findWordRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabFindMyWord = this.Factory.CreateRibbonTab();
            this.grpFindWord = this.Factory.CreateRibbonGroup();
            this.btnFindWord = this.Factory.CreateRibbonButton();
            this.tabFindMyWord.SuspendLayout();
            this.grpFindWord.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabFindMyWord
            // 
            this.tabFindMyWord.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tabFindMyWord.ControlId.OfficeId = "TabHome";
            this.tabFindMyWord.Groups.Add(this.grpFindWord);
            this.tabFindMyWord.Label = "TabHome";
            this.tabFindMyWord.Name = "tabFindMyWord";
            // 
            // grpFindWord
            // 
            this.grpFindWord.Items.Add(this.btnFindWord);
            this.grpFindWord.Name = "grpFindWord";
            // 
            // btnFindWord
            // 
            this.btnFindWord.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnFindWord.Image = global::FindMyWord.Properties.Resources.icon_search;
            this.btnFindWord.Label = "Find My Word";
            this.btnFindWord.Name = "btnFindWord";
            this.btnFindWord.ShowImage = true;
            this.btnFindWord.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnFindWord_Click);
            // 
            // findWordRibbon
            // 
            this.Name = "findWordRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tabFindMyWord);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.findWordRibbon_Load);
            this.tabFindMyWord.ResumeLayout(false);
            this.tabFindMyWord.PerformLayout();
            this.grpFindWord.ResumeLayout(false);
            this.grpFindWord.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabFindMyWord;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpFindWord;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnFindWord;
    }

    partial class ThisRibbonCollection
    {
        internal findWordRibbon findWordRibbon
        {
            get { return this.GetRibbon<findWordRibbon>(); }
        }
    }
}
