using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        Color[]  colors =  { Color.green, Color.red, Color.blue};
        int rndColor = Random.Range(0, colors.Length);
        gameObject.GetComponent<Renderer>().material.color = colors[rndColor];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        FindObjectOfType<BrickManager>().RemoveBrick(this);
    }
}
