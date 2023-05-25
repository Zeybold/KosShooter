using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class KosShooter : Game
{
    private WorldSystem _worldSystemGame;
    public KosShooter()
    {
        Configurations.GraphicsDeviceManager = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Configurations.ScreenResultInit();
        base.Initialize();
    }

    protected override void LoadContent()
    {

        Configurations.SpriteBatch = new SpriteBatch(GraphicsDevice);
        Configurations.ContentGame = Content;
        
        _worldSystemGame = new WorldSystem();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Configurations.UpdateGameTime(gameTime);
        _worldSystemGame.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        Configurations.SpriteBatch.Begin();
        _worldSystemGame.Draw();
        Configurations.SpriteBatch.End();
        base.Draw(gameTime);
    }
}