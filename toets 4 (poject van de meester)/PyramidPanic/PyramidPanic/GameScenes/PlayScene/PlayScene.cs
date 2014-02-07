// Met using kan je een XNA codebibliotheek toevoegen en gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PlayScene : IState
    {
        //Fields van de class PlayScene
        private PyramidPanic game;
        private Beetle beetle, beetle1;
        private Scorpion scorpion, scorpion1;
        private Explorer explorer;
        private Block block1;
        private Block block2;
        private Block block3;
        private Block block4;
        private Block block5;
        private Block block6;

        // Constructor van de StartScene-class krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        // Initialize methode. Deze methode initialiseert (geeft startwaarden aan variabelen).
        // Void wil zeggen dat er niets teruggegeven wordt.
        public void Initialize()
        {
            this.LoadContent();
        }

        // LoadContent methode. Deze methode maakt nieuwe objecten aan van de verschillende
        // classes.
        public void LoadContent()
        {
            this.beetle = new Beetle(this.game, new Vector2(100f, 300f));
            this.beetle1 = new Beetle(this.game, new Vector2(400f, 100f));
            this.scorpion = new Scorpion(this.game, new Vector2(300f, 188f));
            this.scorpion1 = new Scorpion(this.game, new Vector2(188f, 300f));
            this.explorer = new Explorer(this.game, new Vector2(304f, 240f));
            this.block1 = new Block(this.game, @"Block\Block", new Vector2(0f, 0f));
            this.block2 = new Block(this.game, @"Block\Wall1", new Vector2(32f, 0f));
            this.block3 = new Block(this.game, @"Block\Wall2", new Vector2(64f, 0f));
            this.block4 = new Block(this.game, @"Block\Door", new Vector2(96f, 0f));
            this.block5 = new Block(this.game, @"BLock\Block_hor", new Vector2(128f, 0f));
            this.block6 = new Block(this.game, @"Block\Block_vert", new Vector2(160f, 0f));
        }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        // en update alle variabelen, methods enz.......
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.IState = this.game.StartScene;
            }
            this.beetle.Update(gameTime);
            this.beetle1.Update(gameTime);
            this.scorpion.Update(gameTime);
            this.scorpion1.Update(gameTime);
            this.explorer.Update(gameTime);
            this.block1.Draw(gameTime);
            this.block2.Draw(gameTime);
            this.block3.Draw(gameTime);
            this.block4.Draw(gameTime);
            this.block5.Draw(gameTime);
            this.block6.Draw(gameTime);
        }

        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Pink);
            this.beetle.Draw(gameTime);
            this.beetle1.Draw(gameTime);
            this.scorpion.Draw(gameTime);
            this.scorpion1.Draw(gameTime);
            this.explorer.Draw(gameTime);
        }
    }
}
