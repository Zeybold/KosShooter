using System.Net.Mime;
using Microsoft.Xna.Framework;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KosShooter;

public class World
{
    public World()
    {
        EntityProcessing.Add(new Player());
        EntityProcessing.Add(new Enemy());
        Mouse.SetCursor(MouseCursor.FromTexture2D(Configurations.ContentGame.Load<Texture2D>("TextureGames/Cursor/aim"),10,10));
    }

    public void Update(GameTime gameTime)
    {
        EntityProcessing.Update(gameTime);
    }

    public void Draw()
    {
        EntityProcessing.Draw();
    }
}