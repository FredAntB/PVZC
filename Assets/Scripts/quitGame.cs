using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class quitGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData pointerEventData) {
        Application.Quit();
    }
}
