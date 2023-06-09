using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualWeapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform FirePoint;
    public GameObject BulletPrefab;
    public float timer;
    public float cooldown; 
     

    void Start()
    {
        timer = 0f;
        cooldown = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {

        // Cooldown 
        Clock();

        // Boundary 
        if (transform.position.y > 3.82f)
        {
            transform.position = new Vector3(transform.position.x, 3.82f, -10);
        }
        if (transform.position.y < -3.82f)
        {
            transform.position = new Vector3(transform.position.x, -3.82f, -10);
        }


        // Fire Bullet
        if (Input.GetButton("Fire1") && timer >= cooldown)
        {
            Shoot();
            timer = 0f;
        }
    }


    // Bullet Function 
    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }

    void Clock()
    {
        timer += 1 * Time.deltaTime; 
    }
}
