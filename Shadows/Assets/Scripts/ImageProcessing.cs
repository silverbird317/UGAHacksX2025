namespace ImageProcessing
{
    using UnityEngine;
    using System.Collections;
    using OpenCvSharp;
    using UnityEngine.UI;
    using System;
    using System.IO;
    using UnityEngine.SceneManagement;

    public class ImageProcessor : MonoBehaviour
    {
        //private bool slice = false;

        public Texture2D texture;

        // Use this for initialization
        public void GetContours()
        {
            //Load texture
            Mat image = Unity.TextureToMat(this.texture);

            //Gray scale image
            Mat grayMat = new Mat();
            Cv2.CvtColor(image, grayMat, ColorConversionCodes.BGR2GRAY);

            Mat thresh = new Mat();
            Cv2.Threshold(grayMat, thresh, 127, 255, ThresholdTypes.BinaryInv);


            // Extract Contours
            Point[][] contours;
            HierarchyIndex[] hierarchy;
            Cv2.FindContours(thresh, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxNone, null);

            int numPoints = 40;

            Point[][] simplify_contours = new Point[contours.Length][];
            for (int i = 0; i < contours.Length; i++)
            {
                simplify_contours[i] = new Point[numPoints];
                for (int j = 0; j < numPoints; j++)
                {
                    simplify_contours[i][j] = new Point(0, 0);
                }
            }
            for (int i = 0; i < simplify_contours.Length; i++)
            {


                // every numStep other point
                for (int j = 0; j < numPoints; j++)
                {
                    int end = j * contours[i].Length / numPoints;
                    if (j * contours[i].Length / numPoints > contours[i].Length)
                    {
                        end = contours[i].Length - 1;
                    } // if
                    simplify_contours[i][j] = contours[i][end];
                } // for
            } // for

            for (int i = 0; i < simplify_contours.Length; i++)
            {
                Debug.Log(i + ": " + simplify_contours[i][0] + ", " + simplify_contours[i][1] + ", " + simplify_contours[i][2]);
            }

            // drawing
            for (int i = 0; i < simplify_contours.Length; i++)
            {
                Point[] contour = simplify_contours[i];
                Debug.Log(i + ": " + contour[0] + ", " + contour[1] + ", " + contour[2]);

                double length = Cv2.ArcLength(contour, true);
                Point[] approx = Cv2.ApproxPolyDP(contour, length * 0.01, true);
                string shapeName = "cube";
                Scalar color = new Scalar();
                color = new Scalar(0, 255, 255);

                if (shapeName != null)
                {
                    Moments m = Cv2.Moments(contour);
                    int cx = (int)(m.M10 / m.M00);
                    int cy = (int)(m.M01 / m.M00);

                    Cv2.DrawContours(image, new Point[][] { contour }, 0, color, -1);
                    Cv2.PutText(image, shapeName, new Point(cx - 50, cy), HersheyFonts.HersheySimplex, 1.0, new Scalar(0, 0, 0));
                }
            }


            // Render texture
            Texture2D texture = Unity.MatToTexture(image);
            RawImage rawImage = gameObject.GetComponent<RawImage>();
            rawImage.texture = texture;

            //slice = false;

            // export collider points to txt file
            Debug.Log("Exporting contour coordinates to txt file");
            // Set a variable to the Documents path.

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Assets/TXT Files/Contours.txt", false);
                //Write a line of text
                for (int i = 0; i < simplify_contours.Length; i++)
                {
                    sw.WriteLine("New Collider");
                    for (int j = 0; j < simplify_contours[i].Length; j++)
                    {
                        sw.WriteLine(simplify_contours[i][j]);
                    } // for
                } // for
                  //Close the file
                sw.Close();

                StreamWriter sw2 = new StreamWriter("Assets/TXT Files/RetrySceneName.txt", false);
                sw2.WriteLine(SceneManager.GetActiveScene().name);
                sw2.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            } // try-catch-finally

            // after image segmentation, go to 2D trial scene
            SceneManager.LoadScene("Shadows2D Scene");

            // } // if

        } // GetContours
    }
}