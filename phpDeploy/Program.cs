using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace phpDeploy
{
    public static class Program
    {
        public static phpDeploy.App App;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.App = new phpDeploy.App();
            Application.Run(Program.App);
        }
    }
}
