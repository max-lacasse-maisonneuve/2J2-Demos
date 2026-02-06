using UnityEngine;

public class EtoileScintillante : MonoBehaviour
{
    public float min = 0.1f;
    public float max = 2f;
    public float taille = 0.1f;
    public int direction = 1;
    void Start()
    {
        float tailleInitiale = Random.Range(min, max);
        transform.localScale = new Vector2(tailleInitiale, tailleInitiale);
        direction = Random.Range(0, 2) == 0 ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {

        float nouvelleTaille = transform.localScale.x + (direction * taille);
        transform.localScale = new Vector2(nouvelleTaille, nouvelleTaille);

        if (nouvelleTaille < min || nouvelleTaille > max)
        {
            direction = -direction;
        }
    }
}
