using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ScreenRotator
{
    static class UACHelper
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);

        [DllImport("Shell32.dll", SetLastError = false)]
        private static extern Int32 SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        private enum SHSTOCKICONID : uint
        {
            // http://msdn.microsoft.com/en-us/library/bb762542(v=vs.85).aspx
            SIID_SHIELD = 77
        }

        [Flags]
        private enum SHGSI : uint
        {
            SHGSI_ICONLOCATION = 0,
            SHGSI_ICON = 0x000000100,
            SHGSI_SYSICONINDEX = 0x000004000,
            SHGSI_LINKOVERLAY = 0x000008000,
            SHGSI_SELECTED = 0x000010000,
            SHGSI_LARGEICON = 0x000000000,
            SHGSI_SMALLICON = 0x000000001,
            SHGSI_SHELLICONSIZE = 0x000000004
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHSTOCKICONINFO
        {
            public UInt32 cbSize;
            public IntPtr hIcon;
            public Int32 iSysIconIndex;
            public Int32 iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }

            return false;
        }

        public static void RerunApplicationAsAdministrator()
        {
            RerunApplicationAsAdministrator(null);
        }

        public static void RerunApplicationAsAdministrator(string arguments)
        {
            System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
            info.UseShellExecute = true;
            info.Verb = "runas"; // Provides Run as Administrator
            info.Arguments = arguments;

            try
            {
                if (System.Diagnostics.Process.Start(info) != null)
                {
                    // The user accepted the UAC prompt.
                    System.Windows.Forms.Application.Exit();
                }
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // User canceled the UAC prompt
            }
        }

        public static System.Drawing.Bitmap GetUACShieldIcon()
        {
            SHSTOCKICONINFO info = new SHSTOCKICONINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);

            int error = SHGetStockIconInfo(SHSTOCKICONID.SIID_SHIELD, SHGSI.SHGSI_LARGEICON | SHGSI.SHGSI_ICON, ref info);
            if (error != 0)
                throw Marshal.GetExceptionForHR(error);

            System.Drawing.Bitmap result;

            using (System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon))
            {
                result = icon.ToBitmap();
            }

            DestroyIcon(info.hIcon);
            
            return result;
        }
    }
}
