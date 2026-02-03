// using System;
using UnityEngine;
using UnityEngine.InputSystem; // Cette ligne permet de détecter les touches du clavier

public class DeplacementJoueur : MonoBehaviour
{
    [Header("Déplacement du joueur")]
    public float vitesse = 5;
    public float vitesseRotation = 180;

    // Update is called once per frame
    void Update()
    {
        // Variables temporaires pour gérer le déplacement et la rotation du joueur
        float deplacement = 0;
        float rotation = 0;

        // Gestion des touches pour la rotation du joueur
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            rotation = vitesseRotation * Time.deltaTime;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            rotation = vitesseRotation * Time.deltaTime * -1;
        }

        // Gestion des touches pour le déplacement du joueur
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            deplacement = vitesse * Time.deltaTime;
        }
        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            deplacement = vitesse * Time.deltaTime * -1; //Permet d'aller par en arrière en multipliant par -1
        }

        //On applique la rotation et le déplacement
        transform.Rotate(0, 0, rotation);
        transform.Translate(deplacement * Vector2.up); //Vector2.up correspond à la flèche verte du joueur
    }
}
