using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DeplacementAvion : MonoBehaviour
{
    //===== Variables publiques
    public float vitesse;
    public int points;
    public float tempsPasse = 0;

    public InputAction onDeplacementVertical;
    public InputAction onDeplacementHorizontal;

    //Sons
    public AudioClip sonEchec;
    public AudioClip sonEtoile;

    AudioSource audioSource;


    //UI
    public TMP_Text textePoints;
    public TMP_Text texteTemps;

    public GameObject panneauMort;

    //===== Variables privées
    Rigidbody2D rigid;
    //Audiosource
    float deplacementHor = 0;
    float deplacementVert = 0;
    public bool estMort = false;

    //Points

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
        //Affecter le composant AudioSource à une variable
        audioSource = GetComponent<AudioSource>();
        // audioSource.pitch = 2;
        // audioSource.mute = true;
        // audioSource.clip = sonEchec;
        points = 0;
        // textePoints.text = points.ToString();
        textePoints.text = $"{points} pts";
    }

    void Update()
    {
        tempsPasse += Time.deltaTime;
        texteTemps.text = $"{tempsPasse:F2}s";

        // float angleAvion = transform.eulerAngles.z;
        // if (angleAvion > -45f && angleAvion < 45f)
        // {
        //     deplacementHor = onDeplacementHorizontal.ReadValue<float>();

        // }

        if (estMort == false)
        {

            deplacementVert = onDeplacementVertical.ReadValue<float>();
        }
        else
        {
            deplacementHor = 0;
            deplacementVert = 0;

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Invoke("RedemarrerScene", 1f);
            }
        }

        // Modifier la vélocité linéaire de l'avion.
        rigid.linearVelocityX = deplacementHor * vitesse;
        rigid.linearVelocityY = deplacementVert * vitesse;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            //MORT!!!!
            audioSource.Stop();
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(sonEchec);

            Debug.Log("Mort!");
            panneauMort.SetActive(true);
            Mourir();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Etoile")
        {
            audioSource.PlayOneShot(sonEtoile);
            points++;
            textePoints.text = $"{points} pts";
            collision.gameObject.GetComponent<GestionEtoile>().Cacher();
            // Destroy(collision.gameObject);//Détruit le gameobject
            Debug.Log(points);
        }
    }
    // Ajouter une méthode OnTriggerEnter2D
    // Si le tag du gameobject de la collision est "Etoile" et que le joueur n'est pas mort
    //// Accéder au script "GestionEtoile"
    //// Déclencher la fonction publique Cacher de l'étoile
    //// Ajouter un son d'étoile
    //// Ajouter des points
    //// Mettre à jour le texte du UI
    // Fin OnTriggerEnter2D


    void Mourir()
    {
        estMort = true;
        // Enlever la contrainte de rotation
        rigid.freezeRotation = false;
        // Ajouter une vélocité de rotation
        rigid.angularVelocity = 500;
        rigid.gravityScale = 3;//Ajoute la gravité
        GetComponent<Collider2D>().enabled = false;//On désactive le collider

        // Ajouter un son de mort
        // Déclencher la fonction RedemarrerScene après 3sec
        // Invoke("RedemarrerScene", 2f);
    }

    /**
    * Fonction servant à redémarrer la scène actuelle
    */
    void RedemarrerScene()
    {
        string nomSceneCourante = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nomSceneCourante);
    }

}
