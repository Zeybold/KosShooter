using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace KosShooter;

public class Configurations
{
    public static SpriteBatch SpriteBatch;
    public static ContentManager ContentGame;
    public static int ScreenHeight;
    public static int ScreenWidth;
    public static GraphicsDeviceManager GraphicsDeviceManager;
    public static Color BaseColor = Color.White;
    public static float IndependentActionsFromFramrate;
    public static bool isFreezeTime;

    public static void ScreenResultInit()
    {
        GraphicsDeviceManager.PreferredBackBufferWidth = GraphicsDeviceManager.GraphicsDevice.DisplayMode.Width;
        ScreenWidth = GraphicsDeviceManager.PreferredBackBufferWidth;
        GraphicsDeviceManager.PreferredBackBufferHeight = GraphicsDeviceManager.GraphicsDevice.DisplayMode.Height;
        ScreenHeight = GraphicsDeviceManager.PreferredBackBufferWidth;
        GraphicsDeviceManager.ApplyChanges();
        GraphicsDeviceManager.IsFullScreen = false;
    }

    public static void UpdateGameTime(GameTime gameTime)
    {
        if (isFreezeTime)
        {
            IndependentActionsFromFramrate = (float)gameTime.ElapsedGameTime.TotalSeconds / 5;
        }
        else
        {
            IndependentActionsFromFramrate = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}