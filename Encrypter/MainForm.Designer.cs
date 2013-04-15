namespace Encrypter
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.書式OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._menuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this._textBox = new System.Windows.Forms.TextBox();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._fontDialog = new System.Windows.Forms.FontDialog();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this.書式OToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(392, 24);
            this._menuStrip.TabIndex = 0;
            // 
            // _menuItemFile
            // 
            this._menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemNew,
            this._menuItemOpen,
            this._menuItemSave,
            this._menuItemSaveAs,
            this.toolStripSeparator1,
            this._menuItemExit});
            this._menuItemFile.Name = "_menuItemFile";
            this._menuItemFile.Size = new System.Drawing.Size(66, 20);
            this._menuItemFile.Text = "ファイル(&F)";
            // 
            // _menuItemNew
            // 
            this._menuItemNew.Name = "_menuItemNew";
            this._menuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._menuItemNew.Size = new System.Drawing.Size(218, 22);
            this._menuItemNew.Text = "新規(&N)";
            this._menuItemNew.Click += new System.EventHandler(this._menuItemNew_Click);
            // 
            // _menuItemOpen
            // 
            this._menuItemOpen.Name = "_menuItemOpen";
            this._menuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._menuItemOpen.Size = new System.Drawing.Size(218, 22);
            this._menuItemOpen.Text = "開く(&O)...";
            this._menuItemOpen.Click += new System.EventHandler(this._menuItemOpen_Click);
            // 
            // _menuItemSave
            // 
            this._menuItemSave.Name = "_menuItemSave";
            this._menuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._menuItemSave.Size = new System.Drawing.Size(218, 22);
            this._menuItemSave.Text = "上書き保存(&S)";
            this._menuItemSave.Click += new System.EventHandler(this._menuItemSave_Click);
            // 
            // _menuItemSaveAs
            // 
            this._menuItemSaveAs.Name = "_menuItemSaveAs";
            this._menuItemSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this._menuItemSaveAs.Size = new System.Drawing.Size(218, 22);
            this._menuItemSaveAs.Text = "名前を付けて保存(&A)...";
            this._menuItemSaveAs.Click += new System.EventHandler(this._menuItemSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // _menuItemExit
            // 
            this._menuItemExit.Name = "_menuItemExit";
            this._menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this._menuItemExit.Size = new System.Drawing.Size(218, 22);
            this._menuItemExit.Text = "閉じる(&E)";
            this._menuItemExit.Click += new System.EventHandler(this._menuItemExit_Click);
            // 
            // 書式OToolStripMenuItem
            // 
            this.書式OToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFont});
            this.書式OToolStripMenuItem.Name = "書式OToolStripMenuItem";
            this.書式OToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.書式OToolStripMenuItem.Text = "書式(&O)";
            // 
            // _menuItemFont
            // 
            this._menuItemFont.Name = "_menuItemFont";
            this._menuItemFont.Size = new System.Drawing.Size(124, 22);
            this._menuItemFont.Text = "フォント(&F)...";
            this._menuItemFont.Click += new System.EventHandler(this._menuItemFont_Click);
            // 
            // _textBox
            // 
            this._textBox.AllowDrop = true;
            this._textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._textBox.Location = new System.Drawing.Point(0, 24);
            this._textBox.Multiline = true;
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(392, 349);
            this._textBox.TabIndex = 1;
            this._textBox.TextChanged += new System.EventHandler(this._textBox_TextChanged);
            this._textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this._textBox_DragDrop);
            this._textBox.DragEnter += new System.Windows.Forms.DragEventHandler(this._textBox_DragEnter);
            // 
            // _openFileDialog
            // 
            this._openFileDialog.Filter = "AESファイル|*.aes|すべてのファイル|*.*";
            this._openFileDialog.Title = "ファイルを開く";
            this._openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this._openFileDialog_FileOk);
            // 
            // _saveFileDialog
            // 
            this._saveFileDialog.Filter = "AESファイル|*.aes|すべてのファイル|*.*";
            this._saveFileDialog.Title = "名前を付けて保存";
            this._saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this._saveFileDialog_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(392, 373);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.Text = "Encrypter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem _menuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem _menuItemSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _menuItemExit;
        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem _menuItemSave;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem 書式OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _menuItemFont;
        private System.Windows.Forms.FontDialog _fontDialog;
    }
}

