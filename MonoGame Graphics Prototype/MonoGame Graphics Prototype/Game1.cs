using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace MonoGame_Graphics_Prototype {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        AnimatedSprite sprite;
        ParticleFX PFX;
        List<Texture2D> particleTexts = new List<Texture2D>();
        List<Particle> particles = new List<Particle>();

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            PFX = new ParticleFX();
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite = new AnimatedSprite(Content.Load<Texture2D>("animZombie"), 50.0f, 50.0f, 51, 108, 250);
            font = Content.Load<SpriteFont>("basic_font");
            particleTexts.Add(Content.Load<Texture2D>("particle"));
            particleTexts.Add(Content.Load<Texture2D>("particle2"));
            particleTexts.Add(Content.Load<Texture2D>("particle3"));
            particleTexts.Add(Content.Load<Texture2D>("particle4"));
            particleTexts.Add(Content.Load<Texture2D>("particle5"));
            particleTexts.Add(Content.Load<Texture2D>("particle6"));
        }

        protected override void UnloadContent() {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime) {

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.A)) {
                PFX.startDirtTrail(50.0f, 50.0f);
            }

            PFX.update(gameTime.ElapsedGameTime.TotalMilliseconds);
            particles = PFX.getParticles();

            if (sprite.getCurrentState() == 1) {
                if (gameTime.TotalGameTime.TotalMilliseconds - sprite.getLastTime() > sprite.getFrameTime()) {
                    sprite.changeFrame(gameTime.TotalGameTime.TotalMilliseconds);
                }
            }

            base.Update(gameTime);
        }

        // Draws a Sprite from all it's variables information
        public void drawSprite(Sprite s) {
            Rectangle scale = new Rectangle((int) s.getPosition().X,
                                            (int) s.getPosition().Y,
                                            (int) (s.getWidth() * s.getScale()),
                                            (int) (s.getHeight() * s.getScale()) );
            spriteBatch.Draw(s.getTexture(), scale, null, Color.White, s.getRotationRadians(), 
                s.getOrigin(), SpriteEffects.None, 0);
        }

        // Draws an animated sprite from all it's variables information
        public void drawAnimatedSprite(AnimatedSprite s) {
            Rectangle destination = new Rectangle(  (int) s.getPosition().X,
                                                    (int) s.getPosition().Y,
                                                    s.getFrameWidth(),
                                                    s.getFrameHeight());
            Rectangle source = new Rectangle(s.getFrameWidth() * s.getCurrentHorizontal(),
                                              s.getFrameHeight() * s.getCurrentVertical(),
                                              s.getFrameWidth(),
                                              s.getFrameHeight());
            spriteBatch.Draw(s.getTexture(), destination, source, Color.White);
        }

        // Uses only the standard font
        public void drawText(string inText, float inX, float inY, Color inColor) {
            spriteBatch.DrawString(font, inText, new Vector2(inX, inY), inColor);
        }

        // For use with different fonts
        public void drawText(string inText, float inX, float inY, Color inColor, SpriteFont inFont) {
            spriteBatch.DrawString(inFont, inText, new Vector2(inX, inY), inColor);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            Random rnd = new Random();
            for (int i = 0; i < particles.Count; i++) {
                if (particles[i].getLife() > 0) {
                    spriteBatch.Draw(particleTexts[rnd.Next(0,6)], new Vector2(particles[i].getPosition().X,
                                                            particles[i].getPosition().Y), Color.White);
                }
            }

            drawAnimatedSprite(sprite);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
