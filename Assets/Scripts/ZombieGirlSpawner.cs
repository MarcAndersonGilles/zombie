using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGirlSpawner : MonoBehaviour
{
    public Transform zombie;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawner2());
    }

    IEnumerator ZombieSpawner2()
    {
            yield return new WaitForSeconds(5f);
            Instantiate(zombie, transform.position, transform.rotation);
            StartCoroutine(ZombieSpawner2());
    }
}
