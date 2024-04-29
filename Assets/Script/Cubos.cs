using UnityEngine;

public class Cubos : MonoBehaviour
{
    int contadorBloques = 0;
    public MovimientoPelota MovimientoPelota;
    void ReboteCubo ( Collision2D colision )
    {
        Debug.Log ("Rebote con cubo llamado");
        Vector2 direccionPelota = this.MovimientoPelota.GetComponent<Rigidbody2D> ().velocity.normalized;
        Vector2 direccionSuperficie = colision.contacts [0].normal;
        float anguloAleatorio = Random.Range (-10f, 10f);
        Vector2 direccionRebote = Quaternion.Euler (0, 0, anguloAleatorio) * direccionPelota;
        this.MovimientoPelota.GetComponent<Rigidbody2D> ().velocity = direccionRebote * this.MovimientoPelota.GetComponent<Rigidbody2D> ().velocity.magnitude;

    }
    private void OnCollisionEnter2D ( Collision2D colLision )
    {
        Rigidbody2D cubo = this.gameObject.GetComponent<Rigidbody2D> ();
        ReboteCubo (colLision);
        Destroy (gameObject);
        contadorBloques++;

    }
    public int NumeroDeBloquesDestruidos ()
    {
        return contadorBloques;
    }
}
