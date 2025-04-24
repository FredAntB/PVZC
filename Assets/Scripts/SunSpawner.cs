using System.Collections;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    private IEnumerator coroutine;

    IEnumerator SpawnAfterFixedTime(GameObject Sun)
    {
        yield return new WaitForSeconds(5);
        GameObject NewSun = Instantiate(Sun);
    }

    public void SpawnSun(GameObject Sun)
    {
        coroutine = SpawnAfterFixedTime(Sun);
        StartCoroutine(coroutine);
    }
}
