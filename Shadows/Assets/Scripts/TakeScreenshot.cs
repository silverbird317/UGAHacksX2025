using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Threading;

public class TakeScreenshot : MonoBehaviour
{
    [SerializeField] GameObject processorContainer;
    ImageProcessing.ImageProcessor processor;

    public int resWidth = 2550;
    public int resHeight = 3300;

    private bool takeHiResShot = false;

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

    public void TakeHiResShot()
    {
        takeHiResShot = true;
    }

    void LateUpdate()
    {
        takeHiResShot |= Input.GetKeyDown("k");
        if (takeHiResShot)
        {
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



            // make readable
            /*string line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(filename + ".meta");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                int counter = 0;
                int line_to_edit = 0;
                while (line != null)
                {
                    //write the line to console window
                    Debug.Log(line);
                    if (line.Contains("  isReadable: 0")) {
                        line_to_edit = counter;
                    } // if
                    //Read the next line
                    line = sr.ReadLine();
                    counter++;
                }
                //close the file
                sr.Close();
                Debug.Log("sleepy");
                Thread.Sleep(new TimeSpan(0, 0, 1));
                Debug.Log("awake");
                string newText = "isReadable: 1";
                string[] arrLine = File.ReadAllLines(filename + ".meta");
                arrLine[line_to_edit - 1] = newText;
                File.WriteAllLines(filename + ".meta", arrLine);
            }
            catch (Exception e)
            {
                Debug.Log("Exception: " + e.Message);
            }
            finally
            {
                Debug.Log("Executing finally block.");
            }*/
            
         




            Debug.Log(string.Format("Took screenshot to: {0}", filename));
            takeHiResShot = false;


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
            else {
                Debug.Log("nonexistant");
            }
            processor.texture = tex;
        }
    }
}