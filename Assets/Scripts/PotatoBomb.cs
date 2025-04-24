using UnityEngine;
using System.Collections.Generic;

public class PotatoBomb : Plant
{   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 9 => zombies
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<ZombieMovement>().ReceiveDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
