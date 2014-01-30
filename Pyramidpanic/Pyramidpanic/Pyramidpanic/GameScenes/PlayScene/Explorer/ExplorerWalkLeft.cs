﻿//met using kan je een microsoft xna codebibliotheek toevoegen gebruiken in je class.
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
    //dit is een toestand class (dus moet hij de interface toepassen)
    //deze classe belooft dat hij de methods uit de interface haalt.
    
    
    public class ExplorerWalkLeft : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;

        //constructor
        public ExplorerWalkLeft(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            this.velocity = new Vector2(this.explorer.Speed, 0f);
            this.effect = SpriteEffects.FlipHorizontally;
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {

            this.explorer.Position -= this.velocity;

            //als de position x op 16 komt dan:
            if (this.explorer.Position.X < 0 + 16) 
            {
                //word de velocity 0 en kan de explorer neit meer bewegen
                this.explorer.Position += this.velocity;
                //de state verandert naar explorer idle walk
                this.explorer.State = this.explorer.ExplorerIdleWalk;
                //de sprite effect word fliphorizontally 
                //zodat de explorer in idlewalk nogsteeds naar links bijlft kijken
                this.explorer.ExplorerIdleWalk.Effect = SpriteEffects.FlipHorizontally;
                //en de rotation krijgt een vaste waarde van nul in exploreridle walk
                this.explorer.ExplorerIdleWalk.Rotation = 0f;
            }

            //als de rechtertoets los gelaten word dan: 
            if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //word de rotation can explorer idle word aangegeven als 0
                this.explorer.ExplorerIdle.Rotation = 0f;
                //maar de effect is aangegeven als fliphorizontally 
                //en dat draait de afbeelding om naar links.
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
            }


            this.explorer.Position -= this.velocity;
            //hier staat dat de destination rextangle van de x
            //gelijkstaat aan de (int) x positie van this.explorer
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            //hier staat dat de destination rextangle van de x
            //gelijkstaat aan de (int) x positie van this.explorer.
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //hier word de base.update method aangeroepen,
            //en gameTime word er in mee gegeven
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
