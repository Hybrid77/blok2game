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
        private Block[,] blocks;




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
        public void Draw(GameTime gameTime) 
        {

            //het blocks array word getekend door middel van een dubbele for-lus.
            for (int row = 0; row < this.blocks.GetLength(1); row++) 
            {
                for (int column = 0; column < this.blocks.GetLength(0); column++) 
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            
            }
        }





        private void LoadAssets()
        {
            //Deze list van Strings slaat elke regel van 0.txt op
            this.lines = new List<String>();
            //De StreamReader kan lezen wat er in het text bestand staat.
            StreamReader reader= new StreamReader(this.stream);
            //leest een regel
            string line = reader.ReadLine();
            //dit telt hoeveel regels de 0.txt bestand heeft
            int lineWidth = line.Length;
            //schrijft een regel in de console
            //Console.WriteLine(line);
            //dit schrijft het aantal characters in de console
            //Console.WriteLine(lineWidth);


            //waneer line niet gelijk is aan nul dan:
            while (line != null) 
            {
                //en dit stopt de uitgelezen regel in de List<String> this.lines
                this.lines.Add(line);
                //Leest de volgende regels iot het tekst bestand met read.Readline();
                line = reader.ReadLine();
            }

            //dit telt het aantal regels in het 0.txt bestand
            int amountOfLines = this.lines.Count;
            
            
            //vernietigd het reader object. het bestand is uitgelezen.
            reader.Close();
            //vernietigd het stream object. het bestand is uitgelezen.
            this.stream.Close();

            //dit tweedimentionale array bevat block-objecten
            this.blocks = new Block [lineWidth, amountOfLines];

            //dit gaat de block-array doorlopen met een dubbele for-lus
            for (int row = 0; row < amountOfLines; row++)
            {

                    for (int column = 0; column < lineWidth; column++)
                    {
                    //dit leest iedere letter uit de lines-list uit in een char variable
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] =this.LoadBlock(blockElement, column * 32, row * 32);
                    }
                }
            }

        public Block LoadBlock(char blockElement, int x, int y)
        {

            switch(blockElement){
                case 'x': 
                    return new Block(this.game, @"Block\Block", new Vector2(x, y));

                case '.':
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));

                default:
                    return new Block(this.game, @"Block\Transparant", new Vector2(x, y));

            }
        }
    }
}
