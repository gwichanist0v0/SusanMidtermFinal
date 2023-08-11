using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerBehavior : MonoBehaviour
{

    public float _speed = 1f;
    [SerializeField] KeyCode _downKey;
    [SerializeField] KeyCode _upKey;
    [SerializeField] KeyCode _leftKey;
    [SerializeField] KeyCode _rightKey;
    [SerializeField] WeaponBehavior weaponBehavior;
    [SerializeField] float buffUp;
    [SerializeField] GameObject FireObj;
    [SerializeField] GameObject SpeedObj;
    bool isSpeedUp;
    CsoundUnity csoundUnity;
    MusicManager clipPlay;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameBehaviors gameBehave;

    // Start is called before the first frame update
    void Start()
    {
        isSpeedUp = false;
        GameObject csoundy = GameObject.Find("Csound");
        csoundUnity = csoundy.GetComponent<CsoundUnity>();
        GameObject musicManager = GameObject.Find("MusicManager");
        clipPlay = musicManager.GetComponent<MusicManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GameBehaviors.Instance.State == GameState.Play)
        { 
            if (Input.GetKey(_upKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                transform.position += new Vector3(0, _speed, 0) * Time.deltaTime;

            }


            if (Input.GetKey(_downKey))
            {

                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                transform.position -= new Vector3(0, _speed, 0) * Time.deltaTime;

            }

            if (Input.GetKey(_rightKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position += new Vector3(_speed, 0, 0) * Time.deltaTime;

            }

            if (Input.GetKey(_leftKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -180f);
                transform.position -= new Vector3(_speed, 0, 0) * Time.deltaTime;
            }

            if (Input.GetKey(_leftKey) && Input.GetKey(_upKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 135f);
            }

            if (Input.GetKey(_leftKey) && Input.GetKey(_downKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -135f);
            }

            if (Input.GetKey(_rightKey) && Input.GetKey(_upKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 45);
            }

            if (Input.GetKey(_rightKey) && Input.GetKey(_downKey))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -45);
            }
        }

        

    }

    

    //public IEnumerator SpeedUp()
    //{
    //    _speed *= 2;

    //    Debug.Log(_speed);

    //    yield return new WaitForSeconds(5f);

    //    _speed /= 2;

    //    Debug.Log(_speed);
    //}

    public void SpeedUP()
    {
        if (!isSpeedUp)
        {
            SpeedObj.SetActive(true);
            _speed *= 2;
            isSpeedUp = true;
            clipPlay.PlayClip(2);  
            Invoke(nameof(SpeedDown), buffUp);
        }
    }

    private void SpeedDown()
    {
        SpeedObj.SetActive(false);
        _speed /= 2;
        isSpeedUp = false;
        clipPlay.PlayClip(0); 
        Debug.Log(_speed);

    }

    public void AttakGo()
    {
        FireObj.SetActive(true);
        weaponBehavior.enabled = true;
        clipPlay.PlayClip(1); 
        Invoke(nameof(AttackNo), buffUp);
    }

    private void AttackNo()
    {
        FireObj.SetActive(false);
        clipPlay.PlayClip(0);
        weaponBehavior.enabled = false; 
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            //this.gameObject.SetActive(false);

            spriteRenderer.enabled = false;
            gameBehave.GameOverla(); 

        }


    }




}

