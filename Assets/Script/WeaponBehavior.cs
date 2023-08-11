using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    CsoundUnity csoundUnity; 


    // Start is called before the first frame update
    void Start()
    {
        GameObject csound = GameObject.Find("Csound");
        csoundUnity = csound.GetComponent<CsoundUnity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {

            csoundUnity.SendScoreEvent("i\"bullet\"0 .5");
            Shoot();

        }

        //Vector3 mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        //transform.up = direction;
        ////Look at Quaternion look rotation; 

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0f; // Since we are in 2D, set the z-coordinate to 0

        //// Calculate the direction from the object to the mouse position
        //Vector3 direction = mousePos - transform.position;

        //// Calculate the angle in radians between the object's forward direction and the direction to the mouse
        //float angle = Mathf.Atan2(direction.y, direction.x);

        //// Convert the angle to degrees and rotate the object to face the mouse
        //float degrees = angle * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, degrees));
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }


    

}
