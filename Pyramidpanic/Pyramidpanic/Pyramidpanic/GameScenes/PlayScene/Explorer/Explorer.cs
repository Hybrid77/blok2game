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
        private int speed = 2;
        private Vector2 position;
        

        //maakt van iedere toestand (met andere woorden state) een field
        private ExplorerWalkUp explorerWalkUp;
        private ExplorerWalkDown explorerwalkDown;
        private ExplorerWalkLeft explorerWalkLeft;
        private ExplorerWalkRight explorerWalkRight;
        private ExplorerIdle explorerIdle;
        private ExplorerIdleWalk explorerIdleWalk;
        private Rectangle explorerRectangle;
        private Vector2 origin;

        //properties
        public ExplorerWalkUp ExplorerWalkUp
        {
            get { return this.explorerWalkUp; }

        }
        public ExplorerWalkDown ExplorerWalkDown
        {
            get { return this.explorerwalkDown; }

        }
        public ExplorerWalkLeft ExplorerWalkLeft
        {
            get { return this.explorerWalkLeft; }

        }
        public ExplorerWalkRight ExplorerWalkRight
        {
            get { return this.explorerWalkRight; }

        }
        public ExplorerIdle ExplorerIdle
        {
            get { return this.explorerIdle; }

        }
        public ExplorerIdleWalk ExplorerIdleWalk
        {
            get { return this.explorerIdleWalk; }

        }
        public Vector2 Position 
        {

            get { return this.position; }
            set { 
                    this.position = value;
                    this.state.Initialize();
                }
        
        }
        public IEntityState State
        {
            set { 
                    this.state = value;
                    this.state.Initialize();
                }
    
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
            this.explorerWalkUp = new ExplorerWalkUp(this);
            this.explorerwalkDown = new ExplorerWalkDown(this);
            this.explorerWalkLeft = new ExplorerWalkLeft(this);
            this.explorerWalkRight = new ExplorerWalkRight(this);
            this.explorerIdle = new ExplorerIdle(this);
            this.explorerIdleWalk = new ExplorerIdleWalk(this);
            this.state = this.explorerIdle;
            this.origin.X = this.texture.Width / 2;
            this.origin.Y = this.texture.Height / 2;
            this.explorerRectangle = new Rectangle((int)origin.X , (int)origin.Y, this.texture.Width/2, this.texture.Height/2);
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
