using Microsoft.Win32;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace ViewModels
{
    public static class AppSettings
    {
        #region MEMBER VARIABLES
        [SupportedOSPlatform("windows")]
        private static readonly RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("CryptoPass");
        #endregion

        #region METHODS
        [SupportedOSPlatform("windows")]
        private static object? GetValue(string key)
        {
            return rk.GetValue(key);
        }

        [SupportedOSPlatform("windows")]
        private static void SetValue(string key, string value)
        {
            rk.SetValue(key, value);
        }

        [SupportedOSPlatform("windows")]
        public static void SetPass(string pass)
        {
            SetValue("Password", GetHash(pass));
        }

        [SupportedOSPlatform("windows")]
        public static bool PassExist()
        {
            return GetValue("Password") != null;
        }

        [SupportedOSPlatform("windows")]
        public static bool CheckPass(string pass)
        {
            string? password = GetValue("Password")?.ToString();
            if (password != null)
            {
                return password.Equals(GetHash(pass));
            }
            return false;
        }

        [SupportedOSPlatform("windows")]
        public static void SetPath(string path)
        {
            if (PathExist())
            {
                List<string> list = new()
                {
                    @"\Passwords.json",
                    @"\Notes.json",
                    @"\Payments.json"
                };
                foreach (string item in list)
                {
                    if (File.Exists(AppSettings.GetPath() + item))
                    {
                        File.Move(AppSettings.GetPath() + item, path + item);
                    }
                }
            }
            SetValue("Path", path);
        }

        [SupportedOSPlatform("windows")]
        public static string GetPath()
        {
            if (GetValue("Path") is not string path || !Directory.Exists(path))
            {
                path = Directory.GetCurrentDirectory();
                SetPath(path);
            }
            return path;
        }

        [SupportedOSPlatform("windows")]
        public static bool PathExist()
        {
            return GetValue("Path") != null && Directory.Exists(GetPath());
        }

        public static string GetHash(string text)
        {
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(text);

            SHA256 algorithm = SHA256.Create();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);

            return Convert.ToBase64String(hash);
        }
        #endregion
    }
}
