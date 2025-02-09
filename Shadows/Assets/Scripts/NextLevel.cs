using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;

    void Awake() {
        victoryScreen.SetActive(false);
    }// Awake

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            Debug.Log("hyohyohyo");
            victoryScreen.SetActive(true);
        } // if
    } // OnTriggerEnter2D
} // RespawnPlayer
