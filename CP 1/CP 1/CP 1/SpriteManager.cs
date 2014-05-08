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


        public static Vector2[] casas ={
                                        new Vector2(0 , 86), new Vector2(0 , 129), new Vector2(0 , 172), new Vector2(0 , 215), new Vector2(0 , 258), new Vector2(0 , 301), new Vector2(0 , 344), new Vector2(0 , 387), new Vector2(0 , 430), new Vector2(0 , 473), 
                                        new Vector2(96 , 559), new Vector2(144 , 559), new Vector2(192 , 559), new Vector2(240 , 559), new Vector2(288 , 559), new Vector2(336 , 559), new Vector2(384 , 559), new Vector2(432 , 559), new Vector2(480 , 559), new Vector2(528 , 559), new Vector2(576 , 559), new Vector2(624 , 559), new Vector2(672 , 559), new Vector2(720 , 559), new Vector2(768 , 559), new Vector2(816 , 559), 
                                        new Vector2(912 , 473), new Vector2(912 , 430), new Vector2(912 , 387), new Vector2(912 , 344), new Vector2(912 , 301), new Vector2(912 , 258), new Vector2(912 , 215), new Vector2(912 , 172), new Vector2(912 , 129), new Vector2(912 , 86), 
                                        new Vector2(816 , 0), new Vector2(768 , 0), new Vector2(720 , 0), new Vector2(672 , 0), new Vector2(624 , 0), new Vector2(576 , 0), new Vector2(528 , 0), new Vector2(480 , 0), new Vector2(432 , 0), new Vector2(384 , 0), new Vector2(336 , 0), new Vector2(288 , 0), new Vector2(240 , 0), new Vector2(192 , 0), new Vector2(144 , 0), new Vector2(96 , 0)
                                     };
        
        //public static Vector2[] casas = {
       //                       new Vector2(0 , 86), new Vector2(0 , 129), new Vector2(0 , 172), new Vector2(0 , 215), new Vector2(06 , 258), new Vector2(0 , 301), new Vector2(0 , 344), new Vector2(0 , 387), new Vector2(0 , 430), new Vector2(0 , 473), new Vector2(0 , 559), 
       //                       new Vector2(144 , 559), new Vector2(192 , 559), new Vector2(240 , 559), new Vector2(288 , 559), new Vector2(336 , 559), new Vector2(384 , 559), new Vector2(432 , 559), new Vector2(480 , 559), new Vector2(528 , 559), new Vector2(576 , 559), new Vector2(624 , 559), new Vector2(672 , 559), new Vector2(720 , 559), new Vector2(768 , 559), new Vector2(816 , 559), 
       //                       new Vector2(912 , 473), new Vector2(912 , 430), new Vector2(912 , 387), new Vector2(912 , 344), new Vector2(912 , 301), new Vector2(912 , 258), new Vector2(912 , 215), new Vector2(912 , 172), new Vector2(912 , 129), new Vector2(912 , 86), 
       //                       new Vector2(816 , 0), new Vector2(768 , 0), new Vector2(720 , 0), new Vector2(672 , 0), new Vector2(624 , 0), new Vector2(576 , 0), new Vector2(528 , 0), new Vector2(480 , 0), new Vector2(432 , 0), new Vector2(384 , 0), new Vector2(336 , 0), new Vector2(288 , 0), new Vector2(240 , 0), new Vector2(192 , 0), new Vector2(144 , 0), new Vector2(96 , 0), 
       //                   };
        public static Vector2[] casas2 = {new Vector2(0, 0), new Vector2(912, 0), new Vector2(0, 559), new Vector2(912, 559) };
        public static Vector2[] salidas = {new Vector2(0 , 43), 	new Vector2(912 , 43), new Vector2(0 , 516), 	new Vector2(912 , 516), new Vector2(48 , 0), 	new Vector2(864 , 0), new Vector2(48 , 559), new Vector2(864 , 559) };

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
            // posicion inicial del npc
            Random random = new Random();
            int casa = random.Next(0, casas.Length);
            Vector2 npc = casas[casa];
            if (npc.X < 100) { npc.X += 350; }
            if (npc.Y < 100) { npc.Y += 350; }
            if (npc.X >100) { npc.X -= 350; }
            if (npc.Y > 100) { npc.Y -= 350; }

            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            player = new UserControlledSprite(Game.Content.Load<Texture2D>(@"Images/Jugadores"),Vector2.Zero, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(6, 6), "", SpriteEffects.None, new Point(0,0));
            //spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
           // spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(300, 150), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
          //  spriteList.Add(new AutomatedSprite(Game.Content.Load<Texture2D>(@"Images/Jugador2"), new Vector2(150, 300), new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(1, 1), "", SpriteEffects.None, new Point(0, 0)));
            spriteList.Add(new EvadingSprite(Game.Content.Load<Texture2D>(@"Images/NPC"), npc, new Point(35, 60), 10, new Point(0, 0), new Point(7, 2), new Vector2(0, 0), "", this, .75f, 150, SpriteEffects.None, new Point(0, 0)));

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
