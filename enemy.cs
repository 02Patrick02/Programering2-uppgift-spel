using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    class Enemy : PlayerBase
    {

        public Enemy(Texture2D tex, Vector2 position, Point size, int health) : base(tex)
        {
            texture = tex;
            base.position = position;
            base.rectangle = new Rectangle(position.ToPoint(), size);
            base.health = health;
        }

        public void Move()
        {
            position.Y += 5;
            rectangle = new Rectangle(position.ToPoint(), rectangle.Size); // Rectangle = Position
        }

        public void HealthLoss()
        {
            health--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }

    }
}