using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LancementBalle : MonoBehaviour
{
    public float vitesseMin, vitesseMax, acceleration;
    public Image barreFront;
    public GameObject uiBarre;

    private float vitesse;
    private Rigidbody2D rb;

    void Start()
    {
        vitesse = 0;
        uiBarre.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Modifier la condition pour le bloc se déclenche lorsque la barre d'espacement ou le bouton gauche de la souris
        // sont enfoncés pour la première fois
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            uiBarre.SetActive(true);
            barreFront.fillAmount = 0;
            vitesse = vitesseMin;
        }

        // Modifier la condition pour le bloc se déclenche lorsque la barre d'espacement ou le bouton gauche de la souris
        // sont toujours enfoncés depuis le dernier frame
        if (Keyboard.current.spaceKey.isPressed || Mouse.current.leftButton.isPressed)
        {
            vitesse += acceleration * Time.deltaTime;
            barreFront.fillAmount = (vitesse - vitesseMin) / (vitesseMax - vitesseMin);
        }

        // Modifier la condition pour le bloc se déclenche lorsque la barre d'espacement ou le bouton gauche de la souris
        // sont relâchés
        if (Keyboard.current.spaceKey.wasReleasedThisFrame || Mouse.current.leftButton.wasReleasedThisFrame)
        {
            vitesse = Mathf.Clamp(vitesse, vitesseMin, vitesseMax);
            rb.linearVelocityY = vitesse;
            vitesse = 0;
            uiBarre.SetActive(false);
        }
    }
}
