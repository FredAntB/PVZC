using UnityEngine;

public class ZombieCommon : ZombieMovement
{
    public override void ReceiveDamage(int Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            animator.SetTrigger("die");
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
        }
        else if (Health <= 100)
        {
            outer_hand.enabled = false;            
            outer_arm_bottom.enabled = false;
            outer_arm_top.sprite = half_arm;
        }
    }
}
