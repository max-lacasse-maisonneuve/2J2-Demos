using UnityEngine;

public class Clic_survol : MonoBehaviour
{
    public Sprite imageNormale;
    public Sprite imageSurvol;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = imageNormale;
    }

    public void AuClic()
    {
        gameObject.SetActive(false);
    }

    public void AuDebutSurvol()
    {
        spriteRenderer.sprite = imageSurvol;
    }

    public void AuFinSurvol()
    {
        spriteRenderer.sprite = imageNormale;
    }
}
