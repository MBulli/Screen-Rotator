using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Keys = System.Windows.Forms.Keys;

namespace ScreenRotator
{
    static class UserInputLocker
    {
        private static long latestEscapeKey = 0;

        private static IntPtr hKBHook;
        private static IntPtr hMSHook;

        public static event EventHandler UserAbortedInputLock;

        public static void LockInput()
        {
            InstallHooks();
        }

        public static void UnlockInput()
        {
            UninstallHooks();
        }

        private static void InstallHooks()
        {
            IntPtr hModule = SafeNativeMethods.GetModuleHandle(null);

            if (hKBHook == IntPtr.Zero)
                hKBHook = SafeNativeMethods.SetWindowsHookEx(SafeNativeMethods.WH_KEYBOARD_LL, ProcessKB, hModule, 0);
            if (hMSHook == IntPtr.Zero)
                hMSHook = SafeNativeMethods.SetWindowsHookEx(SafeNativeMethods.WH_MOUSE_LL, ProcessMS, hModule, 0);
        }

        private static void UninstallHooks()
        {
            if (hKBHook != IntPtr.Zero)
            {
                SafeNativeMethods.UnhookWindowsHookEx(hKBHook);
                hKBHook = IntPtr.Zero;
            }

            if (hMSHook != IntPtr.Zero)
            {
                SafeNativeMethods.UnhookWindowsHookEx(hMSHook);
                hMSHook = IntPtr.Zero;
            }
        }

        private static IntPtr ProcessKB(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var kb = PtrToStructure<SafeNativeMethods.KBDLLHOOKSTRUCT>(lParam);
                int message = wParam.ToInt32();

                if ( kb.vkCode == (uint)Keys.Escape && message == SafeNativeMethods.WM_KEYUP)
                {
                    long delta = kb.time - latestEscapeKey;
                    latestEscapeKey = kb.time;

                    if (delta < 1000)
                    {
                        UninstallHooks();

                        if (UserAbortedInputLock != null)
                            UserAbortedInputLock(null, EventArgs.Empty);

                        return SafeNativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
                    }
                }

                if (!kb.flags.HasFlag(SafeNativeMethods.KBDLLHOOKSTRUCTFlags.LLKHF_INJECTED))
                    return new IntPtr(1); // block input
            }

            return SafeNativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr ProcessMS(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var ms = PtrToStructure<SafeNativeMethods.MSLLHOOKSTRUCT>(lParam);

                if (!ms.flags.HasFlag(SafeNativeMethods.MSLLHOOKSTRUCTFlags.LLMHF_INJECTED))
                    return new IntPtr(1); // block input
            }

            return SafeNativeMethods.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static T PtrToStructure<T>(IntPtr ptr)
            where T : struct
        {
            return (T)System.Runtime.InteropServices.Marshal.PtrToStructure(ptr, typeof(T));
        }
    }
}
