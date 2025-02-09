using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject regularScreen;

    void Awake() {
        victoryScreen.SetActive(false);
        regularScreen.SetActive(true);
    }// Awake

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            Debug.Log("hyohyohyo");
            victoryScreen.SetActive(true);
            regularScreen.SetActive(false);
        } // if
    } // OnTriggerEnter2D
} // RespawnPlayer
