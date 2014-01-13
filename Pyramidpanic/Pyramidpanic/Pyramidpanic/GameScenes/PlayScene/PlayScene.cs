//met using kan je een microsoft xna codebibliotheek toevoegen gebruiken in je class.
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
    public class PlayScene: IState //: IState voert de interface IState in.
    {
        //Fields van de class StartScene
        private PyramidPanic game;
        private Beetle beetle;
        private Scorpion scorpion;
        //de constructor ( heeft de zelfde naam als de class)
        //de constructor krijgt een object game mee van het type PyramidPanic
        public PlayScene(PyramidPanic game)
        {

            this.game = game;
            this.Initialize();
        }


        //Initialize method. Deze methode instaleert ( geeft de start waarden aan de variabelen)
        //void wilt zeggen dat er niets teruggegeven word.

        public void Initialize()
        {
            this.LoadConent();

        }

        //LoadConent methode. Deze methode maakt nieuwe objecten aan van de verschilende
        //classes
        public void LoadConent()
        {
            this.scorpion = new Scorpion(this.game, new Vector2(300f, 188f));
            this.beetle = new Beetle(this.game, new Vector2(100f,300f));


        }

        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen.
        //en update alle variabelen, methods enz....
        public void Update(GameTime gameTime)
        {

            if (Input.EdgeDetectKeyDown(Keys.Z))
            {
                this.game.IState = this.game.StartScene;
            }

          
            this.beetle.Update(gameTime);
            this.scorpion.Update(gameTime);
        }
        //Draw methode. Deze methode word normaal 60 maal perseconde aangeroepen en
        //tekent de textures op het canvas
        public void Draw(GameTime gameTime)
        {

            this.game.GraphicsDevice.Clear(Color.Crimson);
            
            this.beetle.Draw(gameTime);
            this.scorpion.Draw(gameTime);
        }


    }
}
