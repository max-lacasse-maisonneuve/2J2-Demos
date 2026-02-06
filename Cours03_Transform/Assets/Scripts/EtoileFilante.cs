using UnityEngine;

public class EtoileFilante : MonoBehaviour
{
    public float vitesseX = 0.01f;
    public float vitesseY = 0.01f;
    public float tauxReduction = 0.01f;
    public bool peutBouger = true;


    // Update is called once per frame
    void Update()
    {
        if (peutBouger == true)
        {
            transform.Translate(vitesseX, vitesseY, 0);

            float nouvelleTaille = transform.localScale.x - tauxReduction;
            if (nouvelleTaille <= 0)
            {
                peutBouger = false;
            }
            transform.localScale = new Vector3(nouvelleTaille, nouvelleTaille, nouvelleTaille);
        }

    }
}
