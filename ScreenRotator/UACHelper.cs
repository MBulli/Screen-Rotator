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
            SafeNativeMethods.SHSTOCKICONINFO info = new SafeNativeMethods.SHSTOCKICONINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);

            int error = SafeNativeMethods.SHGetStockIconInfo(SafeNativeMethods.SHSTOCKICONID.SIID_SHIELD,
                                                             SafeNativeMethods.SHGSI.SHGSI_LARGEICON | SafeNativeMethods.SHGSI.SHGSI_ICON,
                                                             ref info);
            if (error != 0)
                throw Marshal.GetExceptionForHR(error);

            System.Drawing.Bitmap result;

            using (System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon))
            {
                result = icon.ToBitmap();
            }

            SafeNativeMethods.DestroyIcon(info.hIcon);
            
            return result;
        }
    }
}
