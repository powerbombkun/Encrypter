using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Encrypter
{
    /// <summary>
    /// 暗号化の変換処理クラス
    /// </summary>
    public static class AESConveter
    {
        #region 定数

        /// <summary>
        /// ブロックサイズ
        /// </summary>
        private const int BLOCK_SIZE = 128;
        /// <summary>
        /// キーサイズ
        /// </summary>
        private const int KEY_SIZE = 128;
        /// <summary>
        /// 初期化ベクタ
        /// </summary>
        private const string AES_IV = @"!QAZ2WSX#EDC4RFV";
        /// <summary>
        /// 暗号キー
        /// </summary>
        private const string AES_KEY = @"5TGB&YHN7UJM(IK<";

        #endregion

        #region メソッド

        /// <summary>
        /// 文字列をAESで暗号化
        /// </summary>
        public static string Encrypt(string text)
        {
            // AES暗号化サービスプロバイダ
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = BLOCK_SIZE;
            aes.KeySize = KEY_SIZE;
            aes.IV = Encoding.UTF8.GetBytes(AES_IV);
            aes.Key = Encoding.UTF8.GetBytes(AES_KEY);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // 文字列をバイト型配列に変換
            byte[] src = Encoding.Unicode.GetBytes(text);

            // 暗号化する
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // バイト型配列からBase64形式の文字列に変換
                return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// 文字列をAESで復号化
        /// </summary>
        public static string Decrypt(string text)
        {
            // AES暗号化サービスプロバイダ
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = BLOCK_SIZE;
            aes.KeySize = KEY_SIZE;
            aes.IV = Encoding.UTF8.GetBytes(AES_IV);
            aes.Key = Encoding.UTF8.GetBytes(AES_KEY);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Base64形式の文字列からバイト型配列に変換
            byte[] src = System.Convert.FromBase64String(text);

            // 複号化する
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return Encoding.Unicode.GetString(dest);
            }
        }

        #endregion
    }
}
