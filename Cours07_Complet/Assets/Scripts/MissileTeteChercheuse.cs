using UnityEngine;

public class MissileTeteChercheuse : MonoBehaviour
{
    // Variables publiques
    public GameObject pointDepart; //Méthode 1: On glisse le gameObject dans l'inspecteur
    public GameObject joueur; // Méthode 2: On cherche l'objet dans la scène dans le Start
    public float vitesse = 0.01f;
    public float distanceDetection = 4f;
    public float distanceCollision = 1f;

    // Variables privées
    GameObject cible; //Des fois la cible c'est le joueur, des fois la cible c'est le point de départ
    SpriteRenderer sr;

    void Start()
    {
        // On trouve les références
        sr = GetComponent<SpriteRenderer>();
        joueur = GameObject.FindGameObjectWithTag("Player");

        // On initialise les valeurs au démarrage
        cible = pointDepart;
        transform.position = cible.transform.position;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, joueur.transform.position);

        if (distance < distanceDetection)
        {
            sr.color = Color.red;
            cible = joueur;
        }
        else
        {
            cible = pointDepart;
            sr.color = Color.white;
        }

        if (distance < distanceCollision)
        {
            sr.color = Color.black;
            joueur.GetComponent<DeplacementJoueur>().estMort = true;
            joueur.GetComponentInChildren<SpriteRenderer>().color = Color.black;
        }

        transform.position = Vector2.MoveTowards(transform.position, cible.transform.position, vitesse);
        Vector2 direction = cible.transform.position - transform.position;
        transform.up = direction;
    }
}
