﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CP_1
{
    class UserControlledSprite : Sprite
    {
        MouseState prevMouseState;

        //public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, Point sentido, float evasionSpeedModifier, int evasionRange)
        //    : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, sentido, evasionSpeedModifier, evasionRange)
        //{ 
        
        //}

        //public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, int millisecondsPerFrame, Point sentido, float evasionSpeedModifier, int evasionRange)
        //    : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, millisecondsPerFrame, sentido, evasionSpeedModifier, evasionRange)
        //{
        
        //}

        public UserControlledSprite(Texture2D textureImage, Vector2 position,
       Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
       Vector2 speed, string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, collisionCueName,  SpEfect,  sentido)
        {
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame, string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName, SpEfect, sentido)
        {
        }

        public override Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;
                if (Keyboard.GetState( ).IsKeyDown(Keys.Left))
                inputDirection.X =inputDirection.X- 1;
                if (Keyboard.GetState( ).IsKeyDown(Keys.Right))
                inputDirection.X += 1;
                if (Keyboard.GetState( ).IsKeyDown(Keys.Up))
                    inputDirection.Y = inputDirection.Y-1;
                if (Keyboard.GetState( ).IsKeyDown(Keys.Down))
                inputDirection.Y += 1;
                GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
                if(gamepadState.ThumbSticks.Left.X != 0)
                inputDirection.X += gamepadState.ThumbSticks.Left.X;
                if(gamepadState.ThumbSticks.Left.Y != 0)
                inputDirection.Y -= gamepadState.ThumbSticks.Left.Y;
                return inputDirection * speed;
            }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Move the sprite based on direction
            position += direction;
            // If player moved the mouse, move the sprite
            MouseState currMouseState = Mouse.GetState();
            if (currMouseState.X != prevMouseState.X ||
            currMouseState.Y != prevMouseState.Y)
            {
                position = new Vector2(currMouseState.X, currMouseState.Y);
            }
            prevMouseState = currMouseState;
            // If sprite is off the screen, move it back within the game window
            if (limitePantalla(clientBounds)) ;

            //if (position.X < 0)
            //    position.X = 0;
            //if (position.Y < 0)
            //    position.Y = 0;
            //if (position.X > clientBounds.Width - frameSize.X)
            //    position.X = clientBounds.Width - frameSize.X;
            //if (position.Y > clientBounds.Height - frameSize.Y)
            //    position.Y = clientBounds.Height - frameSize.Y;
            base.Update(gameTime, clientBounds);

            // calculo de sentido
            if (direction.X > 0) { sentido.X = 0; } else { sentido.X = 1; }
            if (direction.Y > 0) { sentido.Y = 0; } else { sentido.Y = 1; }

        }

        public override Point psentido
        {
            get{ return sentido; }
        }

    }
}
