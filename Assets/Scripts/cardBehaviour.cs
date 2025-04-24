using UnityEngine;
using UnityEngine.EventSystems;

public class cardBehaviour : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject picked_plant;
    public GameObject plant;
    public Canvas canvas;
    public int Cost;

    private GameObject plant_instance;
    private Manager manager;

    private void Start()
    {
        manager = Manager.manager;
    }

    public void OnDrag(PointerEventData eventData)
    {
        plant_instance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        plant_instance = Instantiate(picked_plant, canvas.transform);
        plant_instance.transform.position = Input.mousePosition;
        plant_instance.GetComponent<PlantDrag>().card = this;

        Manager.manager.draggedPlant = plant_instance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        manager.PlacePlant();
        manager.draggedPlant = null;
        Destroy(plant_instance);
    }
}
