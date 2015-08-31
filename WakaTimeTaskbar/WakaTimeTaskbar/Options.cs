using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WakaTimeTaskbar.NativeCalls;

namespace WakaTimeTaskbar
{
    public partial class Options : Form
    {
        NativeCalls.WinEventDelegate _windowDelegate = null;

        public Options()
        {
            InitializeComponent();            
            _windowDelegate = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, _windowDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] WindowInfo = GetActiveWindowInfo();
            if (WindowInfo != null)
            {
                Console.WriteLine(string.Format("Process: {0}, Window Title: {1}", WindowInfo[0], WindowInfo[1]));
            }
        }
    }
}
