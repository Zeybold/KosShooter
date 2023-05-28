using System.Net.Mime;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public static class Configurations
{
    public static SpriteBatch SpriteBatch{ get; private set; }
    public static ContentManager ContentGame{ get; private set; }
    public static int ScreenHeight{ get; private set; }
    public static int ScreenWidth{ get; private set; }
    private static GraphicsDeviceManager GraphicsDeviceManager{ get; set; }
    public static readonly Color BaseColor = Color.White;
    public static float IndependentActionsFromFramrate{ get; private set; }
    public static bool IsFreezeTime{ get; set; }
    public static float Time { get; set; }

    public static void ScreenResultInit()
    {
        GraphicsDeviceManager.PreferredBackBufferWidth = GraphicsDeviceManager.GraphicsDevice.DisplayMode.Width;
        ScreenWidth = GraphicsDeviceManager.PreferredBackBufferWidth;
        GraphicsDeviceManager.PreferredBackBufferHeight = GraphicsDeviceManager.GraphicsDevice.DisplayMode.Height;
        ScreenHeight = GraphicsDeviceManager.PreferredBackBufferHeight;
        GraphicsDeviceManager.ApplyChanges();
        GraphicsDeviceManager.IsFullScreen = false;
    }

    public static void UpdateGameTime(GameTime gameTime)
    {
        Time = (float)gameTime.ElapsedGameTime.TotalSeconds;
        TimeSystem.Update(gameTime);
        IndependentActionsFromFramrate=TimeSystem.FreezeTime;
    }

    public static void LoadSpriteBach(GraphicsDevice graphicsDevice)
    {
        SpriteBatch = new SpriteBatch(graphicsDevice);
    }
    public static void LoadContent(ContentManager content)
    {
        ContentGame = content;
    }
    public static void LoadGraphicsDeviceManager(Game game)
    {
        GraphicsDeviceManager = new GraphicsDeviceManager(game);
    }
}