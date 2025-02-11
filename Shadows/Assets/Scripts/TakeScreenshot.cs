using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Threading;

public class TakeScreenshot : MonoBehaviour
{
    [SerializeField] GameObject processorContainer;
    ImageProcessing.ImageProcessor processor;
    [SerializeField] GameObject canvas;

    public int resWidth = 2550;
    public int resHeight = 3300;

    //private bool takeHiResShot = false;

    private void Awake()
    {
        processor = processorContainer.GetComponent<ImageProcessing.ImageProcessor>();
    }

    public static string ScreenShotName(int width, int height)
    {
        return string.Format("{0}/Screenshots/screen_{1}x{2}_{3}.png",
                             Application.dataPath,
                             width, height,
                             System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

    /*public void TakeHiResShot()
    {
        takeHiResShot = true;
    }*/

    public void SaveScreenshot()
    {
        //takeHiResShot |= Input.GetKeyDown("k");
        //if (takeHiResShot) {
        // hide canvas before screenshot
        canvas.SetActive(false);

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        GetComponent<Camera>().targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        GetComponent<Camera>().Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        GetComponent<Camera>().targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = ScreenShotName(resWidth, resHeight);
        System.IO.File.WriteAllBytes(filename, bytes);


        Debug.Log(string.Format("Took screenshot to: {0}", filename));
        //takeHiResShot = false;


        // set texture of segmentation to newly screenshoted picture
        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filename))
        {
            Debug.Log("exists");
            fileData = File.ReadAllBytes(filename);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        else
        {
            Debug.Log("nonexistant");
        } // if-else
        processor.texture = tex;

        // show camera after screenshot
        canvas.SetActive(true);

        // add file path to Contours.txt after
        try
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("Assets/TXT Files/Filename.txt", false);
            //Write a line of text
            sw.WriteLine(filename);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        } // try-catch-finally
        // } // if
    } // SaveScreenshot
}