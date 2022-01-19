using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;

    public float faceX;

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        webCamTexture = new WebCamTexture(devices[0].name);
        webCamTexture.Play();

        cascade = new CascadeClassifier("Assets/haarcascade_frontalface_default.xml");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GetComponent<Renderer>().material.mainTexture = webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(webCamTexture);

        findNewFace(frame);
        display(frame);
    }

    void findNewFace(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            Debug.Log(faces[0].Location);
            MyFace = faces[0];
            faceX = faces[0].X;
        }
    }

    void display(Mat frame)
    {
        if (MyFace != null)
        {
            frame.Rectangle(MyFace, new Scalar(250, 0, 0), 5);
        }

        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }
}
