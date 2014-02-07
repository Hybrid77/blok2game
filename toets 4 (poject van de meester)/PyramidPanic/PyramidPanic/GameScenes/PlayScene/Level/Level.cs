using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;


namespace PyramidPanic
{
    public class Level
    {

        //Fields
        private PyramidPanic game;
        private int levelIndex;
        private Stream stream;





        //Properties
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public int LevelIndex 
        {
            get { return this.levelIndex; }
        }



        //Constructor
        public Level(PyramidPanic game, int levelIndex) 
        {
            this.game = game;
            this.levelIndex = levelIndex;
            this.stream = stream;


        
        }

        //Update method


        //Draw Method

    }
}
