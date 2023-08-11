using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BulletBehavior : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rigid;
   

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.right * speed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false); // Disables the collided game object
            Destroy(this.gameObject);
            UpdateScore();

        }
        else if (collision.GetComponent<TilemapCollider2D>() != null || collision.GetComponent<Tilemap>() != null)
        {
            Destroy(this.gameObject);
        }


    }

    private void UpdateScore()
    {
        GameBehaviors.Instance.Score += 5;
    }

}
