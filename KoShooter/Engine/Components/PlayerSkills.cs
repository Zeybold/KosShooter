namespace KosShooter;

public static class PlayerSkills
{
    public static float SixSence { get; private set; }
    public static float SharpShooting{ get; private set; }
    public static float Luck{ get; private set; }
    public static float Speed{ get; private set; }
    public static float HP{ get; private set; }

    public static void ResetCharacter()
    {
        SixSence = 1;
        SharpShooting = 1;
        Luck = 1;
        Speed = 1;
        HP = 1;
    }

    public static void LevelUp()
    {
        SixSence*=0.1f;
        SharpShooting/=0.1f;
        Luck*=0.1f;
        Speed*=0.1f;
        HP*=0.1f;
    }
}