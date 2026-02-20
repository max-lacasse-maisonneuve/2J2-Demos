using UnityEngine;

public class MissileTeteChercheuse : MonoBehaviour
{
    // Variables publiques
    public GameObject joueur; // Méthode 1: Recherche par tag
    public GameObject positionDepart; //Méthode 2: Glisser dans inspecteur
    public float distanceMin = 5f;
    // Variables privées
    private GameObject cible;
    private SpriteRenderer sr;//Par défaut la variable est vide

    void Start()
    {
        joueur = GameObject.FindGameObjectWithTag("Player");
        cible = positionDepart;

        sr = GetComponent<SpriteRenderer>(); //Trouve le component SpriteRenderer et ajoute dans la variable
        sr.flipY = true;
        sr.color = Color.green;
    }
    void Update()
    {
        float distance = Vector2.Distance(transform.position, joueur.transform.position);

        //Si la distance plus petite que 0.3f, on met la propriété estMort à true du script DeplacementJoueur
        if (distance < 0.3f)
        {
            joueur.GetComponent<DeplacementJoueur>().estMort = true;
        }

        if (distance < distanceMin)
        {
            //Changer la couleur du missile
            sr.color = Color.red;
            joueur.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            cible = joueur;
        }
        else
        {
            //Remettre la couleur normale au missile
            sr.color = Color.white;
            joueur.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            cible = positionDepart;
        }

        // Déplacer vers la cible
        transform.position = Vector2.MoveTowards(transform.position, cible.transform.position, 0.01f);

        // Tourner en direction de la cible
        Vector2 direction = transform.position - cible.transform.position;
        transform.up = direction;

    }
}
