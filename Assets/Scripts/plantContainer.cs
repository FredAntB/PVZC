using UnityEngine;
using UnityEngine.UI;

public class plantContainer : MonoBehaviour
{
    public bool isFull;
    public Manager manager;

    public Image highlight;
    
    public SpawnPoint spawnPoint;
    private void Start()
    {
        manager = Manager.manager;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager.draggedPlant != null && !isFull)
        {
            manager.currentContainer = this.gameObject;
            highlight.enabled = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
            manager.currentContainer = null;
            highlight.enabled = false;
    }
}
