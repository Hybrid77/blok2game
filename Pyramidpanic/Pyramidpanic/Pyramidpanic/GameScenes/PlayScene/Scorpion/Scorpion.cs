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
    public class Scorpion : IAnimatedSprite
    {

        //Fields
        private Texture2D texture;
        private PyramidPanic game;
        private IEntityState state;
        private int speed = 2;
        private Vector2 position;

        //maakt van iedere toestand (met andere woorden state) een field
        private WalkLeft walkLeft;
        private WalkRight walkRight;


        //properties
        public WalkLeft WalkLeft 
        {
            get { return this.walkLeft; }
        
        }
        public WalkRight WalkRight
        {
            get { return this.walkRight; }

        }
        public Vector2 Position 
        {

            get { return this.position; }
            set { this.position = value; }
        
        }
        public IEntityState State
        {
            set { this.state = value; }
    
        }
        public PyramidPanic Game 
        {
            get { return this.game; }
        }
        public int Speed
        {
            get { return this.speed; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }


        //Constructor
        public Scorpion(PyramidPanic game, Vector2 position)
        {
            this.position = position;
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Scorpion\Scorpion");
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = new WalkLeft(this);
        }


        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }



        //Draw
        public void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
        }
    }
}
