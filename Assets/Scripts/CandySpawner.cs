using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    public GameObject[] Candies;

    [SerializeField]
    float SpawnInterval;

    public static CandySpawner instance;

    public bool GameOver { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // SpawnCandy();

        StartCoroutine("SpawnCandies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCandy()
    {
        //this what gives you a random number to spawn from
        int rand = Random.Range(0, Candies.Length);

        //this randomizes the postion using the maxX
        float randX = Random.Range(-maxX, maxX);

        //this creates a new vector3 using that random postion
        Vector3 randomPos = new Vector3(randX, transform.position.y, transform.position.z);

        //this is what acutally spawns them in place of the spawn object
        Instantiate(Candies[rand], randomPos, transform.rotation);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {
            SpawnCandy();

            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    public void startSpawingCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
