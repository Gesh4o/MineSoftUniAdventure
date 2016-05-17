namespace _03.GenericList
{
    using System;
    using _04.GenericListVersion;
    using System.Runtime.InteropServices;

    [Version(2, 11)]
    public class MainClass
    {
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int ShowMessageBox(int hWnd, string text, string caption, int type);
        private static void Main()
        {
            GenericList<int> list = new GenericList<int>();

            list.Add(5);
            list.Add(3);

            list.InsertAtPos(9, 4);

            Console.WriteLine(list[0].ToString());
            Console.WriteLine(list[1].ToString());
            Console.WriteLine(list[2].ToString()); 

            int indexOfFive = list.FindFirstIndexOf(3);
            Console.WriteLine(indexOfFive.ToString());

            Console.WriteLine(list.ToString());

            Console.WriteLine(list.Min(3, 4));
            Console.WriteLine(list.Max(3, 4));

            list.Clear();
            Console.WriteLine(list.ToString());
            //VersionAttribute version = new VersionAttribute(2, 11);
            //ShowMessageBox(0,"Version: " + version.Major.ToString() + "." + version.Minor.ToString(), "Program information", 0);

            Type type = typeof(MainClass);
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in allAttributes)
            {
                Console.WriteLine(
                  "This class has version {0}.{1} ", attr.Major, attr.Minor);
            }

        }
    }
}
