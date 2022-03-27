using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameON, GameOFF, balloons, spawn;
    public Text scoreText, levelText;
    public static float score, level;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            Quit();
        }
        scoreText.text = score.ToString();
        levelText.text = level.ToString();
    }

    public void Play()
    {
        // StartCoroutine(SpawnScript.StartSpawning());
        StartCoroutine(spawn.GetComponent<SpawnScript>().StartSpawning());
        GameON.SetActive(true);
        GameOFF.SetActive(false);
        score = 0;
        level = 1;
        scoreText.text = "0";
        levelText.text = "1";
    }

    public void Quit()
    {
        // Destroy(balloons);
        foreach (Transform child in balloons.transform)
        {
            child.gameObject.GetComponent<BalloonScript>().Burst();
        }
        GameON.SetActive(false);
        GameOFF.SetActive(true);
    }
}
