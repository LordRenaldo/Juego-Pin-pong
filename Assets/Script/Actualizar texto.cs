using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Actualiza UI (nivel/puntaje/vidas) y maneja progreso y game over.
/// Se alimenta desde ControlColision (SumaPuntos / RestaVida).
/// </summary>
public class Actualizartexto : MonoBehaviour
{
    [Header ("UI")]
    public TextMeshProUGUI nivel;
    public TextMeshProUGUI puntaje;
    public TextMeshProUGUI vidas;

    [Header ("Estado")]
    [SerializeField] private int puntajeNumero = 0;
    [SerializeField] private int vidasNumero = 3;
    [SerializeField] private int nivelNumero = 1;

    // Vida extra cada 10.000 puntos (acumulado).
    private const int PUNTOS_POR_VIDA = 10000;
    private int puntosAcumuladosParaVida = 0;

    // Para que no vuelva a disparar el mismo cambio de nivel.
    private readonly bool [] nivelesCompletados = new bool [3];

    private void Start ()
    {
        RefrescarUI ();
    }

    private void Update ()
    {
        VerificadorNivel ();

        // Game over cuando llegas a 0 vidas.
        if (vidasNumero <= 0)
        {
            SceneManager.LoadScene (2);
        }
    }

    private void RefrescarUI ()
    {
        if (nivel) nivel.text = nivelNumero.ToString ();
        if (puntaje) puntaje.text = puntajeNumero.ToString ();
        if (vidas) vidas.text = vidasNumero.ToString ();
    }

    public void VerificadorNivel ()
    {
        int [] puntajesParaNiveles = { 22800, 48600, 77600 };

        for (int i = 0; i < puntajesParaNiveles.Length; i++)
        {
            if (!nivelesCompletados [i] && puntajeNumero >= puntajesParaNiveles [i])
            {
                nivelNumero++;
                if (nivel) nivel.text = nivelNumero.ToString ();

                nivelesCompletados [i] = true;

                // Mantengo tu lógica original: escena 3/4/5 según el nivel.
                SceneManager.LoadScene (i + 3);
                break;
            }
        }
    }

    public void SumaVidas ()
    {
        vidasNumero++;
        if (vidas) vidas.text = vidasNumero.ToString ();
    }

    public void RestaVida ()
    {
        vidasNumero = Mathf.Max (0, vidasNumero - 1);
        if (vidas) vidas.text = vidasNumero.ToString ();
    }

    public void SumaPuntos ( int valorBloque )
    {
        puntajeNumero += valorBloque;
        if (puntaje) puntaje.text = puntajeNumero.ToString ();

        // Acumula para vida extra (funciona aunque sumes de a 100/200/300/400).
        puntosAcumuladosParaVida += valorBloque;
        while (puntosAcumuladosParaVida >= PUNTOS_POR_VIDA)
        {
            puntosAcumuladosParaVida -= PUNTOS_POR_VIDA;
            SumaVidas ();
        }
    }
}
