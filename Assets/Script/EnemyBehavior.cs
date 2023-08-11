using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CodeMonkey.Utils;

public class EnemyBehavior : MonoBehaviour
{

    NavMeshAgent agent;
    public GameObject myPlayer;
    CsoundUnity csoundUnity;
    GameBehaviors gameBehave;
    

    //[SerializeField] SpriteRenderer spriteRenderer;
    //[SerializeField] Collider2D collider;
    //[SerializeField] Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GameObject.Find("Player");
        if (myPlayer != null)
        {
            Debug.Log("Found the player!");
        }
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        GameObject csoundy = GameObject.Find("Csound"); 
        csoundUnity = csoundy.GetComponent<CsoundUnity>();

        GameObject gameBehaviors = GameObject.Find("GameManager");
        gameBehave = gameBehaviors.GetComponent<GameBehaviors>();



    }

    // Update is called once per frame
    void Update()
    {
        //SetTargetPosition(); 
        SetTargetPosition();  
        //Console reference of what's in the game

    }

    void SetTargetPosition()
    {
        //if (myPlayer != null)
       // {
            Vector3 position = myPlayer.transform.position;
            this.agent.SetDestination(position);
       // }
       // else agent.SetDestination(this.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            csoundUnity.SendScoreEvent("i\"enemy\"0 0.5");            
            
        }

        //if (collision.collider.CompareTag("Bullet"))
        //{
        //    Debug.Log("BULLET BULLET");
        //    EnemyOff();
        //}


    }

    //public void EnemyOff()
    //{
    //    spriteRenderer.enabled = false;
    //    GetComponent<Collider>().enabled = false;
    //    GetComponent<Rigidbody>().simulated = false;
    //    Debug.Log("ENEMYOFFFFFFFFFFFF");
    //}


}
