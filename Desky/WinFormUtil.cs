using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desky
{
    public class WinFormUtil
    {
        public static void ShowToastAt(uint number, Rect rect)
        {
            Task.Run(() =>
            {
                ScreenIdentifier id = new ScreenIdentifier(number)
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = new System.Drawing.Point(rect.Left + 10, rect.Top + 10)
                };
                Application.Run(id);
            });
        }
    }
}
