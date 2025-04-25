using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class updateSun : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text sunCounter;
    public float minHeight;
    public int value;

    public void SetSunCounter(TMP_Text text_box) {
        sunCounter = text_box;
    }

    private void Start() {
        minHeight = 60;
    }

    private void Update() {
        if (transform.position.y > minHeight)
        {
            transform.position += new Vector3(0f, -4f, 0f);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        sunCounter.text = (int.Parse(sunCounter.text) + value).ToString();
        Destroy(this.gameObject);
    }
}