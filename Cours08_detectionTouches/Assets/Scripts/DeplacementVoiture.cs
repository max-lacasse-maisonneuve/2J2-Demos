using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementVoiture : MonoBehaviour
{
    public InputAction onDeplacement;
    public InputAction onRotation;

    public float vitesseDeplacement = 7.5f;
    public float vitesseRotation = 150;

    void OnEnable()
    {
        onDeplacement.Enable();
        onRotation.Enable();
    }

    void OnDisable()
    {
        onDeplacement.Disable();
        onRotation.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float directionRotation = 0;
        float directionDeplacement = 0;

        directionDeplacement = onDeplacement.ReadValue<float>();
        directionRotation = onRotation.ReadValue<float>();
        transform.Rotate(0, 0, directionRotation * vitesseRotation * Time.deltaTime);
        transform.Translate(Vector2.up * directionDeplacement * vitesseDeplacement * Time.deltaTime);
    }
}
