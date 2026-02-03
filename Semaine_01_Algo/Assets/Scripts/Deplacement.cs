using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public string nom;

    public float vitesse;

    public int nbVies;

    public bool peutSeDeplacer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(nom);
    }

    // Update is called once per frame
    void Update()
    {
        float nouvellePositionX = transform.position.x + vitesse;
        float nouvellePositionY = transform.position.y;

        if (nouvellePositionX > 10)
        {
            nouvellePositionX = -10;
        }
        else if (nouvellePositionX > 0 && nouvellePositionX < 10)
        {

        }
        else
        {
            
        }

        transform.position = new Vector2(nouvellePositionX, nouvellePositionY);
    }
}
