﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Template
{
    class player : playerbase
    {
       
    
        private List<Vector2> BulletsList;

        private KeyboardState oldKState;

 
        public player(Texture2D tex, Vector2 position, List<Vector2> bullets, Point size) : base(tex)
        {
            texture = tex;
            BulletsList = bullets;
            base.position = position;
            rectangle = new Rectangle(base.position.ToPoint(), size);


        }

        public override void Update()
        {
            KeyboardState a = Keyboard.GetState();


            if (a.IsKeyDown(Keys.D))
                position.X += 10;
            if (a.IsKeyDown(Keys.A))
                position.X -= 10;
            if (a.IsKeyDown(Keys.W))
                position.Y -= 10;
            if (a.IsKeyDown(Keys.S))
                position.Y += 10;

            if (position.X <= 0)
                position.X = 0;
            if (position.X >= 1780)
                position.X = 1780;
            if (position.Y <= 0)
                position.Y = 0;
            if (position.Y >= 930)
                position.Y = 930;

            if (a.IsKeyDown(Keys.Space) && oldKState.IsKeyUp(Keys.Space))
            {
                BulletsList.Add(position + new Vector2(30, 0));

            }

            rectangle = new Rectangle(position.ToPoint(), rectangle.Size); // Rectangle = Position

            oldKState = a;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
