using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SinoSZToolFlowDesign
{
        static class Program
        {
                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                [STAThread]
                static void Main()
                {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        XtraForm1 _f = new XtraForm1();
                        if (_f.ShowDialog() == DialogResult.OK)
                        {
                                Application.Run(new frmFlowDesignTool());
                        }
                }
        }
}