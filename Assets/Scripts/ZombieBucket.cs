using UnityEngine.UI;
using UnityEngine;

public class ZombieBucket : ZombieMovement
{
    public Image Bucket;
    public Sprite Bucket_damaged;
    public Sprite Bucket_broken;

     public override void ReceiveDamage(int Damage)
    {
        Health -= Damage;

        if (Health <= 0)
        {
            animator.SetTrigger("die");
            Bucket.enabled = false;
            SpawnPoint spawnPoint = transform.parent.GetComponent<SpawnPoint>();
            spawnPoint.zombies.Remove(this.gameObject);
            spawnPoint.reduceZombieCountBy(1);
        }
        else if (Health <= 100)
        {
            outer_hand.enabled = false;            
            outer_arm_bottom.enabled = false;
            outer_arm_top.sprite = half_arm;
        }
        else if (Health <= 200)
        {
            Bucket.enabled = false;
        }
        else if (Health <= 300)
        {
            Bucket.sprite = Bucket_broken;
        }
        else if (Health <= 400)
        {
            Bucket.sprite = Bucket_damaged;
        }
    }
}
