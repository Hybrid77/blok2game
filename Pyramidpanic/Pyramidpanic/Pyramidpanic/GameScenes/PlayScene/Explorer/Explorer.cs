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
    public class Explorer : IAnimatedSprite
    {

        //Fields
        private Texture2D texture;
        private PyramidPanic game;
        private IEntityState state;
        private int speed = 5;
        private Vector2 position;


        //maakt van iedere toestand (met andere woorden state) een field
        private ExplorerWalkUp walkUp;
        private ExplorerWalkDown walkDown;
        private ExplorerWalkUp walkLeft;
        private ExplorerWalkDown walkRight;

        //properties
        public WalkUp ExplorerWalkUp
        {
            get { return this.walkUp; }

        }
        public WalkDown ExplorerWalkDown
        {
            get { return this.walkDown; }

        }
        public WalkUp ExplorerWalkLeft
        {
            get { return this.walkLeft; }

        }
        public WalkDown ExplorerWalkRight
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
        public Explorer(PyramidPanic game, Vector2 position)
        {
            this.position = position;
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlayScene\Explorer\Explorer");
            this.walkUp = new ExplorerWalkUp(this);
            this.walkDown = new ExplorerWalkDown(this);
            this.walkUp = new ExplorerWalkLeft(this);
            this.walkDown = new ExplorerWalkRight(this);
            this.state = this.walkRight;
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
