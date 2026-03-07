using UnityEngine;

public class ObstacleTourne : MonoBehaviour
{
    public float vitesseRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float coinFlip = Random.Range(1, 3);
        if (coinFlip == 1)
        {
            vitesseRotation = -0.01f;
        } else
        {
            vitesseRotation = 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, vitesseRotation);
    }
}
