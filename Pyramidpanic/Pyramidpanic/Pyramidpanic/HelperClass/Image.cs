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
       //maak een variable aan(reference) aan het typen texture2D met de naam texture
       private Texture2D texture;

       //maak een variable aan(reference) aan het typen Color met de naam color
       private Color color = Color.White;

       // Maak een variable aan om de game instantie in op te slaan
       private PyramidPanic game;


       //maak een rectangle voor het detecteren van collisions
       private Rectangle rectangle;

       //dit is een propery voor de color field
       public Color Color {

           get { return this.color; }
           set { this.color = value; }
       
       }


       //dit is een property voor de rectangle field
       public Rectangle Rectangle {

           get { return this.rectangle; }

       }


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
                                      this.color);
       
       
       }

       //Helper method.






    }
}
