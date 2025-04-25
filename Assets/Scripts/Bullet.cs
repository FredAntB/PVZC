using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private int Damage;

    public void SetDamage(int damage)
    {
        Damage = damage;
    }

    public void Update() {
        transform.Translate(new Vector3(Speed*Time.deltaTime, 0f, 0f));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 9 => zombie
        if(collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<ZombieMovement>().ReceiveDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
