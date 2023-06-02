using KosShooter.Items;
using Microsoft.Xna.Framework;

namespace KosShooter;

public class Daemon : Enemy
{
    public Daemon(Vector2 position) : base(position)
    {
        EmStatus = EnemyStatus.Daemon;
        Texture = TextureSource.Enemies[(int)EmStatus];
        Velocity = 100;
        Damage = 20;
        MaxHp = 50;
        CurrentHp = MaxHp;
        DrItSys.AddItem(new AiItemWeaponAmmunition(),0.3f);
        DrItSys.AddItem(new AiItemAidKit(15),0.4f);
        DrItSys.AddItem(new AiItemAidKit(),0.15f);
        DrItSys.AddItem(new AiItemWeaponAmmunition(1),0.05f);
    }
}