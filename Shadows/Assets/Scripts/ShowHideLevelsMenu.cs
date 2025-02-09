using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideLevelsMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    // Start is called before the first frame update
    void Start()
    {
        levelMenu.SetActive(false);
    }

    public void SetActive(bool active) {
        levelMenu.SetActive(active);
    } // SetActive
}
