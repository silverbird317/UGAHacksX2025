using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] GameObject shadowCam;
    [SerializeField] GameObject objectsCam;
    [SerializeField] GameObject photoCam;

    [SerializeField] GameObject shadowCanvas;
    [SerializeField] GameObject objectsCanvas;
    [SerializeField] GameObject photoCanvas;

    private void Awake()
    {
        shadowCam.SetActive(false);
        objectsCam.SetActive(true);
        photoCam.SetActive(false);

        shadowCanvas.SetActive(false);
        objectsCanvas.SetActive(true);
        photoCanvas.SetActive(false);
    } // Awake

    public void switchCamera(int cameraNum) {
        Debug.Log("click: " + cameraNum);
        if (cameraNum == 0)
        {
            shadowCam.SetActive(true);
            objectsCam.SetActive(false);
            photoCam.SetActive(false);

            shadowCanvas.SetActive(true);
            objectsCanvas.SetActive(false);
            photoCanvas.SetActive(false);
        }
        else if (cameraNum == 1)
        {
            shadowCam.SetActive(false);
            objectsCam.SetActive(true);
            photoCam.SetActive(false);

            shadowCanvas.SetActive(false);
            objectsCanvas.SetActive(true);
            photoCanvas.SetActive(false);
        }
        else if (cameraNum == 2) {
            shadowCam.SetActive(false);
            objectsCam.SetActive(false);
            photoCam.SetActive(true);

            shadowCanvas.SetActive(false);
            objectsCanvas.SetActive(false);
            photoCanvas.SetActive(true);
        }
    } // switchCamera
}
