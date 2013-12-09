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
   public class Menu
    {
       //Fields
       //maak een variable (reference) van het typen Image
       private Image start;

       //maak een variable (reference) van het typen PyramidPanic
       private PyramidPanic game;


       //Constructor
       public Menu(PyramidPanic game){
           this.game = game;
           this.Initialize();
       }

       public void Initialize() {
           this.LoadContent();
       
       }


       public void LoadContent() {

           this.start = new Image(this.game, @"StartScene\Button_start", new Vector2 (20f, 440f));
       }

       //update
       public void Update(GameTime gameTime) { 
       
       }



       //Draw
       public void Draw(GameTime gameTime)
       {
           this.start.Draw(gameTime);
       }



    }
}
