using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeplacementAvion : MonoBehaviour
{
    public float vitesse;
    public InputAction onDeplacementVertical;
    public InputAction onDeplacementHorizontal;
    public AudioClip sonEtoile;
    public AudioClip sonImpact;

    public TMP_Text textePoints;
    Rigidbody2D rigid;
    AudioSource source;
    float deplacementHor = 0;
    float deplacementVert = 0;
    public bool estMort = false;
    int points = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (estMort == false)
        {

            deplacementHor = onDeplacementHorizontal.ReadValue<float>();
            deplacementVert = onDeplacementVertical.ReadValue<float>();
        }
        else
        {
            deplacementHor = 0;
            deplacementVert = 0;
        }

        // Modifier la vélocité linéaire de l'avion  
    }


    // Ajouter une méthode OnCollisionEnter2D
    // Si le tag du gameobject de la collision est "Obstacle" et que le joueur n'est pas mort

    //// Affecter true à estMort
    //// Enlever la contrainte de rotation
    //// Ajouter une vélocité de rotation


    //// Déclencher la fonction Mourir
    //Fin OnCollisionEnter2D




    // Ajouter une méthode OnTriggerEnter2D
    // Si le tag du gameobject de la collision est "Etoile" et que le joueur n'est pas mort

    //// Accéder au script "GestionEtoile"
    //// Déclencher la fonction publique Cacher
    //// Ajouter un son
    //// Ajouter des points
    //// Modifier le UI
    // Fin OnTriggerEnter2D


    void Mourir()
    {
        source.Stop();
        source.volume = 0.5f;
        source.PlayOneShot(sonImpact);

        Invoke("RedemarrerScene", 3f);
    }

    void RedemarrerScene()
    {
        string nomSceneCourante = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomSceneCourante);
    }

}
