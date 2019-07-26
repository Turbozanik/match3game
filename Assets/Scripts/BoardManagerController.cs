using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManagerController : MonoBehaviour
{

    public static BoardManagerController instance;

    public GameObject tilePrefab;

    private float vertical;
    private float horizontal;
    private float prefabWidth;
    private float prefabHeight;
    private int columnsCount;
    private int rowsCount;
    private int itemMargin = 1;

    public GameObject[] tilesPull;
    private GameObject[,] gameTiles;

    void Start()
    {
        vertical = Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        prefabWidth = tilePrefab.GetComponent<Renderer>().bounds.size.x;
        prefabHeight = tilePrefab.GetComponent<Renderer>().bounds.size.y;
        columnsCount = (int)(horizontal / prefabWidth);
        rowsCount = (int)(vertical / prefabHeight);

        gameTiles = new GameObject[columnsCount, rowsCount];

        Debug.Log("width " + columnsCount);
        Debug.Log("height " + rowsCount);

        populateTiles();
        Debug.Log("tiles size" + gameTiles.Length);
    }

    void populateTiles() {
        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < rowsCount; x++)
        {      
            for (int y = 0; y < columnsCount; y++)
            {
                Debug.Log("position x " + (startX + (prefabWidth * x)) + " position y " + (startY + (prefabHeight * y)));

                GameObject newTile = tilesPull[x + y];
                newTile.transform.position = new Vector3(startX + (prefabWidth * x), startY + (prefabHeight * y), 0);
                gameTiles[x, y] = newTile;
            }
        }

    }

}
