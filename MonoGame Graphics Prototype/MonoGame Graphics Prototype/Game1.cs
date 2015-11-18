using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Graphics_Prototype {

    public class Game1 : Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        Sprite sprite;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize() {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite = new Sprite(Content.Load<Texture2D>("stick"), 50.0f, 50.0f, 0.0f, 3.0f);
            font = Content.Load<SpriteFont>("basic_font");
        }

        protected override void UnloadContent() {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime) {
            /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();*/

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
        //public void drawAnimatedSprite(AnimatedSprite s) {
            //TO DO: Implement me please
        //}

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

            drawSprite(sprite);
            drawText("Time Elapsed: " + gameTime.TotalGameTime.TotalMilliseconds, 10.0f, 10.0f, Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
