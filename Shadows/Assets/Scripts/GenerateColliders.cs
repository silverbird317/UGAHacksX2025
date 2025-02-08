using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using OpenCvSharp;

public class GenerateColliders : MonoBehaviour
{
    List<List<Vector2>> colliderData = new List<List<Vector2>>();
    string colliderDataPath = "Assets/Contours/Contours.txt";

    List<GameObject> objs;
    // Start is called before the first frame update
    void Start()
    {
        objs = new List<GameObject>();
        using (StreamReader read = new StreamReader(colliderDataPath))
        {
            string line;
            int rowCount = -1;
            List<Vector2> tempPointsList = new List<Vector2>();
            while ((line = read.ReadLine()) != null)
            {
                if (line.Trim().Equals("New Collider"))
                {
                    if (rowCount >= 0) {
                        colliderData.Add(tempPointsList);
                    } // if
                    rowCount++;
                    tempPointsList = new List<Vector2>();
                } else {
                    float scale = 100;
                    float x = (float.Parse(line.Substring(line.IndexOf('x') + 2, line.IndexOf(' ') - (line.IndexOf('x') + 2))) / scale) - (960 / scale);
                    float y = ((float.Parse(line.Substring(line.IndexOf('y') + 2, line.IndexOf(')') - (line.IndexOf('y') + 2))) / scale) * -1) + (540 / scale);
                    tempPointsList.Add(new Vector2(x, y));
                } // if-else
            } // while
            colliderData.Add(tempPointsList);

            Debug.Log(rowCount);

            // Create GameObjects
            for (int i = 0; i <= rowCount; i++) {
                GameObject obj = new GameObject("GameObject " + i);
                obj.AddComponent<PolygonCollider2D>();
                //obj.AddComponent<SpriteRenderer>();
                obj.transform.position = new Vector3(0, 0, 5);
                //obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("collider");
                //obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
                obj.GetComponent<PolygonCollider2D>().points = colliderData[i].ToArray();
                objs.Add(obj);
            } //
        } // using

        //spawn object

        /*obj = new GameObject("GameObject 1");
        obj.AddComponent<PolygonCollider2D>();
        obj.AddComponent<SpriteRenderer>();
        obj.transform.position = new Vector3(0, 0, 5);
        obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("collider");
        obj.GetComponent<PolygonCollider2D>().points = colliderData[0].ToArray();
        */
    } // Start

    // Update is called once per frame
    void Update()
    {
        
    }
}
