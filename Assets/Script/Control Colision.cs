using UnityEngine;

public class ControlColision : MonoBehaviour
{
    public MovimientoRaqueta MovimientoRaqueta;
    public MovimientoPelota movimientoPelota;
    public Actualizartexto actualizartexto;
    public Material azul;
    public Material rojo;
    public Material Transparente;
    public Renderer pelota;
    public bool pelotaHelada = false;
    public bool pelotaTransparente = false;

    private Rigidbody2D rbPelota;

    private void Awake ()
    {
        rbPelota = movimientoPelota.GetComponent<Rigidbody2D> ();
    }

    void ReboteConRaqueta ( Collision2D colision )
    {
        Vector3 posicionPelota = this.transform.position;
        Vector3 posicionRaqueta = colision.gameObject.transform.position;
        float anchoRaqueta = colision.collider.bounds.size.x;
        float y = 1;

        float x = (posicionPelota.x - posicionRaqueta.x) / anchoRaqueta;

        this.movimientoPelota.MoverPelota (new Vector2 (x, y));
        this.movimientoPelota.AumentarContadorGolpe ();
    }

    void Rebote ( Collision2D colision, float anguloAleatorio )
    {
        Vector2 direccionPelota = rbPelota.linearVelocity.normalized;
        Vector2 direccionSuperficie = colision.contacts [0].normal;
        Vector2 direccionRebote = Quaternion.Euler (0, 0, anguloAleatorio) * direccionPelota;
        rbPelota.linearVelocity = direccionRebote * rbPelota.linearVelocity.magnitude;
    }

    void RebotePared ( Collision2D colision )
    {
        Debug.Log ("Estabilizador llamado");
        Rebote (colision, Random.Range (-10f, 10f));
    }

    void EstabiliadorAleatorioDeRebote ( Collision2D colision )
    {
        Debug.Log ("Estabilizador aleatorio llamado");
        Rebote (colision, Random.Range (-100f, 100f));
    }

    void CambiarMaterialPelota ( Material material )
    {
        pelota = GetComponent<Renderer> ();
        pelota.material = material;
    }

    void VuelveTransparenteLaPelota ()
    {
        CambiarMaterialPelota (Transparente);
    }

    void VuelvePelotaVisible ()
    {
        CambiarMaterialPelota (rojo);
    }

    private void OnCollisionEnter2D ( Collision2D colision )
    {
        if (colision.gameObject.name == "Raqueta")
        {
            if (pelotaHelada)
            {
                MovimientoRaqueta.CongelarRaqueta ();
                ReboteConRaqueta (colision);
                MovimientoRaqueta.Invoke ("DescongelarRaqueta", 2);
            }
            ReboteConRaqueta (colision);
            Debug.Log ("ReboteConRaqueta llamado");
        }

        else if (colision.gameObject.name == "Pared izquierda" || colision.gameObject.name == "Pared derecha" || colision.gameObject.name == "Pared superior")
        {
            RebotePared (colision);
            Debug.Log ("pego con una pared");
        }

        else if (colision.gameObject.name == "Pared Inferior")
        {
            this.GetComponent<Rigidbody2D> ().linearVelocity = new Vector2 (0, 0);

            actualizartexto.RestaVida ();
            StartCoroutine (this.movimientoPelota.SiguienteIntento (true));
        }

        else if (colision.gameObject.name == "Cubo Blanco")
        {
            actualizartexto.SumaPuntos (100);
            pelotaHelada = false;
            CambiarMaterialPelota (rojo);
        }

        else if (colision.gameObject.name == "Cubo Azul")
        {
            actualizartexto.SumaPuntos (200);
            pelotaHelada = true;
            CambiarMaterialPelota (azul);
            Debug.Log (pelotaHelada);

        }
        else if (colision.gameObject.name == "Cubo Rosa")
        {
            actualizartexto.SumaPuntos (300);
            EstabiliadorAleatorioDeRebote (colision);

        }
        else if (colision.gameObject.name == "Cubo Transparente")
        {
            actualizartexto.SumaPuntos (400);
            VuelveTransparenteLaPelota ();
            Invoke ("VuelvePelotaVisible", 0.5f);

        }
    }
}
