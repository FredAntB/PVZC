using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public int Health;
    public int Damage;
    public float Speed;
    private bool isEating;


    private void Start()
    {
        isEating = false;
    }

    public void Update() {
        if (!isEating)
        {
            transform.Translate(new Vector3(Speed * -1, 0f, 0f));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // zombie collides with any object at layer 8 => plant
        if(collision.gameObject.layer == 8)
        {
            isEating = true;
        }
    }

    public void ReceiveDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            transform.parent.GetComponent<SpawnPoint>().zombies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
