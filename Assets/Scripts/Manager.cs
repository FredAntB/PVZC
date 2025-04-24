using UnityEngine;
using TMPro;
using System.Collections;

public class Manager : MonoBehaviour
{
    public GameObject Sun;
    public GameObject SunHolder;

    public GameObject draggedPlant;
    public GameObject currentContainer;
    public TMP_Text sunCounter;

    private cardBehaviour card;

    public static Manager manager;

    private void Awake() {
        manager = this;
        StartCoroutine("SpawnSuns");
    }

    public void PlacePlant()
    {
        int sunCount = int.Parse(sunCounter.text);

        if (draggedPlant != null && currentContainer != null && sunCount > 0)
        {
            card = draggedPlant.GetComponent<PlantDrag>().card;
            
            if (sunCount - card.Cost < 0) {
                return;
            }

            GameObject plant = Instantiate(card.plant, currentContainer.transform);
            currentContainer.GetComponent<plantContainer>().isFull = true;

            plant.GetComponent<Plant>().zombies = currentContainer.GetComponent<plantContainer>().spawnPoint.zombies;

            sunCounter.text = (sunCount - card.Cost).ToString();
        }
    }

    public IEnumerator SpawnSuns()
    {
        while(true) {
            yield return new WaitForSeconds(5f);

            Vector3 spawnPoint = new Vector3(Random.Range(-260.0f, 150.0f), 0f, 0f);
            GameObject sun_instance = Instantiate(Sun, SunHolder.transform.position + spawnPoint, Quaternion.identity, SunHolder.transform);
            sun_instance.GetComponent<updateSun>().SetSunCounter(sunCounter);
        }
    }
}
