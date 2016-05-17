/*//////////////////////////////////////
///                                  ///
///   Author: Huy Phuong Nguyen,     ///
///   Qui Nhơn, Bình Định, Vietnam   ///
///   Email: huy_p_n@yahoo.vn        ///
///                                  ///
//////////////////////////////////////*/

namespace Theatre
{
    using Theatre.Contracts;
    using Theatre.Core;
    using Theatre.Factories;
    using Theatre.IO;

    public class TheatreProgram
    {
        public static void Main()
        {
            IInputHandler inputHandler = new ConsoleReader();

            IRenderer renderer = new ConsoleWriter();

            IPerformanceDatabase performanceDatabase = new PerformanceDatabase();

            ICommandFactory commandFactory = new CommandFactory();

            IEngine theatreEngine = new TheatreEngine(performanceDatabase, commandFactory, inputHandler, renderer);

            theatreEngine.Run();
        }
    }
}
