using System;
using System.Collections.Generic;
using System.Text;

namespace MP2
{
    public class GamePlatform
    {
        private DateTime addedTo;
        public DateTime AddedTo
        {
            get
            {
                return addedTo;
            }
            set
            {
                addedTo = value;
            }
        }

        private Platform platform;
        public Platform Platform
        {
            get
            {
                return platform;
            }

            set
            {
                platform = value;
            }
        }

        private Game game;
        public Game Game
        {
            get
            {
                return game;
            }
            set
            {
                game = value;
            }
        }

        public GamePlatform (Platform platform, Game game, DateTime addedTo)
        {
            SetPlatform(platform);
            SetGame(game);
            this.AddedTo = addedTo;
        }

        public void Delete()
        {
            this.Platform.DeleteGamePlatform(this);
            this.Game.DeleteGamePlatform(this);
        }

        public void SetPlatform(Platform platform)
        {
            if (this.platform != null)
            {
                platform.DeleteGamePlatform(this);
                this.platform = null;
            }
            this.platform = platform;
            platform.AddGamePlatform(this);
        }

        public void SetGame(Game game)
        {
            if (this.game != null)
            {
                game.DeleteGamePlatform(this);
                this.game = null;
            }
            this.game = game;
            game.AddGamePlatform(this);
        }
   
    }
}
