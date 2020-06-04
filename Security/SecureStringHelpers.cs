using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace BasicCRUDTool
{
    /// <summary>
    /// Helpers for the secure string class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecure a secure string to text
        /// </summary>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

            //get a pointer for an unsecure string in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }

            finally
            {
                // Clean up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
