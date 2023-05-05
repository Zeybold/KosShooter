using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class KosShooter : Game
{
    private World worldGame;
    public KosShooter()
    {
        Configurations.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Configurations.ScreenResultInit();
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        
        Configurations.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Configurations.ContentGame = this.Content;
        
        worldGame = new World();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        worldGame.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // TODO: Add your drawing code here
        Configurations.SpriteBatch.Begin();
        worldGame.Draw();
        Configurations.SpriteBatch.End();
        base.Draw(gameTime);
    }
}