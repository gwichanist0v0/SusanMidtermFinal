using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] MonkTest monkTest;
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] int MaxCoin;
    [SerializeField] float sec;
    private BoundsInt bounds;
    private int count;

    private void Start()
    {
        bounds = tilemap.cellBounds;

        if (GameBehaviors.Instance.State == GameState.Play)
        {
            StartCoroutine(GenerateCoins());
        }

        //Debug.Log("bounds: " + bounds.size);
    }

    private void Update()
    {
        count = GameObject.FindGameObjectsWithTag("Coin").Length;
        //Debug.Log(count);
    }

    IEnumerator GenerateCoins()
    {
        while (true)
        {
            if (count < MaxCoin)
            {
                int coinsToGenerate = MaxCoin - count;

                for (int i = 0; i < coinsToGenerate; i++)
                {
                    int RandX = Random.Range(bounds.min.x, bounds.max.x +1);
                    int RandY = Random.Range(bounds.min.y, bounds.max.y +1 );
                    Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
                    int val = grid.GetValue(randGrid.x, randGrid.y);

                    if (val < 50)
                    {
                        Vector3Int randomCoin = new Vector3Int(RandX, RandY, bounds.min.z);
                        Instantiate(coinPrefab, randomCoin, Quaternion.identity);
                        monkTest.ReceiveValue(randomCoin, 1); 
                        //monkTest.ReceiveCoin(randomCoin);
                        //Debug.Log("NEW" + randomCoin);
                    }
                }
            }

            yield return new WaitForSeconds(sec);
        }
    }
}
