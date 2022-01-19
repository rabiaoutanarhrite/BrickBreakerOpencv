using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
 
    FaceDetector faceDetector;
    OpenCvSharp.Rect myFace;

    private float norm;
    private float lastX;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        faceDetector = (FaceDetector)FindObjectOfType(typeof(FaceDetector));
        //lastX = faceDetector.faceX;
    }  

    // Update is called once per frame
    void LateUpdate()
    {
        
        float step = speed * Time.deltaTime;
        norm = Mathf.Clamp(faceDetector.faceX - lastX, -1, 1);

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + norm, transform.position.y, transform.position.z), step);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x + norm, transform.position.y, transform.position.z), ref velocity, speed);

        lastX = faceDetector.faceX;
    }


}
