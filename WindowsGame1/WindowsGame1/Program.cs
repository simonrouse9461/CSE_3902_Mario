using System;

namespace WindowsGame1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MarioGame game = new MarioGame())
            {                                                                                
                game.Run();
            }
        }                   
    }
#endif                       
}

