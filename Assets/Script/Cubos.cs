using UnityEngine;

public class Cubos : MonoBehaviour
{
    int contadorBloques = 0;
    public MovimientoPelota MovimientoPelota;
    private Rigidbody2D rbPelota;

    private void Awake ()
    {
        rbPelota = MovimientoPelota.GetComponent<Rigidbody2D> ();
    }

    void ReboteCubo ( Collision2D colision )
    {
        Debug.Log ("Rebote con cubo llamado");
        Vector2 direccionPelota = rbPelota.velocity.normalized;
        Vector2 direccionSuperficie = colision.contacts [0].normal;
        float anguloAleatorio = Random.Range (-10f, 10f);
        Vector2 direccionRebote = Quaternion.Euler (0, 0, anguloAleatorio) * direccionPelota;
        rbPelota.velocity = direccionRebote * rbPelota.velocity.magnitude;
    }

    private void OnCollisionEnter2D ( Collision2D colLision )
    {
        ReboteCubo (colLision);
        Destroy (gameObject);
        contadorBloques++;
    }

    public int NumeroDeBloquesDestruidos ()
    {
        return contadorBloques;
    }
}
