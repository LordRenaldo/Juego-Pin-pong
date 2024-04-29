using UnityEngine;

public class ControlSonido : MonoBehaviour
{
    public AudioSource sonidoRaqueta;
    public AudioSource sonidoPared;
    public AudioSource sonidoBloqueBlanco;

    private void OnCollisionEnter2D ( Collision2D collision )
    {
        if (collision.gameObject.name == ("Raqueta"))
        {
            this.sonidoRaqueta.Play ();
        }
        else if (collision.gameObject.name == ("Pared superior") || collision.gameObject.name == ("Pared izquierda") || collision.gameObject.name == ("Pared derecha"))
        {
            this.sonidoPared.Play ();
        }
    }
}


