using UnityEngine;

public class MovimientoRaqueta : MonoBehaviour
{
    public Material azul;
    public Material rojo;
    public Material transparente;
    public Renderer LineaSuperior;
    public Renderer LineaInferior;
    public Renderer LineaIzquierda;
    public Renderer LineaDerecha;
    public float VelocidadMovimiento;
    public float VelocidadMovimientoLenta;
    bool raquetaCongelada = false;

    private void FixedUpdate ()
    {
        float movimientoHorizontal;
        if (raquetaCongelada == true)
        {
            movimientoHorizontal = Input.GetAxisRaw ("Horizontal");
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (movimientoHorizontal * VelocidadMovimientoLenta, 0);
        }
        else
        {
            movimientoHorizontal = Input.GetAxisRaw ("Horizontal");
            GetComponent<Rigidbody2D> ().velocity = new Vector2 (movimientoHorizontal * VelocidadMovimiento, 0);
        }
    }

    public void PosicionarRaqueta ()
    {
        Rigidbody2D Raqueta = this.gameObject.GetComponent<Rigidbody2D> ();
        this.gameObject.transform.localPosition = new Vector3 (0, -2.5f, 100);
    }
    public void AumentarVelocidadPelota ()
    {

    }
    public void CongelarRaqueta ()
    {
        LineaSuperior = transform.GetChild (0).GetComponent<Renderer> ();
        LineaSuperior.material = azul;

        LineaInferior = transform.GetChild (1).GetComponent<Renderer> ();
        LineaInferior.material = azul;

        LineaIzquierda = transform.GetChild (2).GetComponent<Renderer> ();
        LineaIzquierda.material = azul;

        LineaDerecha = transform.GetChild (3).GetComponent<Renderer> ();
        LineaDerecha.material = azul;
        raquetaCongelada = true;
        Debug.Log (raquetaCongelada);

    }
    public void DescongelarRaqueta ()
    {
        raquetaCongelada = false;
        LineaSuperior = transform.GetChild (0).GetComponent<Renderer> ();
        LineaSuperior.material = rojo;

        LineaInferior = transform.GetChild (1).GetComponent<Renderer> ();
        LineaInferior.material = rojo;

        LineaIzquierda = transform.GetChild (2).GetComponent<Renderer> ();
        LineaIzquierda.material = rojo;

        LineaDerecha = transform.GetChild (3).GetComponent<Renderer> ();
        LineaDerecha.material = rojo;

    }

}
