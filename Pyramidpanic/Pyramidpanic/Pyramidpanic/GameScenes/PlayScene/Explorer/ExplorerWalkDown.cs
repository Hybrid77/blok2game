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
    //dit is een toestand class (dus moet hij de interface toepassen)
    //deze classe belooft dat hij de methods uit de interface haalt.
    
    
    public class ExplorerWalkDown : AnimatedSprite, IEntityState
    {
        //fields
        private Explorer explorer;
        private Vector2 velocity;

        //constructor
        public ExplorerWalkDown(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            this.destinationRectangle = new Rectangle((int)this.explorer.Position.X, (int)this.explorer.Position.Y, 32, 32);
            this.velocity = new Vector2(0f, this.explorer.Speed);
            this.rotation = (float)Math.PI / 2;
            
           
        }


        public void Initialize()
        {
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            this.explorer.Position += this.velocity;

            //als de x positie op 480 - 17 staat dan:
            if (this.explorer.Position.Y > 480-17)
            {
                //word de velocity 0 en kan de explorer neit meer bewegen
                this.explorer.Position -= this.velocity;
                //de state verandert naar explorer idle walk
                this.explorer.State = this.explorer.ExplorerIdleWalk;
                //de spriteeffect word none omdat je de fakkel dan al links hebt
                this.explorer.ExplorerIdleWalk.Effect = SpriteEffects.None;
                //en de rotation krijgt een vaste waarde van pi/2 in exploreridlewalk
                //zodat de explorer naar benedern kijkt als die loopt en still staat
                this.explorer.ExplorerIdleWalk.Rotation = (float)Math.PI / 2;
                
               
            }

            //als de pijltjestoets die naar benedenwijst los gelaten word dan:
            if (Input.EdgeDetectKeyUp(Keys.Down))
            {

                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //maar de effect is aangegeven als flipvertically 
                //zodat de fakel aan de linker kant blijft
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipVertically;
                
            }


            this.explorer.Position += this.velocity;
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
