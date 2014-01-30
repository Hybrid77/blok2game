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
    public interface IEntityState
    {
        //elke toestand van de beetle en scorpion classes 
        //past de interface IEntityState toe
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Initialize();
    }
}
