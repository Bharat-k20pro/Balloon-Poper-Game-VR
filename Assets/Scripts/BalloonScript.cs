using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BalloonScript : GazePointer
{
    public GameObject smokeEffect;
    float balloonSpeed = 0.2f;
    void Start()
    {
        // bow.SetActive(false);
    }

    void Update()
    {
        if (PlayerManager.level == 1) balloonSpeed = 0.2f;
        else if (PlayerManager.level == 2) balloonSpeed = 0.4f;
        else if (PlayerManager.level == 3) balloonSpeed = 0.55f;
        transform.Translate(Vector3.up * Time.deltaTime * balloonSpeed);
        // cube.SetActive(false);
    }

    // public override void OnPointerEnter(PointerEventData eventData)
    // {
    //     // bow.Play("Bow_AIM");
    // }
    // public void OnPointerEnter(PointerEventData eventData)
    // {
    //     base.OnPointerEnter(eventData);
    //     pointerDown = false;
    // }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Burst();

        // toApplyColor = bowColors[UnityEngine.Random.Range(0, bowColors.Count)];
        // arc_copie.transform.GetChild(0).gameObject.GetComponent<Renderer>().material = toApplyColor;
        // arc_copie.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public void Burst()
    {
        if (gameObject.GetComponent<Renderer>().material.color == LaserColorController.toApply.color)
        {
            PlayerManager.score++;
        }
        else
        {
            PlayerManager.score--;
        }
        if (PlayerManager.score <= 5)
        {
            PlayerManager.level = 1;
        }
        else if (PlayerManager.score > 10)
        {
            PlayerManager.level = 3;
        }
        else if (PlayerManager.score > 5)
        {
            PlayerManager.level = 2;
        }
        Destroy(gameObject);
        Instantiate(smokeEffect, gameObject.transform.position, gameObject.transform.rotation);
        // LaserColorController.bow.GetComponent<Renderer>().material = LaserColorController.colors[0];

        // arc_copie.SetActive(false);

        // if (objectHit.transform.name == "Red(Clone)" || objectHit.transform.name == "Yellow(Clone)" || objectHit.transform.name == "Green(Clone)" || objectHit.transform.name == "Blue(Clone)" || objectHit.transform.name == "White(Clone)")
        // {
        //     Destroy(objectHit.transform.gameObject);
        //     Instantiate(smoke, objectHit.point, Quaternion.LookRotation(objectHit.normal));
        //     score += 1;
        //     scoreText.text = score.ToString();
        // }
    }
}
