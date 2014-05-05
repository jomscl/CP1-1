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


namespace CP_1
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        UserControlledSprite player;
        List<Sprite> spriteList = new List<Sprite>();

       
        //Vector2[] casas = { new Vector2(50 , 53), new Vector2(50 , 118), new Vector2(50 , 183), new Vector2(50 , 248), new Vector2(50 , 313), new Vector2(50 , 378), new Vector2(50 , 443), new Vector2(50 , 508), new Vector2(50 , 573), new Vector2(50 , 638), 
        //                  new Vector2(110 , 638), new Vector2(170 , 638), new Vector2(230 , 638), new Vector2(290 , 638), 	new Vector2(350 , 638), 	new Vector2(410 , 638), 	new Vector2(470 , 638), 	new Vector2(530 , 638), 	new Vector2(590 , 638), 	new Vector2(650 , 638), 	new Vector2(710 , 638), 	new Vector2(770 , 638), 	new Vector2(830 , 638), 	new Vector2(890 , 638), 	new Vector2(950 , 638), 	
        //                  new Vector2(950 , 53),  new Vector2(950 , 118), new Vector2(950 , 183), new Vector2(950 , 248), new Vector2(950 , 313), new Vector2(950 , 378), new Vector2(950 , 443), new Vector2(950 , 508), new Vector2(950 , 573), 
        //                  new Vector2(110 , 53), 	new Vector2(170 , 53), 	new Vector2(230 , 53), 	new Vector2(290 , 53), 	new Vector2(350 , 53), 	new Vector2(410 , 53), 	new Vector2(470 , 53), 	new Vector2(530 , 53), 	new Vector2(590 , 53), 	new Vector2(650 , 53), 	new Vector2(710 , 53), 	new Vector2(770 , 53), 	new Vector2(830 , 53), 	new Vector2(890 , 53)             
        //                };

        Vector2[] casas = {
                              new Vector2(96 , 86), new Vector2(96 , 129), new Vector2(96 , 172), new Vector2(96 , 215), new Vector2(96 , 258), new Vector2(96 , 301), new Vector2(96 , 344), new Vector2(96 , 387), new Vector2(96 , 430), new Vector2(96 , 473), new Vector2(96 , 559), 
                              new Vector2(144 , 559), new Vector2(192 , 559), new Vector2(240 , 559), new Vector2(288 , 559), new Vector2(336 , 559), new Vector2(384 , 559), new Vector2(432 , 559), new Vector2(480 , 559), new Vector2(528 , 559), new Vector2(576 , 559), new Vector2(624 , 559), new Vector2(672 , 559), new Vector2(720 , 559), new Vector2(768 , 559), new Vector2(816 , 559), 
                              new Vector2(912 , 473), new Vector2(912 , 430), new Vector2(912 , 387), new Vector2(912 , 344), new Vector2(912 , 301), new Vector2(912 , 258), new Vector2(912 , 215), new Vector2(912 , 172), new Vector2(912 , 129), new Vector2(912 , 86), 
                              new Vector2(816 , 0), new Vector2(768 , 0), new Vector2(720 , 0), new Vector2(672 , 0), new Vector2(624 , 0), new Vector2(576 , 0), new Vector2(528 , 0), new Vector2(480 , 0), new Vector2(432 , 0), new Vector2(384 , 0), new Vector2(336 , 0), new Vector2(288 , 0), new Vector2(240 , 0), new Vector2(192 , 0), new Vector2(144 , 0), new Vector2(96 , 0), 
                          };


        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        protected override void LoadContent( )
        {
            Random random = new Random();
            int casa = random.Next(0, casas.Length);

            
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/Jugadores"),Vector2.Zero, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(6, 6), "", SpriteEffects.None, new Point(0,0));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
           // spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(300, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
          //  spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 300), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            spriteList.Add(new EvadingSprite(Game.Content.Load<Texture2D>(@"Images/NPC"), casas[casa], new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", this, .75f, 150, SpriteEffects.None, new Point(0, 0)));

            //player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/Jugadores"), Vector2.Zero, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(6, 6), SpriteEffects.None, new Point(0, 0), 1, 5);
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), SpriteEffects.None, new Point(0, 0), 1, 5));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(300, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), SpriteEffects.None, new Point(0, 0), 1, 5));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 300), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), SpriteEffects.None, new Point(0, 0), 1, 5));
            //spriteList.Add(new EvadingSprite(Game.Content.Load<Texture2D>(@"Images/NPC"), new Vector2(600, 400), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), 20, SpriteEffects.None, new Point(0, 0), 1, 5));

            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            //// Update player
            //player.Update(gameTime, Game.Window.ClientBounds);
            //// Update all sprites
            //foreach (Sprite s in spriteList)
            //{
            //    s.Update(gameTime, Game.Window.ClientBounds);
            //    // Check for collisions and exit game if there is one
            //    if (s.collisionRect.Intersects(player.collisionRect))
            //    {
            //        //Game.Exit();
                    
            //    }
            //}
            UpdateSprites(gameTime);

            base.Update(gameTime);
        }

        protected void UpdateSprites(GameTime gameTime)
        {
            // Update player
            player.Update(gameTime, Game.Window.ClientBounds);

            // Update all non-player sprites
            for (int i = 0; i < spriteList.Count; ++i)
            {
                Sprite s = spriteList[i];

                s.Update(gameTime, Game.Window.ClientBounds);

                // Check for collisions
                if (s.collisionRect.Intersects(player.collisionRect))
                {

                }
  

            }

        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            // Draw the player
            player.Draw(gameTime, spriteBatch);
            // Draw all sprites
            foreach (Sprite s in spriteList)
                s.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public Vector2 GetPlayerPosition()
        {
            return player.GetPosition;
        }
    }
}
