using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerController : MonoBehaviour
{

    public static BoardManagerController instance;

    public GameObject tilePrefab;

    private float prefabWidth;
    private float prefabHeight;

    public int columnsCount;
    public int rowsCount;
    public float itemMargin;
    public float startXOffset;
    public float startYOffset;

    public GameObject[] tilesPull;
    private GameObject[,] gameTiles;

    void Start()
    {
        prefabWidth = tilePrefab.GetComponent<Renderer>().bounds.size.x;
        prefabHeight = tilePrefab.GetComponent<Renderer>().bounds.size.y;

        gameTiles = new GameObject[columnsCount, rowsCount];

        PopulateTiles();
    }

    void PopulateTiles() {
        int currentPullIdex = 0;
        float startX = transform.position.x + startXOffset;
        float startY = transform.position.y + startYOffset;

        for (int x = 0; x < columnsCount; x++)
        {      
            for (int y = 0; y < rowsCount; y++)
            {
                float currentXPos = startX + itemMargin * x;
                float currentYPos = startY + itemMargin * y;

                GameObject newTile = tilesPull[currentPullIdex];//Instantiate(tilesPull[x + y], new Vector3(currentXPos + (prefabWidth * x), currentYPos + (prefabHeight * y), 0), tilesPull[x + y].transform.rotation);
                newTile.transform.position = new Vector3(currentXPos + (prefabWidth * x), currentYPos + (prefabHeight * y), 0);
                gameTiles[x, y] = newTile;

                currentPullIdex++;

                Debug.Log(x + y);

            }
        }

    }

  

}
