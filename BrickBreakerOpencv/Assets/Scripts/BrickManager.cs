using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] float spacing;
    [SerializeField] GameObject brickPrefab;

    private List<GameObject> bricks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    { 
       ResetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetLevel()
    {
        foreach(GameObject brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();

        for(int x=0; x < rows; x++)
        {
            for (int y=0; y < columns; y++)
            {
                Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                    x * (brickPrefab.transform.localScale.x + spacing),
                    -y * (brickPrefab.transform.localScale.y + spacing));
                GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                bricks.Add(brick);
            }
        }
    }

    public void RemoveBrick(Brick brick)
    {
        bricks.Remove(brick.gameObject);
        if(bricks.Count == 0)
        {
            ResetLevel();
        }
    }
}
