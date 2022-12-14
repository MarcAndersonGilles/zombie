using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject zombie;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawner());
    }

    IEnumerator ZombieSpawner()
    {
        if(GameObject.FindWithTag("timer").GetComponent<TimerScript>().TimeLeft > 10)
        {
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPoint.Length-1));
            yield return new WaitForSeconds(7f);
            Instantiate(zombie, spawnPoint[randomNumber].transform.position, transform.rotation);
            StartCoroutine(ZombieSpawner());
        }
    }
}
