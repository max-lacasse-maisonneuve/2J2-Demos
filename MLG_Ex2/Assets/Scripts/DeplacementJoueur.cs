using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementJoueur : MonoBehaviour
{
    public float vitesseY;
    public float vitesseX;

    // Update is called once per frame
    void Update()
    {
        float deplacementX = 0;
        if (Keyboard.current.aKey.isPressed)
        {
            deplacementX = -vitesseX;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            deplacementX = vitesseX;
        }
        transform.Translate(deplacementX, vitesseY * Time.deltaTime, 0);
    }
}
