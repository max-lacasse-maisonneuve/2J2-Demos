using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class DeplacementJoueur : MonoBehaviour
{
    public float vitesseDeplacement = 10;
    public float forceSaut = 50;

    public InputAction onDeplacementHorizontal;
    public InputAction onDeplacementVertical;

    public Transform solCheck;
    public float rayonSol = 0.2f;
    public LayerMask layerSol;

    float deplacementHorizontal;
    bool demandeSaut;
    public bool estAuSol;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator animator;
    void OnEnable()
    {
        onDeplacementHorizontal.Enable();
        onDeplacementVertical.Enable();
    }

    void OnDisable()
    {
        onDeplacementHorizontal.Disable();
        onDeplacementVertical.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        estAuSol = Physics2D.OverlapCircle(solCheck.position, rayonSol, layerSol);
        deplacementHorizontal = onDeplacementHorizontal.ReadValue<float>();

        if (deplacementHorizontal < 0)
        {
            spriteRenderer.flipX = true;

        }
        else if (deplacementHorizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("deplacement", Mathf.Abs(rigid.linearVelocityX));

        if (estAuSol && onDeplacementVertical.WasPressedThisFrame())
        {
            demandeSaut = true;
            animator.SetTrigger("saut");
        }
    }

    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(deplacementHorizontal * vitesseDeplacement, rigid.linearVelocity.y);

        if (demandeSaut && estAuSol)
        {
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.x, forceSaut);
            demandeSaut = false;
        }
    }
}
