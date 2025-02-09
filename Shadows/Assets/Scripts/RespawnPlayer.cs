using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Player")) {
            collider.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collider.gameObject.transform.position = respawnPoint.transform.position;
        } // if
    } // OnTriggerEnter2D
} // RespawnPlayer
