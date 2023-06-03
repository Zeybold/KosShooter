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
        Configurations.LoadGraphicsDeviceManager(this);
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

        Configurations.LoadSpriteBach(GraphicsDevice);
        Configurations.LoadContent(Content);
        
        _worldSystemGame = new WorldSystem();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape) || Player.Creature.CurrentHp <= 0)
            Exit();
        Configurations.UpdateGameTime(gameTime);
        if (Player.Creature.CurrentHp <= 0)
            _worldSystemGame = new WorldSystem();
        else
            _worldSystemGame.Update();
        base.Update(gameTime);
        Configurations.ScreenResultInit();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        _worldSystemGame.Draw();
        base.Draw(gameTime);
    }
}