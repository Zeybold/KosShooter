using KosShooter.Engine.UI;

namespace KosShooter;

public static class PlayerSkills
{
    public static float SharpShooting{ get; private set; }
    public static float Luck{ get; private set; }
    public static float Speed{ get; private set; }
    public static float Hp{ get; private set; }
    public static float SpecialAbillity{ get; private set; }

    public static void ResetCharacter()
    {
        SharpShooting = 1;
        Luck = 1;
        Speed = 1;
        Hp = 1;
        SpecialAbillity = 1;
    }

    public static void LevelUp()
    {
        if (SharpShooting-SharpShooting/50f>0)
            SharpShooting-=SharpShooting/50f;
        if (SpecialAbillity + SpecialAbillity / 50f < 3f)
        {
            Player.Creature.UpdateSpecialAbility();
            PlayerInterface.TimeBar.LevelUp(Player.Creature.MaxSpecialAbility);
            SpecialAbillity+=SpecialAbillity/50f;
        }
        if (Luck+Luck/70f<=3f)
            Luck+=Luck/70f;
        if (Speed+Speed/50f<2.5f)
            Speed+=Speed/50f;
        if (Hp + Hp / 50f < 2.5f)
        {
            Player.Creature.UpdateHP();
            PlayerInterface.HealthBar.LevelUp(Player.Creature.MaxHp);
            Hp+=Hp/50f;
        }
    }
}