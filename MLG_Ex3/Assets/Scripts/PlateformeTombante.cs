using UnityEngine;

public class PlateformeTombante : MonoBehaviour
{
    public Sprite imageBlocBrise;
    public float tempsDisponible = 2f;
    public bool estTombee = false;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid.bodyType = RigidbodyType2D.Static;

    }


    void Update()
    {
        if (rigid != null && estTombee == false && tempsDisponible <= 0)
        {
            estTombee = true;

            rigid.bodyType = RigidbodyType2D.Dynamic;
            this.enabled = false;
            Invoke("Detruire", 2f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (estTombee == false && collision.gameObject.tag == "Player")
        {
            spriteRenderer.sprite = imageBlocBrise;

        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (estTombee == false && collision.gameObject.tag == "Player")
        {
            tempsDisponible -= Time.deltaTime;
        }
    }

    void Detruire()
    {
        gameObject.SetActive(false);
    }

}
