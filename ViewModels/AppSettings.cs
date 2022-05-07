﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ViewModels
{
    public static class AppSettings
    {
        #region MEMBER VARIABLES
        private static readonly RegistryKey rk = Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("CryptoPass");
        #endregion

        #region METHODS
        public static object GetValue(string key)
        {
            return rk.GetValue(key);
        }

        public static void SetValue(string key, string value)
        {
            rk.SetValue(key, value);
        }

        public static void SetPass(string pass)
        {
            SetValue("Password", GetHash(pass));
        }

        public static bool CheckPass(string pass)
        {
            return GetValue("Password").Equals(GetHash(pass));
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
