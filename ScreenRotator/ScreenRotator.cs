using Magic.Samples.DisplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Screen = System.Windows.Forms.Screen;
using ScreenOrientation = System.Windows.Forms.ScreenOrientation;

namespace ScreenRotator
{
    class ScreenRotator
    {
        public static Screen GetNotebookScreen()
        {
            return (from s in Screen.AllScreens
                    where s.Bounds.Width == 1366 && s.Bounds.Height == 768
                    select s).FirstOrDefault();
        }

        public static void BlockInput()
        {
            if (!UACHelper.IsAdministrator())
            {
                UACHelper.RerunApplicationAsAdministrator();
            }
            ScreenInterop.BlockInput(true);
        }

        public static void RotateScreen()
        {
            DisplayManager.RotateScreen(true);
        }

        public static void ToggleLandscapeModes()
        {
            if (CurrenOrientation() == ScreenOrientation.Angle0)
                SetScreenOrientation(ScreenOrientation.Angle180);
            else
                SetScreenOrientation(ScreenOrientation.Angle0);
        }

        public static void TogglePotraitModes()
        {
            if (CurrenOrientation() == ScreenOrientation.Angle90)
                SetScreenOrientation(ScreenOrientation.Angle270);
            else
                SetScreenOrientation(ScreenOrientation.Angle90);
        }

        public static void SetScreenOrientation(ScreenOrientation newOr)
        {
            var set = DisplayManager.GetCurrentSettings();

            var oldOr = (ScreenOrientation)set.Orientation;

            if (newOr != oldOr)
            {
                if (IsLandscape(newOr) != IsLandscape(oldOr))
                {
                    int tmp = set.Height;
                    set.Height = set.Width;
                    set.Width = tmp;
                }

                set.Orientation = (Orientation)newOr;
                DisplayManager.SetDisplaySettings(set);
            }
        }

        private static ScreenOrientation CurrenOrientation()
        {
            return System.Windows.Forms.SystemInformation.ScreenOrientation;
        }

        private static bool IsLandscape(ScreenOrientation o)
        {
            return o == ScreenOrientation.Angle0 || o == ScreenOrientation.Angle180;
        }

        private static bool IsPotrait(ScreenOrientation o)
        {
            return o == ScreenOrientation.Angle90 || o == ScreenOrientation.Angle270;
        }
    }
}
