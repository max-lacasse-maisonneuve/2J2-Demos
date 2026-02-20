using UnityEngine;

public class ZoneCible : MonoBehaviour
{
    private GameObject balle;
    public float oscillation = 2f;

    void Start()
    {
        balle = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.position = new Vector2(Mathf.Sin(Time.time) * oscillation, transform.position.y);
        
        if(Vector2.Distance(transform.position, balle.transform.position) < 0.3f)
        {
            balle.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            balle.transform.SetParent(transform);
            balle.transform.localPosition = Vector3.zero;
        }
    }
}
