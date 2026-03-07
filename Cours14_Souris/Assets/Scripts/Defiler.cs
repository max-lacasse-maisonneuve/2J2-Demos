using UnityEngine;
using UnityEngine.EventSystems;

public class Defiler : MonoBehaviour
{
    public float limiteBas;
    public float limiteHaut;
    public float vitesse;

    public void AuDefiler(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;

        float deplacement = pointerEventData.scrollDelta.y * vitesse;

        if (transform.position.y >= limiteBas && transform.position.y <= limiteHaut)
        {
            transform.Translate(0, deplacement, 0);

            Vector3 positionActuelle = transform.position;
            positionActuelle.y = Mathf.Clamp(positionActuelle.y, limiteBas, limiteHaut);
            transform.position = positionActuelle;
        }
        ;
    }
}
