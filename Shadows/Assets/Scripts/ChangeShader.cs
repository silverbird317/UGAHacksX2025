using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader : MonoBehaviour
{
    [SerializeField] Material changeToMaterial;
    Material startFromMaterial;

    // Start is called before the first frame update
    void Start()
    {
        startFromMaterial = GetComponent<Material>();
    }

    public void MakeInvisible() {
        GetComponent<MeshRenderer>().material = changeToMaterial;
    } // ChangeToInvisible

    public void MakeVisible() {
        GetComponent<MeshRenderer>().material = startFromMaterial;
    } // ChangeToInvisible
}
