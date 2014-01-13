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
    
    
    public class WalkUp : AnimatedSprite, IBeetleState
    {
        //fields
        private Beetle beetle;


        //constructor
        public WalkUp(Beetle beetle) : base(beetle)
        {
            this.beetle = beetle;
        
        }

        //update method
        public void Update(GameTime gameTime) 
        {
        
        
        }
        
        
        //draw method
        public void Draw(GameTime gameTime)
        {


        }




    }
}
