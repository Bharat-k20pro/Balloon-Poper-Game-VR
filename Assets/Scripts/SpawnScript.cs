using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] balloons;
    public Transform parent;
    float time = 4;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(StartSpawning());
    }

    void Update()
    {

    }

    public IEnumerator StartSpawning()
    {
        if (PlayerManager.level == 1) time = 4;
        else if (PlayerManager.level == 2) time = 2;
        else if (PlayerManager.level == 3) time = 1.2f;
        yield return new WaitForSeconds(time);

        for (int i = 0; i < 5; i++)
        {
            var ballloonInstance = Instantiate(balloons[i], spawnPoints[i].position, Quaternion.identity);
            ballloonInstance.transform.SetParent(parent);
        }

        StartCoroutine(StartSpawning());
    }
}
