﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class PlayerBase
    {
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        public virtual void Update()
        {


        }

        public PlayerBase(Texture2D tex)
        {
            texture = tex;
        }
    }
}
