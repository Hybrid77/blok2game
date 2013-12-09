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
   public class Image
    {
       //Fields.

       private Texture2D texture;

       private PyramidPanic game;


       //maak een rectangle voor het detecteren van collisions
       private Rectangle rectangle;



       //Constructor.
       public Image(PyramidPanic game, string pathNameAsset, Vector2 position) {

           this.game = game;
           this.texture = game.Content.Load<Texture2D>(pathNameAsset);
           this.rectangle = new Rectangle((int)position.X,
                                          (int)position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
       
       
       
       
       }


        
       //Update.

       //Draw.

       public void Draw(GameTime gameTime) {

           this.game.Spritebatch.Draw(this.texture, 
                                      this.rectangle,  
                                      Color.White);
       
       
       }

       //Helper method.






    }
}
