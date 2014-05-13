using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CP_1
{
    class AutomatedSprite : Sprite
    {
        // 10
        public AutomatedSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, string collisionCueName, SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, collisionCueName, SpEfect,  sentido)
        {
        }
        // 11
        public AutomatedSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame, string collisionCueName,
            SpriteEffects SpEfect, Point sentido)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame, collisionCueName,  SpEfect,  sentido)
        {
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            
 
            position += direction;
            
            
            // condicion de borde
            limitePantalla(clientBounds);

            
            base.Update(gameTime, clientBounds);
        }


        public override Point psentido
        {
            get { return sentido; }
        }
    } // fin clase
}
