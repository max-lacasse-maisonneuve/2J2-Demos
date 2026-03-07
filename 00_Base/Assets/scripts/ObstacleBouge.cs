using UnityEngine;

public class ObstacleBouge : MonoBehaviour
{
    public float vitesse;
    public float tauxScale = 0.015f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float posY;
        float posXRando = Random.Range(-6, 6);
        float coinFlipY = Random.Range(1, 3);
        float coinFlipV = Random.Range(1, 3);
        float coinFlipS = Random.Range(1, 3);
        // Choisir la vitesse
        if (coinFlipV == 1)
        {
            vitesse = 0.008f;
        }
        else
        {
            vitesse = 0.012f;
        }
        // Choisir point de départ
        if (coinFlipY == 1)
        {
            posY = -6;
        }
        else
        {
            posY = 6;
            vitesse *= -1;
        }
        // Choisir grossissement
        if (coinFlipS == 1)
        {
            tauxScale *= -1;
        }

        transform.position = new Vector2(posXRando, posY);
    }

    // Update is called once per frame
    void Update()
    {
        float nouvellePositionX = transform.position.x;
        float nouvellePositionY = transform.position.y + vitesse;
        // Vérifier le wrap
        if (nouvellePositionY > 7 || nouvellePositionY < -7)
        {
            nouvellePositionY *= -1;
            nouvellePositionX = Random.Range(-6, 6);
            float coinFlipV = Random.Range(1, 3);
            float coinFlipY = Random.Range(1, 3);
            // Choisir nouvelle vitesse
            if (coinFlipV == 1)
            {
                vitesse = 0.008f;
            }
            else
            {
                vitesse = 0.012f;
            }
            // Choisir nouveau point Y
            if (coinFlipY == 1)
            {
                vitesse *= -1;
            }
        }

        transform.position = new Vector2(nouvellePositionX, nouvellePositionY);

        float taille = transform.localScale.x - tauxScale;
        // Vérifier la taille
        if (taille < 0.8 || taille > 2)
        {
            tauxScale *= -1;
        }
        transform.localScale = new Vector2(taille, taille);

    }
}
