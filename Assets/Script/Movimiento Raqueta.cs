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
    private Rigidbody2D rbRaqueta;

    private void Awake ()
    {
        rbRaqueta = this.gameObject.GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate ()
    {
        float movimientoHorizontal = Input.GetAxisRaw ("Horizontal");
        float velocidad = raquetaCongelada ? VelocidadMovimientoLenta : VelocidadMovimiento;
        rbRaqueta.linearVelocity = new Vector2 (movimientoHorizontal * velocidad, 0);
    }

    public void PosicionarRaqueta ()
    {
        this.gameObject.transform.localPosition = new Vector3 (0, -2.5f, 100);
    }


    public void CambiarMaterialRaqueta ( Material material )
    {
        for (int i = 0; i < 4; i++)
        {
            Renderer linea = transform.GetChild (i).GetComponent<Renderer> ();
            linea.material = material;
        }
    }

    public void CongelarRaqueta ()
    {
        CambiarMaterialRaqueta (azul);
        raquetaCongelada = true;
        Debug.Log (raquetaCongelada);
    }

    public void DescongelarRaqueta ()
    {
        raquetaCongelada = false;
        CambiarMaterialRaqueta (rojo);
    }
}
