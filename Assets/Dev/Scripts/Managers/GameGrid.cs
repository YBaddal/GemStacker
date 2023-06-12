using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] float space=1.5f;
    [SerializeField] GameObject gridPrefab;
    GameObject[,] grid; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Create()
    {
        grid = new GameObject[width, height];

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                grid[x,y] = Instantiate(gridPrefab,new Vector3(x*space,0,y*space),Quaternion.identity);
                grid[x,y].transform.SetParent(transform,false);
                grid[x,y].gameObject.name = "Grid "+x+"|"+y;
            }
        }
    }

    public void Reset()
    {
        for(int i = transform.childCount-1; i >= 0; i--)
            DestroyImmediate(transform.GetChild(i).gameObject);
    }
}
