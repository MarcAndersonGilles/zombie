using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform zombie;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawner());
    }

    IEnumerator ZombieSpawner()
    {
            yield return new WaitForSeconds(5f);
            Instantiate(zombie, transform.position, transform.rotation);
            StartCoroutine(ZombieSpawner());
    }
}
