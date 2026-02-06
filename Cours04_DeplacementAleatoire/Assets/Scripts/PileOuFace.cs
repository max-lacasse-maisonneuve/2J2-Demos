using UnityEngine;

public class PileOuFace : MonoBehaviour
{
    public Sprite imagePile;
    public Sprite imageFace;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int nbAleatoire = Random.Range(0, 2);

        if (nbAleatoire == 0)
        {
            spriteRenderer.sprite = imagePile;
        }
        else if (nbAleatoire == 1)
        {
            spriteRenderer.sprite = imageFace;
        }
        else
        {
            Debug.Log("Oups, valeur incorrecte");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
