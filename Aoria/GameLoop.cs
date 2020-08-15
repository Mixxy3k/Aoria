using SFML.Graphics;
using SFML.System;
using System.Threading.Tasks;

namespace Aoria
{
    public sealed class GameLoop
    {
        private static readonly object padlock = new object();
        private static GameLoop instance = null;

        public static GameLoop Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GameLoop();
                        }
                    }
                }
                return instance;
            }
        }

        public enum GameState
        {
            MENU = 1,
            IN_GAME = 2,
            UNKNOW = 3
        }

        private GameLoop()
        {
            gameState = GameState.UNKNOW;
            window = Window.Instance;
            logger = Logger.Instance;

            logger.Info("Initiated game loop!");
        }

        public void WindowLoop()
        {
            gameState = GameState.IN_GAME;

            Player player = new Player();

            Color color = new Color(100, 255, 100, 255);


            while (window.GameWindow.IsOpen)
            {
                window.GameWindow.DispatchEvents();

                window.GameWindow.Clear(color);

                window.GameWindow.Draw(player);

                window.GameWindow.Display();
            }
            return;
        }

        public GameState gameState;
        private Window window;
        private Logger logger;
    }
}
