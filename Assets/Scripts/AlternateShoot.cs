using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AlternateShoot : MonoBehaviour
{
    public Transform shootingPoint;
    public Transform shootingPoint2;
    public GameObject bulletPrefab;
    public float pressedSpace;
    public AudioSource shotgunShootSFX;
    //private bool shootDisabled = false;
    //private Coroutine buttonDisabled = null;
    public float fireRate = 1f;
    public float nextShot;
    public float range = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        pressedSpace = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        bool input = Input.GetKeyDown("space");
        ///bool input2 = Mouse.current.rightButton.wasPressedThisFrame;     

        //if(buttonDisabled == null)
        //{
        //    buttonDisabled = StartCoroutine("ShootCooldown");
        //}

        if(Input.GetKeyDown(KeyCode.X) && Time.timeScale > 0 && Time.time > nextShot)
        {
            shotgunShootSFX.Play();

            Quaternion b1rotation = transform.rotation * Quaternion.Euler(0, 0, 45);
            Quaternion b2rotation = transform.rotation * Quaternion.Euler(0, 0, 0);
            Quaternion b3rotation = transform.rotation * Quaternion.Euler(0, 0, -45);

            AlternateBullet b1 = Instantiate(bulletPrefab, shootingPoint.position, b1rotation).GetComponent<AlternateBullet>();
            AlternateBullet b2 = Instantiate(bulletPrefab, shootingPoint.position, b2rotation).GetComponent<AlternateBullet>();
            AlternateBullet b3 = Instantiate(bulletPrefab, shootingPoint.position, b3rotation).GetComponent<AlternateBullet>();
            b1.range = range;
            b2.range = range;
            b3.range = range;
            //buttonDisabled = StartCoroutine("ShootCooldown");
            nextShot = Time.time + fireRate;
        }

        if (input) 
        {
            pressedSpace = 2f;
        }
        if (pressedSpace > 0) pressedSpace -= 0.1f;
    }

    //IEnumerator ShootCooldown()
    //{
    //    yield return new WaitForSeconds(1.2f);
    //    shootDisabled = false;
    //    buttonDisabled = null;
    //}
}
