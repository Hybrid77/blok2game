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
        private List<String> lines;




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
            this.stream = TitleContainer.OpenStream(@"Content\Level\0.txt");
            this.LoadAssets();

        
        }

        //Update method


        //Draw Method
        private void LoadAssets()
        {
            //Deze list van Strings slaat elke regel van 0.txt op
            this.lines = new List<String>();
            //De StreamReader kan lezen wat er in het text bestand staat.
            StreamReader reader= new StreamReader(this.stream);
            //leest een regel
            string line = reader.ReadLine();
            //schrijft een regel
            Console.WriteLine(line);
        }

    }
}
