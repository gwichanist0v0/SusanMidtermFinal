using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerate : MonoBehaviour
{
    [SerializeField] GameObject WallPreFab;
    [SerializeField] int MaxSquare;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    //Not in use
    // List to store the instantiated squares
    private List<GameObject> instantiatedSquares = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateSquare();
    }

    void GenerateSquare()
    {
        for (int i = 0; i < MaxSquare; i++)
        {
            float yRand = Random.Range(minY, maxY);
            float xRand = Random.Range(minX, maxX);
            Vector3 position = new Vector3(xRand, yRand, 0f);

            // Check for overlapping colliders
            bool overlapping = CheckForOverlap(position);
            if (overlapping)
            {
                // Skip this iteration if there is an overlap
                continue;
            }

            GameObject Wall = Instantiate(WallPreFab, position, Quaternion.identity);
            instantiatedSquares.Add(Wall);

            Debug.Log(i);
        }
    }

    bool CheckForOverlap(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, WallPreFab.GetComponent<BoxCollider2D>().size, 0f);
        return colliders.Length > 0;
    }
}
