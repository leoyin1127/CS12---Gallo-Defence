using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public float spawnrate = 1f;
    private float timer = 0;
    public float CountDown = 45f;
    public static bool spawn = true;
    public float HeightOffSet = 3.78f;
    private WaveIndex wavespawn;

    void Awake()
    {
        wavespawn = FindObjectOfType<WaveIndex>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += 1f * Time.deltaTime;
        CountDown -= 1f * Time.deltaTime; 
        Spawn();
        EndWave();
    }

    void Spawn()
    {
        if (timer >= spawnrate && spawn == true)
        {
            float lowestpoint = transform.position.y - HeightOffSet;
            float highestpoint = transform.position.y + HeightOffSet;

            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
            timer = 0; 
        }
    }
    void EndWave()
    {
        if (CountDown <= 0f)
        {
            spawn = false;
            CountDown = 45f;
            spawnrate *= 0.95f;
            //Debug.Log(spawnrate);
        }

    }

}


//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject Enemy;
//    public float spawnrate = 1f;
//    private float timer = 0;
//    public float CountDown = 91f;
//    public static bool spawn = true;
//    public float HeightOffSet = 3.78f;


//    // Start is called before the first frame update
//    void Start()
//    {
//        Spawn();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        timer += 1f * Time.deltaTime;
//        CountDown -= 1f * Time.deltaTime;
//        Spawn();
//        EndWave();
//    }

//    void Spawn()
//    {
//        if (timer >= spawnrate && spawn == true)
//        {
//            float lowestpoint = transform.position.y - HeightOffSet;
//            float highestpoint = transform.position.y + HeightOffSet;

//            Instantiate(Enemy, new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), -3), transform.rotation);
//            timer = 0;
//        }
//    }
//    void EndWave()
//    {
//        if (CountDown <= 0f)
//        {
//            spawn = false;
//        }
//    }
//}

