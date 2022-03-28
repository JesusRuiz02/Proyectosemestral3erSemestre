using UnityEngine;
public class decaying_enemy : MonoBehaviour
{
    [SerializeField] public float velocidad;
    [SerializeField] public float velocidaddeReversa;
    [SerializeField] public float distanciaDeljugador;
    [SerializeField] public float rangodeVision;
    [SerializeField] public float RangodeReversa;
    [SerializeField] public float RangodeDisparo;
    [SerializeField] public Transform player;
    [SerializeField] public Rigidbody2D rb2D;

    private void Update()
    {
        distanciaDeljugador = Vector2.Distance(player.position, rb2D.position);
        if (distanciaDeljugador < rangodeVision && distanciaDeljugador > RangodeReversa && distanciaDeljugador > RangodeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidad * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }

        else if (distanciaDeljugador < rangodeVision && distanciaDeljugador > RangodeReversa && distanciaDeljugador <= RangodeDisparo)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, 0 * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
        else if (distanciaDeljugador < RangodeReversa)
        {
            Vector2 objetivo = new Vector2(player.position.x, player.position.y);
            Vector2 nuevaPos = Vector2.MoveTowards(rb2D.position, objetivo, velocidaddeReversa * Time.deltaTime);
            rb2D.MovePosition(nuevaPos);
        }
    }
}
