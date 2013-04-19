using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Encrypter.Properties;
using System.Diagnostics;

namespace Encrypter
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region フィールド・プロパティ

        /// <summary>
        /// 編集中かどうか
        /// </summary>
        private bool _isModified;

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _textBox.Font = new Font(AppSetting.Instance.FontFamilyName, AppSetting.Instance.Size);
            _textBox.ForeColor = AppSetting.Instance.ForeColor;
        }

        /// <summary>
        /// 新規ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemNew_Click(object sender, EventArgs e)
        {
            // 変更中かどうか
            if (_isModified)
            {
                // 保存確認
                if (!SaveConfirm())
                {
                    return;
                }
            }

            // 新規
            _textBox.Text = string.Empty;
            _openFileDialog.FileName = Resources.DefaultFileName;
            _isModified = false;
            UpdateTitle();
        }

        /// <summary>
        /// 開くボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemOpen_Click(object sender, EventArgs e)
        {
            // 変更中かどうか
            if (_isModified)
            {
                // 保存確認
                if (!SaveConfirm())
                {
                    return;
                }
            }

            // ファイルを開く
            _openFileDialog.ShowDialog(this);
        }

        /// <summary>
        /// 上書き保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemSave_Click(object sender, EventArgs e)
        {
            // デフォルトファイルと同じ場合
            if (_openFileDialog.FileName == Resources.DefaultFileName)
            {
                _saveFileDialog.ShowDialog(this);
            }
            else
            {
                try
                {
                    string writeText = AESConveter.Encrypt(_textBox.Text);
                    File.WriteAllText(_openFileDialog.FileName, writeText);                    
                    _isModified = false;
                    UpdateTitle();
                }
                catch (Exception)
                {
                    MessageBox.Show(this, Resources.WarnMessageWriteFileFailed, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 名前を付けて保存ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemSaveAs_Click(object sender, EventArgs e)
        {
            _saveFileDialog.ShowDialog(this);
        }

        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ファイルを開くが選択された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string readText = File.ReadAllText(_openFileDialog.FileName);
                _textBox.Text = AESConveter.Decrypt(readText);
                _isModified = false;
                UpdateTitle();
            }
            catch (Exception)
            {
                MessageBox.Show(this, Resources.WarnMessageReadFileFailed, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// ファイルの保存が選択された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string writeText = AESConveter.Encrypt(_textBox.Text);
                File.WriteAllText(_saveFileDialog.FileName, writeText);
                _openFileDialog.FileName = _saveFileDialog.FileName;
                _isModified = false;
                UpdateTitle();
            }
            catch (Exception)
            {
                MessageBox.Show(this, Resources.WarnMessageWriteFileFailed, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// テキストボックスの状態が変わった
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_TextChanged(object sender, EventArgs e)
        {
            _isModified = true;
            UpdateTitle();
        }

        /// <summary>
        /// フォームが閉じられている時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
            {
                // 保存確認
                if (!SaveConfirm())
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// フォームがロードされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _openFileDialog.FileName = Resources.DefaultFileName;
            UpdateTitle();
        }

        /// <summary>
        /// タイトルを更新する
        /// </summary>
        /// <param name="fileName"></param>
        private void UpdateTitle()
        {
            Text = Application.ProductName + " - " + Path.GetFileName(_openFileDialog.FileName);
            if (_isModified)
            {
                Text += "*";
            }
        }

        /// <summary>
        /// 保存確認する
        /// </summary>
        /// <returns>true: 保存しない/false: キャンセル</returns>
        private bool SaveConfirm()
        {
            // 保存確認
            string message = string.Format(Resources.AskMessageSaveData, Path.GetFileName(_openFileDialog.FileName));
            DialogResult dialogResult = MessageBox.Show(this, message, Application.ProductName, MessageBoxButtons.YesNoCancel);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    if (_saveFileDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return false;
                    }
                    return true;
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                    return false;
                default:
                    Debug.Assert(false);
                    return true;
            }
        }

        /// <summary>
        /// フォントが選択された
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _menuItemFont_Click(object sender, EventArgs e)
        {
            if (_fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                _textBox.Font = _fontDialog.Font;
                AppSetting.Instance.FontFamilyName = _textBox.Font.FontFamily.Name;
                AppSetting.Instance.Size = _textBox.Font.Size;
                _textBox.ForeColor = _fontDialog.Color;
                AppSetting.Instance.ForeColor = _textBox.ForeColor;
            }
        }

        /// <summary>
        /// テキストボックスにファイルがドラッグされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_DragEnter(object sender, DragEventArgs e)
        {
            string[] dragFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string d in dragFiles)
            {
                if (!System.IO.File.Exists(d))
                {
                    return;
                }
            }
            e.Effect = DragDropEffects.Copy;
        }

        /// <summary>
        /// テキストボックスにファイルがドロップされた
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _textBox_DragDrop(object sender, DragEventArgs e)
        {
            // 変更中かどうか
            if (_isModified)
            {
                // 保存確認
                if (!SaveConfirm())
                {
                    return;
                }
            }

            try
            {
                // ドラッグしたファイルを開く
                string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                string readText = File.ReadAllText(dropFiles[0]);
                _textBox.Text = AESConveter.Decrypt(readText);
                _isModified = false;
                _openFileDialog.FileName = dropFiles[0];
                UpdateTitle();
            }
            catch (Exception)
            {
                MessageBox.Show(this, Resources.WarnMessageReadFileFailed, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion
    }
}
