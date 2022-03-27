using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RayManager : MonoBehaviour
{
    public TMP_Text textObject;
    public GameObject smoke;
    public Text scoreText;
    int score;
    GameObject sphere;

    void Start()
    {
        //Create Sphere
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        sphere.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        CheckForHit();
    }

    void CheckForHit()
    {
        //Declaring variable
        RaycastHit objectHit;
        Vector3 fwd = transform.forward;

        if (Physics.Raycast(transform.position, fwd, out objectHit, 150))
        {
            //Debug ray and object in console
            Debug.Log(objectHit.transform.gameObject.name);
            Debug.DrawRay(transform.position, fwd * 50, Color.green);

            //Update UI text
            textObject.text = objectHit.transform.gameObject.name.ToString();
        }

        //Draw a line renderer
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + fwd * 150);

        //Update sphere position on hit point
        sphere.transform.position = objectHit.point;

        // if (objectHit.transform.name == "Red(Clone)" || objectHit.transform.name == "Yellow(Clone)" || objectHit.transform.name == "Green(Clone)" || objectHit.transform.name == "Blue(Clone)" || objectHit.transform.name == "White(Clone)")
        // {
        //     Destroy(objectHit.transform.gameObject);
        //     Instantiate(smoke, objectHit.point, Quaternion.LookRotation(objectHit.normal));
        //     score += 1;
        //     scoreText.text = score.ToString();
        // }
    }

}
