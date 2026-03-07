using UnityEngine;
using UnityEngine.InputSystem;

public class DeplacementPerso : MonoBehaviour
{
    public InputAction onDeplacement;
    public InputAction onSaut;
    public float vitesse = 5f;
    public float forceSaut = 5f;
    Rigidbody2D rb;
    private void OnEnable()
    {
        onDeplacement.Enable();
        onSaut.Enable();
    }
    private void OnDisable()
    {
        onDeplacement.Disable();
        onSaut.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float deplacementHorizontal = onDeplacement.ReadValue<float>();
        rb.linearVelocity = new Vector2(deplacementHorizontal * vitesse, rb.linearVelocity.y);
    }

    void FixedUpdate()
    {
        if (onSaut.WasPressedThisFrame())
        {
            rb.AddForce(new Vector2(0, forceSaut), ForceMode2D.Impulse);
        }
    }
}
