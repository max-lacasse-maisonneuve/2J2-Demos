using UnityEngine;
using UnityEngine.UIElements;

public class PlaneteOrbite : MonoBehaviour
{
    public float vitesseRotation = 0.01f;
    public GameObject planeteCible;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(planeteCible.transform.position, Vector3.forward, vitesseRotation);
    }
}
