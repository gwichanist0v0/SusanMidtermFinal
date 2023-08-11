using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGenerator : MonoBehaviour
{

    [SerializeField] Grid grid;
    [SerializeField] MonkTest monkTest;
    [SerializeField] Tilemap tilemap;
    private BoundsInt bounds;

    public bool playerSet;

    // Start is called before the first frame update
    void Start()
    {
        playerSet = false;
        bounds = tilemap.cellBounds;

        while (true)
        {
           
            int RandX = Random.Range(bounds.min.x, bounds.max.x + 1);
            int RandY = Random.Range(bounds.min.y, bounds.max.y + 1);
            Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
            int val = grid.GetValue(randGrid.x, randGrid.y);

            if (val == 0)
            {
                Vector3Int randomPlayer = new Vector3Int(RandX, RandY, bounds.min.z);
                transform.position = randomPlayer;
                playerSet = true;
                Debug.Log("PLAYER"+randomPlayer);
                break;  
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
