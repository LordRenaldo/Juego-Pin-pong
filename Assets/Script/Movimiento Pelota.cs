using System.Collections;
using UnityEngine;

public class MovimientoPelota : MonoBehaviour
{
    public MovimientoRaqueta MovimientoRaqueta;
    public float velocidadMovimiento;
    public float velocidadExtra;
    public float velocidadMaxima;
    float contadorGolpe = 0;

    void Start ()
    {
        StartCoroutine (this.IniciarMovimientoPelota ());
    }
    public IEnumerator SiguienteIntento ( bool comienzaJuagador = true )
    {
        contadorGolpe = 0;
        this.PosicionarPelota (comienzaJuagador);
        yield return new WaitForSeconds (3);

        if (comienzaJuagador)
        {
            this.MovimientoRaqueta.PosicionarRaqueta ();
            yield return new WaitForSeconds (3);
            this.MoverPelota (new Vector2 (0, 1));
        }
    }
    public IEnumerator IniciarMovimientoPelota ( bool comienzaJuagador = true )
    {
        contadorGolpe = 0;
        yield return new WaitForSeconds (2);
        if (comienzaJuagador)
        {
            this.MoverPelota (new Vector2 (0, -1));
        }
    }
    public void MoverPelota ( Vector2 direccion )
    {
        direccion = direccion.normalized;
        float velocidad = this.velocidadMovimiento + this.contadorGolpe * velocidadExtra;
        Rigidbody2D pelota = this.gameObject.GetComponent<Rigidbody2D> ();
        pelota.velocity = direccion * velocidad;
    }
    public void PosicionarPelota ( bool comienzaJugador )
    {
        this.gameObject.transform.localPosition = new Vector3 (0, -4, 100);
    }
    public void AumentarContadorGolpe ()
    {
        if (this.contadorGolpe * this.velocidadExtra <= this.velocidadMaxima)
        {
            contadorGolpe++;
        }
    }
}