using System;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Aoria
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameLoop = GameLoop.Instance;
            gameLoop.WindowLoop();
        }
    }
}