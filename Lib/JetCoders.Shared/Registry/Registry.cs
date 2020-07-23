
using System;
using Microsoft.Win32;

namespace JetCoders.Shared
{
    /// <summary>
    /// An useful class to read/write/delete/count registry keys
    /// </summary>
    public class RegistryUtility
    {
        /// <summary>
        /// A property to show or hide error messages 
        /// (default = false)
        /// </summary>
        public bool ShowError { get; set; }

        private RegistryKey _baseRegistryKey = Registry.LocalMachine;
        /// <summary>
        /// A property to set the BaseRegistryKey value.
        /// (default = Registry.LocalMachine)
        /// </summary>
        public RegistryKey BaseRegistryKey
        {
            get { return _baseRegistryKey; }
            set { _baseRegistryKey = value; }
        }

        /// <summary>
        /// To read a registry key.
        /// input: KeyName (string)
        /// output: value (string) 
        /// </summary>
        public string Read(string subKey, string keyName)
        {
            // Opening the registry key
            RegistryKey rk = _baseRegistryKey;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey(subKey);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            try
            {
                return (string)sk1.GetValue(keyName.ToUpper());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Write(String subKey, string keyName, object value)
        {
            try
            {
                var rk = _baseRegistryKey;
                var sk1 = rk.CreateSubKey(subKey);
                if (sk1 != null) sk1.SetValue(keyName.ToUpper(), value);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool WriteDWord(String subKey, string keyName, object value)
        {
            try
            {
                var rk = _baseRegistryKey;
                var sk1 = rk.CreateSubKey(subKey);
                if (sk1 != null) sk1.SetValue(keyName.ToUpper(), unchecked((int)value), RegistryValueKind.DWord);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteKey(String subKey, string keyName)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                if (sk1 == null)
                    return true;
                sk1.DeleteValue(keyName);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSubKeyTree(String subKey)
        {
            try
            {
                // Setting
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int SubKeyCount(String subKey)
        {
            try
            {
                // Setting
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    return sk1.SubKeyCount;
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int ValueCount(string subKey)
        {
            try
            {
                RegistryKey rk = _baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                if (sk1 != null)
                    return sk1.ValueCount;
                return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
