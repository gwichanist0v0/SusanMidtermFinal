using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] MonkTest monkTest;
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int MaxEnemy;
    [SerializeField] float sec;
    [SerializeField] float enemyGenDis;
    private BoundsInt bounds;
    private int count;
    private Transform PlayerTrans;
    private BoxCollider2D EnemyCol;

    private Vector3 playerPosition;

    [SerializeField] private PlayerGenerator pg;

    private void Start()
    {
        bounds = tilemap.cellBounds;
        Invoke("StartGen", 1.0f); 
        //Debug.Log("bounds: " + bounds.size);
        PlayerTrans = GameObject.Find("Player").transform;
        if (PlayerTrans != null)
        {
            //playerPosition = PlayerTrans.position;
            Debug.Log("FOUND PLAYER WUHU " + PlayerTrans.position);
        }

    }

    private void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (PlayerTrans != null)
        {
            playerPosition = PlayerTrans.position;
            //Debug.Log("PLAYER POSITION WUHU " + playerPosition);
        }
    }

    public void StartGen()
    {
        StartCoroutine(GenerateEnemy());
    }


    IEnumerator GenerateEnemy()
    {
        while (true)
        {
            if (count < MaxEnemy & pg.playerSet)
            {
                int enemiesToGenerate = MaxEnemy - count;

                for (int i = 0; i < enemiesToGenerate; i++)
                {
                    int RandX = Random.Range(bounds.min.x, bounds.max.x + 1);
                    int RandY = Random.Range(bounds.min.y, bounds.max.y + 1);

                    Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
                    int val = grid.GetValue(randGrid.x, randGrid.y);
                    Vector3 randomPosition = new Vector3(RandX, RandY, 0f);
                  
                    Debug.Log("Player" + playerPosition);
                    Debug.Log("rand" + randomPosition);

                    float dis = Vector3.Distance(randomPosition, playerPosition);
                    Debug.Log("dis" + dis);
                   
                    if (val < 50 && enemyGenDis < dis)
                    {
                         
                        Vector3Int randomEnemy = new Vector3Int(RandX, RandY, bounds.min.z);
                        Instantiate(enemyPrefab, randomEnemy, Quaternion.identity);
                        
                        //Debug.Log("NEW" + randomCoin);
                    }
                }
            }

            yield return new WaitForSeconds(sec);
        }
    }
}
