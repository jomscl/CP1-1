﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CP_1
{
    abstract class Sprite
    {

        int alto = 690;
        int ancho = 1024;
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;
        int collisionOffset;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;
        protected Vector2 speed;
        protected Vector2 position;
        SpriteEffects SpEfect;
        protected Point sentido;
        protected float evasionSpeedModifier;
        protected int evasionRange;
        public string collisionCueName { get; private set; }

        //public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, Point sentido, float evasionSpeedModifier, int evasionRange) 
        //    : this(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, SpEfect, defaultMillisecondsPerFrame, sentido, evasionSpeedModifier, evasionRange)
        //{
        
        //}

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
           int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
           string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, defaultMillisecondsPerFrame, collisionCueName, SpEfect, sentido)
        {
        }

        //public Sprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, SpriteEffects SpEfect, int millisecondsPerFrame, Point sentido, float evasionSpeedModifier, int evasionRange)
        //{
        //    this.textureImage = textureImage;
        //    this.position = position;
        //    this.frameSize = frameSize;
        //    this.collisionOffset = collisionOffset;
        //    this.currentFrame = currentFrame;
        //    this.sheetSize = sheetSize;
        //    this.speed = speed;
        //    this.millisecondsPerFrame = millisecondsPerFrame;
        //    this.SpEfect = SpEfect;
        //    this.sentido = sentido;
        //    this.evasionSpeedModifier = evasionSpeedModifier;
        //    this.evasionRange = evasionRange;
        //}

        //
        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
            int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
            int millisecondsPerFrame, string collisionCueName, SpriteEffects SpEfect, Point sentido)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            this.collisionCueName = collisionCueName;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.sentido = sentido;
            this.SpEfect = SpEfect;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                if (direction == Vector2.Zero)
                {
                    currentFrame.X = 0;
                    currentFrame.Y = 0;
                }
                else
                {

                    // codigo antiguo
                    ++currentFrame.X;
                    if (currentFrame.X >= sheetSize.X)
                    {
                        currentFrame.X = 1;
                        if (sentido.Y == 0) { currentFrame.Y = 0; } else { currentFrame.Y = 1; }
                    }
                }
                
                // direccion
                if (sentido.X == 0) { SpEfect = SpriteEffects.None; } else { SpEfect = SpriteEffects.FlipHorizontally; }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1f, SpEfect, 0);
        }

        public abstract Vector2 direction
        {
            get;
        }

        public abstract Point psentido
        {
            get;
        }

        public Vector2 GetPosition
        {
            get { return position; }
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                (int)position.X + collisionOffset,
                (int)position.Y + collisionOffset,
                frameSize.X - (collisionOffset * 2),
                frameSize.Y - (collisionOffset * 2));
            }
        }

        public bool limitePantalla
        {
            get
            {
                bool clip = false;
                //int alto = Game.Window.ClientBounds.Height;
                //int ancho = Game.Window.ClientBounds.Width;

                if (position.X < 10)
                {
                    position.X = 10;
                    clip = true;
                }
                if (position.Y < 10)
                {
                    position.Y = 10;
                    clip = true;
                }
                if (position.X < 10)
                {
                    position.X = 10;
                    clip = true;
                }
                if (position.Y < 10)
                {
                    position.Y = 10;
                    clip = true;
                }
                if (position.X > ancho - frameSize.X - 10)
                {
                    position.X = ancho - frameSize.X;
                    clip = true;
                }
                if (position.Y > alto - frameSize.Y-10)
                {
                    position.Y = alto - frameSize.Y;
                    clip = true;
                }
                if (position.X > ancho - frameSize.X - 10)
                {
                    position.X = ancho - frameSize.X;
                    clip = true;
                }
                if (position.Y > alto - frameSize.Y - 10)
                {
                    position.Y = alto - frameSize.Y;
                    clip = true;
                }
                return clip;
            }
        }

    }
}
