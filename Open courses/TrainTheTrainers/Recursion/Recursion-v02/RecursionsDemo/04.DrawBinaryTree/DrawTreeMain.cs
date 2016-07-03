namespace howto_binary_tree
{
    using System;
    using System.Windows.Forms;

    public static class DrawTreeMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DrawTreeForm());
        }
    }
}
