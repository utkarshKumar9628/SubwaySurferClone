using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColliderHit : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element you want to enable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            // Player hit the collider, enable the UI element
            if (uiElement != null)
            {
                uiElement.SetActive(true);
            }
        }
    }
}
