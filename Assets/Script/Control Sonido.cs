using UnityEngine;

public class ControlSonido : MonoBehaviour
{
    public AudioSource sonidoRaqueta;
    public AudioSource sonidoPared;
    public AudioSource sonidoBloqueBlanco;

    private void OnCollisionEnter2D ( Collision2D collision )
    {
        switch (collision.gameObject.name)
        {
            case "Raqueta":
            sonidoRaqueta.Play ();
            break;
            case "Pared superior":
            case "Pared izquierda":
            case "Pared derecha":
            sonidoPared.Play ();
            break;
        }
    }
}


