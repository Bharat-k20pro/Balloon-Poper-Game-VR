using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserColorController : MonoBehaviour
{
    public GameObject bow;
    public Material[] colors;
    public static Material toApply;
    float time = 6;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        toApply = colors[2];
    }

    IEnumerator StartSpawning()
    {
        if (PlayerManager.level == 1) time = 6;
        else if (PlayerManager.level == 2) time = 4;
        else if (PlayerManager.level == 3) time = 3;
        yield return new WaitForSeconds(time);

        toApply = colors[Random.Range(0, colors.Length)];
        bow.GetComponent<Renderer>().material = toApply;

        StartCoroutine(StartSpawning());
    }
}
