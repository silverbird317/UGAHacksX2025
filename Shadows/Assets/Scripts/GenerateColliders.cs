using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using OpenCvSharp;
using UnityEngine.UI;

public class GenerateColliders : MonoBehaviour
{
    List<List<Vector2>> colliderData = new List<List<Vector2>>();
    string colliderDataPath = "Assets/Contours/Contours.txt";
    string filenamePath = "Assets/Contours/Filename.txt";

    [SerializeField] GameObject showShadowImage;

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
                    double scale = 9.4;
                    float x = (float)((float.Parse(line.Substring(line.IndexOf('x') + 2, line.IndexOf(' ') - (line.IndexOf('x') + 2))) / scale) - (960 / scale));
                    float y = (float)(((float.Parse(line.Substring(line.IndexOf('y') + 2, line.IndexOf(')') - (line.IndexOf('y') + 2))) / scale) * -1) + (540 / scale));
                    tempPointsList.Add(new Vector2(x, y));
                } // if-else
            } // while
            colliderData.Add(tempPointsList);

            Debug.Log("rowCount: " + rowCount);

            // Create GameObjects
            for (int i = 0; i <= rowCount; i++) {
                GameObject obj = new GameObject("GameObject " + i);
                obj.AddComponent<PolygonCollider2D>();
                //obj.AddComponent<SpriteRenderer>();
                obj.transform.position = new Vector3(0, 0, 90);
                //obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("collider");
                //obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
                obj.GetComponent<PolygonCollider2D>().points = colliderData[i].ToArray();
                objs.Add(obj);
            } // for
        } // using

        //spawn object

        /*obj = new GameObject("GameObject 1");
        obj.AddComponent<PolygonCollider2D>();
        obj.AddComponent<SpriteRenderer>();
        obj.transform.position = new Vector3(0, 0, 5);
        obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("collider");
        obj.GetComponent<PolygonCollider2D>().points = colliderData[0].ToArray();
        */


        // get filename from txt file
        string filepath = "";
        using (StreamReader read = new StreamReader(filenamePath))
        {
            string line;
            while ((line = read.ReadLine()) != null)
            {
                filepath = line;
            } // while

        } // using
        // C:/Users/Gaga/Documents/GitHub/UGAHacksX2025/Shadows/Assets/Resources/Screenshots/screen_1920x1080_2025-02-08_21-45-35.png
        Texture2D texture = new Texture2D(1, 1);
        byte[] imageBytes = File.ReadAllBytes(filepath);
        texture.LoadImage(imageBytes);

        // Create a new Sprite from the texture
        Sprite newSprite = Sprite.Create(texture, new UnityEngine.Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        // Assign the new Sprite to the Sprite 
        showShadowImage.GetComponent<Image>().sprite = newSprite;

        //showShadowImage.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("screen_1920x1080_2025-02-08_21-35-52");
    } // Start

    // Update is called once per frame
    void Update()
    {
        
    }
}
