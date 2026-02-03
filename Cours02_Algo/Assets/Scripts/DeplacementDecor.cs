using UnityEngine;

public class DeplacementDecor : MonoBehaviour
{
    public float vitesseX = 0.01f;
    public float limiteXMax = 10f;
    public float limiteXMin = -10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deplacementX = transform.position.x + vitesseX;
        float deplacementY = transform.position.y;

        if (deplacementX < limiteXMax)
        {
            deplacementX = limiteXMin;
        }

        transform.position = new Vector2(deplacementX, deplacementY);
    }
}
