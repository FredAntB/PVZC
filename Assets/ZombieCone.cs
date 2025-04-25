using UnityEngine.UI;
using UnityEngine;

public class ZombieCone : ZombieMovement
{
    public Image Cone;
    public Sprite Cone_damaged;
    public Sprite Cone_broken;

    public override void ReceiveDamage(int Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else if (Health <= 100)
        {
            outer_hand.enabled = false;            
            outer_arm_bottom.enabled = false;
            outer_arm_top.sprite = half_arm;
        }
        else if (Health <= 200)
        {
            Cone.enabled = false;
        }
        else if (Health <= 300)
        {
            Cone.sprite = Cone_broken;
        }
        else if (Health <= 400)
        {
            Cone.sprite = Cone_damaged;
        }
    }
}
