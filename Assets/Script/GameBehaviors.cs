using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Reflection;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Tilemaps;

public class GameBehaviors : MonoBehaviour
{
    public static GameBehaviors Instance;
    public GameState State;
    [SerializeField] TextMeshProUGUI _messagesGUI;
    [SerializeField] TextMeshProUGUI scoreGUI;
    [SerializeField] TextMeshProUGUI endGameGUI;
    [SerializeField] TextMeshProUGUI pauseGUI;
    [SerializeField] GameObject PopUpObj;
    [SerializeField] MusicManager clipPlay;
    [SerializeField] SceneChange sceneChange;
    [SerializeField] GameObject[] enemyArray;
    [SerializeField] Grid grid;
    [SerializeField] MonkTest monkTest;
    [SerializeField] Tilemap tilemap;
    private BoundsInt bounds;




    private void Awake()
    {
        // Singleton Pattern
        if (Instance != this && Instance != null)
            Destroy(this);
        else
            Instance = this;

    }

    void Start()
    {
        // Find all objects with the "Enemy" tag
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Enemy");

        // Access and modify components on the clones
        foreach (GameObject clone in clones)
        {
            NavMeshAgent navMeshAgent = clone.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = true; // Enable the NavMeshAgent component
            }
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) && State != GameState.GameOver)
        {
            if (State == GameState.Play)
            {
                // Switch to play game state
                Time.timeScale = 0f;
                PopUpObj.SetActive(true);
                State = GameState.Pause;
                _messagesGUI.enabled = true;
                pauseGUI.enabled = true;
            }
            else
            {
                // Switch to pause game state
                Time.timeScale = 1f;
                State = GameState.Play;
                _messagesGUI.enabled = false;
                PopUpObj.SetActive(false);
                pauseGUI.enabled = false;
            }
        }

        //if (GameObject.FindWithTag("Player") == null)
        //{
        //    GameOverla();
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
            Debug.Log("sTATES" + State);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            sceneChange.changeScene();
        }

        //foreach (GameObject gameObject in enemyArray)
        //{
        //    if (!gameObject.activeSelf)
        //    {
        //        StartCoroutine(EnemySpwan()); 
        //    }
        //}
    }

    private int score;
    public int Score
    {
        get => score;

        set
        {
            score = value;
            scoreGUI.text = Score.ToString();
        }
    }

    //IEnumerator EnemySpwan()
    //{

    //    bounds = tilemap.cellBounds;

    //    gameObject.SetActive(true);

    //    while (true)
    //    {

    //        int RandX = UnityEngine.Random.Range(bounds.min.x, bounds.max.x + 1);
    //        int RandY = UnityEngine.Random.Range(bounds.min.y, bounds.max.y + 1);
    //        Vector3Int randGrid = monkTest.TileGridSync(new Vector3Int(RandX, RandY, 0));
    //        int val = grid.GetValue(randGrid.x, randGrid.y);

    //        if (val < 50)
    //        {
    //            Vector3Int randomEnemy = new Vector3Int(RandX, RandY, bounds.min.z);
    //            transform.position = randomEnemy;
    //            break;
    //        }

    //        yield return new WaitForSeconds(1.0f);


    //    }



    //}

    public void GameOverla()
    {


        endGameGUI.text = $"Your Score is {score}! \n\nPress space bar to restart.";
        endGameGUI.enabled = true;
        scoreGUI.enabled = false;
        PopUpObj.SetActive(true);
        Time.timeScale = 0f;
        State = GameState.GameOver;
   

    }

    private void Reset()
    {

        State = GameState.Play;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1, LoadSceneMode.Single);        

    }


}
