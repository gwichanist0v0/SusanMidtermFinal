using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid : MonoBehaviour
{
    //Variable Declarations
    public int width;
    public int height;
    public float cellSize;
    private Vector3 originPosition;

    //Multidimentional Array where [,] for x and y of a grid
    private int[,] gridArray;

    //For debug purpose
    private TextMesh[,] debugTextArray;
    MonkTest monkTest;



    //A constructor that receives width and height

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {

        monkTest = GameObject.Find("MokneyTest").GetComponent < MonkTest >(); 

        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];

        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize, cellSize) * .5f, 7, new Color(1f, 1f, 1f, 0f), TextAnchor.MiddleCenter);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }

        //Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        //Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        //Debug.Log("GRID" + width + "HEIGHT" + height);

    }

    //Converts grid position into world position
    public Vector3 GetWorldPosition(int x, int y) 
    {

        return new Vector3(x, y) * cellSize + originPosition;
    }

    //Fucntion that tells X and Y when given a world position, returns multiple values from single function
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        //Converts world position into grid position
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }



    //Set value & avoid error
    public void SetValue(int x, int y, int value)

    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    //Sets value of each grid based on world position
    public void SetValue(Vector3 worldPostiion, int value)
    {
        int x, y;
        GetXY(worldPostiion, out x, out y);
        SetValue(x, y, value);

    }


    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
          
            return gridArray[x, y];
           
        }
        else
        {
            return 0;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    public void AddValue(int x, int y, int value)
    {
        SetValue(x, y, GetValue(x,y)+value);
    }

    //Builds the square aroud each tile
    public void AddValue(Vector3Int SquarePosition, int range, int value)
    {
        for (int x = 0; x < range; x++)
        {
            for (int y = 0; y < range; y++)
            {

                AddValue(monkTest.TileGridSync(SquarePosition).x + x, monkTest.TileGridSync(SquarePosition).y + y, value);

                if (x != 0)
                {
                    AddValue(monkTest.TileGridSync(SquarePosition).x - x, monkTest.TileGridSync(SquarePosition).y + y, value);
                }
                if (y != 0)
                {
                    AddValue(monkTest.TileGridSync(SquarePosition).x + x, monkTest.TileGridSync(SquarePosition).y - y, value);
                    if (x != 0)
                    {
                        AddValue(monkTest.TileGridSync(SquarePosition).x - x, monkTest.TileGridSync(SquarePosition).y - y, value);
                    }
                }
            }
        }
    }

}