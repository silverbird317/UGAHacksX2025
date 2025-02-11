using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetActiveScript : MonoBehaviour
{
    [SerializeField] GameObject obj;
    
    // Set object to inactive on start
    void Start() {
        obj.SetActive(false);
    }

    /* 
     * Set object to active or inactive based
     * --------------------------------------
     * parameters: bool active 
     * returns: none
     */
    public void SetActive(bool active) {
        obj.SetActive(active);
    } // SetActive
}
