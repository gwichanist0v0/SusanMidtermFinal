using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using CodeMonkey.Utils;
public class CoinBehavior : MonoBehaviour
{
    private MonkTest monkTest;
    CsoundUnity csoundUnity;
    private float[] pitch;
    private int randPitch; 

    private void Start()
    {
        pitch = new float[] { 523.25f, 587.33f, 659.25f, 783.99f, 880.00f };

        GameObject csound = GameObject.Find("Csound");
 
        csoundUnity = csound.GetComponent<CsoundUnity>();
   

        GameObject monkTesty = GameObject.Find("MokneyTest");

        //if (monkTesty != null)
        //{
        //    Debug.Log("FOUND MONK"); 
        //}

        monkTest = monkTesty.GetComponent<MonkTest>();

        //if (monkTest != null)
        //{
        //    Debug.Log("MonkTest script found!");
        //}

        transform.position += new Vector3(0.5f, 0.5f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {


        randPitch = UnityEngine.Random.Range(0, pitch.Length);
        float coinFreq = pitch[randPitch]; 
 
            // Check if the colliding object is a coin
        if (collider.CompareTag("Player"))
        {

            csoundUnity.SetChannel("coinFreq", coinFreq); 
            
            csoundUnity.SendScoreEvent("i\"coin\"0 .5");

            Vector3 coinPosition = transform.position;

            Vector3Int coinPositionInt = new Vector3Int(
                ((int)coinPosition.x > 0 ? (int)coinPosition.x : (int)coinPosition.x - 1), ((int)coinPosition.y > 0 ? (int)coinPosition.y : (int)coinPosition.y - 1), 0);
                //Vector3Int coinPositionInt = new Vector3Int((int)coinPosition.x, (int)coinPosition.y, 0);
            //Debug.Log(coinPositionInt);


            monkTest.ReceiveValue(coinPositionInt, 0); 
            Destroy(gameObject);

            UpdateScore();



        }
        
    }

    private void UpdateScore()
    {
        GameBehaviors.Instance.Score += 1;
    }



}
