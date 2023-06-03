using Microsoft.Xna.Framework;
using static KosShooter.Configurations;

namespace KosShooter.Engine.UI;

public static class PlayerInterface
{
    public static readonly ProgressBar HealthBar = 
        new(TextureSource.HealthBarEmpty, TextureSource.HealthBarFill, Player.Creature.MaxHp,
        new Vector2(ScreenWidth-ScreenWidth/4f, 
            ScreenHeight-ScreenHeight/16f));
    public static readonly ProgressBar TimeBar = 
        new(TextureSource.TimeBarEmpty, TextureSource.TimeBarFill, Player.Creature.MaxSpecialAbility,
            new Vector2(ScreenWidth/100f, 
                ScreenHeight-ScreenHeight/20f));

    private static readonly ProgressBar LeverBar =
    new(TextureSource.LevelBarEmpty, TextureSource.LevelBarFill, Player.Creature.MaxLevelUp,
    new Vector2(ScreenWidth-ScreenWidth/1.7f, 
        ScreenHeight/100f));
    
    public static void Update()
    {
        HealthBar.Update(Player.Creature.CurrentHp);
        TimeBar.Update(Player.Creature.CurrentSpecialAbility);
        LeverBar.Update(Player.Creature.CurrentLevelUp);
    }

    public static void Draw()
    {
        TimeBar.Draw();
        LeverBar.Draw();
        HealthBar.Draw();
    }
}