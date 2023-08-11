using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CodeMonkey.Utils;

public class MonkTest : MonoBehaviour
{

    private Grid grid;
    [SerializeField] Tilemap tilemap;
 


    // Start is called before the first frame update
    void Start()
    {
        //grid = new Grid(22, 13, 1f, new Vector3(-11f, -6f));
       
        grid = new Grid((tilemap.cellBounds.max.x - tilemap.cellBounds.min.x ), (tilemap.cellBounds.max.y - tilemap.cellBounds.min.y ), 1f, new Vector3(-10f, -5f));
        //grid = new Grid((tilemap.cellBounds.size.x), (tilemap.cellBounds.size.y), 1f, new Vector3(-11, -6));

        //Debug.Log(tilemap.cellBounds.max.x + " " + tilemap.cellBounds.min.y);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveValue(Vector3Int position, int value)
    {
        grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, value); 
    }

    public void ReceiveADJ(Vector3Int position)
    {
        //Debug.Log("MonkTestADJ: " + position);
        grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 99);
        grid.AddValue(position, 2, 10);
    }

    public void ReceiveRND(Vector3Int position)
    {
        //Debug.Log("MonkTestRND: " + position);
        grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 77);
        grid.AddValue(position, 2, 10);


    }

    //public void ReceiveCoin(Vector3Int position)
    //{
    //    grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 1);
    //}

    //public void DestroyCoin(Vector3Int position)
    //{
    //    grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 11);

    //}

    //public void ReceiveSpeed(Vector3Int position)
    //{
    //    grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 2);

    //}

    //public void DestroySpeed(Vector3Int position)
    //{
    //    grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 22);

    //}

 

    //public void DestroyAttack(Vector3Int position)
    //{
    //    grid.SetValue(TileGridSync(position).x, TileGridSync(position).y, 33);

    //}


    public Vector3Int TileGridSync (Vector3Int tilemapPos)
    {
        //int gridPosX = tilemapPos.x + 11;
        //int gridPosY = tilemapPos.y + 6;

        int gridPosX = tilemapPos.x + Mathf.Abs(tilemap.cellBounds.min.x ) ;
        int gridPosY = tilemapPos.y+ Mathf.Abs(tilemap.cellBounds.min.y + 1) ;

        

        return new Vector3Int(gridPosX, gridPosY, 0);

    
    }

    //public static Vector3Int RoundToInt(Vector3 coinPosition)
    //{
    //    return new Vector3Int(Mathf.RoundToInt(coinPosition.x), Mathf.RoundToInt(coinPosition.y), Mathf.RoundToInt(coinPosition.z));
    //}
}
