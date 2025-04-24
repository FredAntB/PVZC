using UnityEngine;

public class Wallnut : Plant
{
    public void Update()
    {
        if (Health <= 0)
        {
            transform.parent.GetComponent<plantContainer>().isFull = false;
            Destroy(this.gameObject);
        }
    }
}
