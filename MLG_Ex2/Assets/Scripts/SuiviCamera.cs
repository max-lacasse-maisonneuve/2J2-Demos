using UnityEngine;

public class SuiviCamera : MonoBehaviour
{
    float vitesse = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cible = new Vector3(transform.position.x, transform.position.y, -10);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cible, vitesse);
    }
}
