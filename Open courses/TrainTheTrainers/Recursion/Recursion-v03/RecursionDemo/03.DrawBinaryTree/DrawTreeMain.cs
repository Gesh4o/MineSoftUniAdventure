namespace howto_binary_tree
{
    #region

    using System;
    using System.Windows.Forms;

    #endregion

    public static class DrawTreeMain
    {
        /// <summary>
        ///     The main entry point for the application.
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