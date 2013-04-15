using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Encrypter
{
    /// <summary>
    /// アプリケーション設定
    /// </summary>
    public class AppSetting
    {
        #region 定数

        /// <summary>
        /// アプリケーション設定ファイル名
        /// </summary>
        private const string APP_SETTING_FILE_NAME = "setting.xml";

        #endregion

        #region フィールド・プロパティ

        private static AppSetting _instance = new AppSetting();       
        /// <summary>
        /// インスタンス
        /// </summary>
        public static AppSetting Instance
        { 
            get{ return _instance; }
        }

        /// <summary>
        /// 描画フォントのフォントファミリー
        /// </summary>
        public string FontFamilyName { get; set; }

        /// <summary>
        /// 描画フォントのサイズ
        /// </summary>
        public float Size { get; set; }

        /// <summary>
        /// 文字の色
        /// </summary>
        public Color ForeColor { get; set; }

        #endregion

        #region メソッド

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AppSetting()
        {
            FontFamilyName = Control.DefaultFont.FontFamily.Name;
            Size = Control.DefaultFont.Size;
            ForeColor = Control.DefaultForeColor;
        }

        /// <summary>
        /// ファイルから設定を読み込む
        /// </summary>
        public void Load()
        {
            try
            {
                // デシリアライズ
                XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                using (FileStream stream = new FileStream(Path.Combine(GetApplicationDirectory(), APP_SETTING_FILE_NAME), FileMode.Open))
                {
                    _instance = (AppSetting)serializer.Deserialize(stream);
                }
            }
            catch (Exception)
            {
                // 特に何もしない
            }
        }

        /// <summary>
        /// ファイルに設定を保存する
        /// </summary>
        public void Save()
        {
            try
            {
                string directory = GetApplicationDirectory();
                // 存在しない場合は生成
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // シリアライズ
                XmlSerializer serializer = new XmlSerializer(typeof(AppSetting));
                using (FileStream stream = new FileStream(Path.Combine(directory, APP_SETTING_FILE_NAME), FileMode.Create))
                {
                    serializer.Serialize(stream, _instance);
                }
            }
            catch (Exception)
            {
                // 特になにもしない
            }
        }

        /// <summary>
        /// アプリケーション設定のディレクトリを取得する
        /// </summary>
        /// <returns></returns>
        private string GetApplicationDirectory()
        {
            // アプリケーションディレクトリ以下のアプリケーション名のディレクトリ
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                                Path.GetFileNameWithoutExtension(Application.ExecutablePath));
        }

        #endregion

    }
}
