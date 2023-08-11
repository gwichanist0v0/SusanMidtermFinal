using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps; 

public class BuffGenerators : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] MonkTest monkTest;
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject speedPrefab;
    [SerializeField] int MaxSpeed;
    [SerializeField] float speedSec;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] int MaxAttack;
    [SerializeField] float attackSec;
    private BoundsInt bounds;
    private int countSpeed;
    private int countAttack; 


    // Start is called before the first frame update
    void Start()
    {
        bounds = tilemap.cellBounds;

        if (GameBehaviors.Instance.State == GameState.Play)
        {
            StartCoroutine(GenerateSpeedUp());
            StartCoroutine(GenerateAttackUp()); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        countSpeed = GameObject.FindGameObjectsWithTag("SpeedUp").Length;
        countAttack = GameObject.FindGameObjectsWithTag("AttackUp").Length;
    }

    IEnumerator GenerateSpeedUp()
    {
        while (true)
        {
            if (countSpeed < MaxSpeed)
            {
                int speedBuffToGen = MaxSpeed - countSpeed;

                for (int i = 0; i < speedBuffToGen; i++)
                {
                    int RandX = Random.Range(bounds.min.x, bounds.max.x + 1);
                    int RandY = Random.Range(bounds.min.y, bounds.max.y + 1);

                    Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
                    int val = grid.GetValue(randGrid.x, randGrid.y);

                    if (val < 80 && val != 1)
                    {
                        Vector3Int randomSpeed = new Vector3Int(RandX, RandY, bounds.min.z);
                        Instantiate(speedPrefab, randomSpeed, Quaternion.identity);
                    }

                }

            }

            yield return new WaitForSeconds(speedSec);
        }

    }

    IEnumerator GenerateAttackUp()
    {
        while (true)
        {
            if (countAttack < MaxAttack)
            {
                int attackBuffToGen = MaxAttack - countAttack;

                for (int i = 0; i < attackBuffToGen; i++)
                {
                    int RandX = Random.Range(bounds.min.x, bounds.max.x + 1);
                    int RandY = Random.Range(bounds.min.y, bounds.max.y + 1);

                    Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
                    int val = grid.GetValue(randGrid.x, randGrid.y);

                    if (val < 80 && val != 1)
                    {
                        Vector3Int randomAttack = new Vector3Int(RandX, RandY, bounds.min.z);
                        Instantiate(attackPrefab, randomAttack, Quaternion.identity);
                    }

                    //if (val < 50)
                    //{
                    //    Vector3Int randomAttack = new Vector3Int(RandX, RandY, bounds.min.z);
                    //    Instantiate(attackPrefab, randomAttack, Quaternion.identity);
                    //    //monkTest.DestroyAttack(randomAttack);
                    //}
                }

            }

            yield return new WaitForSeconds(attackSec);
        }

    }
}
