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
    
    
    public class ExplorerIdleWalk : AnimatedSprite, IEntityState
    {
        //fields
        //hier word de class explorer gedefineerd
        private Explorer explorer;
        //hier word de vector2 gedefineerd en de naam gegeven "velocity"
        private Vector2 velocity;
       
        

        //properties
        //hier word de property van de spriteEffects aangegeven 
        //waar in de setter van de effect word aangegeven als value.
        public SpriteEffects Effect
        {
            set { this.effect = value; }
        }
        //hier word de setter van rotation aangegeven als value zodat het later
        //nog aangepast kan worden met de value die jij er aan geeft.
        public float Rotation
        {
            set { this.rotation = value; }
        }


        //constructor
        public ExplorerIdleWalk(Explorer explorer)
            : base(explorer)
        {
            this.explorer = explorer;
            //hier word aangegeven wat de maat van het poppetje is
            this.destinationRectangle = new Rectangle(0, 0, 32, 32);
            //hier word de velocity aangegeven als 0 bij 0 als een float getal
            this.velocity = new Vector2(0f, 0f);
            //hier word de spriteEffects aangeroepen en er word erna aangegeven 
            //dat het verticaal word gespiegelt.
            this.effect = SpriteEffects.FlipVertically;
            
        }


        public void Initialize()
        {
            
        }


        //update method
        public new void Update(GameTime gameTime) 
        {
            //als de rechtertoets losgelatenword dan: 
            if (Input.EdgeDetectKeyUp(Keys.Right)) 
            {
                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //word de rotation can explorer idle word aangegeven als 0
                this.explorer.ExplorerIdle.Rotation = 0f;
                //maar de effect is aangegeven als flipvertically 
                //zodat de fakel aan de linker kant blijft
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipVertically;
                
            }
            //als de linkertoets losgelaten is dan: 
            else if (Input.EdgeDetectKeyUp(Keys.Left))
            {
                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //word de rotation can explorer idle word aangegeven als 0
                this.explorer.ExplorerIdleWalk.Rotation = 0f;
                //maar de effect is aangegeven als flipvertically 
                //zodat de fakel aan de linker kant blijft
                this.explorer.ExplorerIdle.Effect = SpriteEffects.FlipHorizontally;
                
            }

            //als de pijltoets die naar beneden wijst losgelaten is dan: 
            else if (Input.EdgeDetectKeyUp(Keys.Down))
            {
                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //word de rotation can explorer idle word aangegeven als pi/2
                this.explorer.ExplorerIdleWalk.rotation = (float)Math.PI / 2;
                //maar de effect is aangegeven als flipvertically 
                //zodat de fakel aan de linker kant blijft
                this.effect = SpriteEffects.FlipVertically;
            }
            //als de pijltoets die naar boven wijst losgelaten is dan: 
            else if (Input.EdgeDetectKeyUp(Keys.Up))
            {
                //word de state van de explorer explorereidle en
                this.explorer.State = this.explorer.ExplorerIdle;
                //word de rotation can explorer idle word aangegeven als pi/2
                this.explorer.ExplorerIdleWalk.rotation = (float)Math.PI / 2;
                //maar de effexct is aangegeven als flip vertically 
                //zodat de fakel aan de linker kant blijft
                this.effect = SpriteEffects.FlipVertically;
            }
            this.explorer.Position += this.velocity;
            this.destinationRectangle.X = (int)this.explorer.Position.X;
            this.destinationRectangle.Y = (int)this.explorer.Position.Y;
            //zorgd voor de animatie (roept de update method aan van de
            //animated class
            base.Update(gameTime);
        }
        
        
        //draw method
        public new void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
