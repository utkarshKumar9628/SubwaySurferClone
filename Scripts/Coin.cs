using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource audioSource; // Changed the variable name to avoid conflicts

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(0, 200 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerManager.numberOfCoins += 1;

            if (audioSource != null)
            {
                // Check if the audio clip is assigned
                if (audioSource.clip != null)
                {
                    audioSource.Play();
                }
                else
                {
                    Debug.LogWarning("Audio clip is not assigned to the AudioSource in the Coin script.");
                }
            }

            Destroy(gameObject);
            Debug.Log("Coins: " + PlayerManager.numberOfCoins);
        }
    }
}