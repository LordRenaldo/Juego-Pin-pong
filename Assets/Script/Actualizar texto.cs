using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actualizartexto : MonoBehaviour
{
    float contadorDePuntosParaVida = 0;
    bool ganaVida = false;
    bool nivelUnoCompletado = false;
    bool nivelDosCompletado = false;
    bool nivelTresCompletado = false;
    public TextMeshProUGUI nivel;
    public TextMeshProUGUI puntaje;
    public TextMeshProUGUI vidas;
    int puntajeNumero = 0;
    int vidasNumero = 3;
    int nivelNumero = 1;

    void Update ()
    {
        VerificadorNivel ();
        if (this.vidasNumero < 0)
        {
            SceneManager.LoadScene (2);
        }
        else if (contadorDePuntosParaVida == 10000 && !ganaVida)
        {
            ganaVida = true;
            SumaVidas ();
        }
    }

    public void VerificadorNivel ()
    {
        if (!nivelUnoCompletado && puntajeNumero == 22800)
        {
            nivelNumero++;
            nivel.text = nivelNumero.ToString ();
            nivelUnoCompletado = true;
            SceneManager.LoadScene (3);
        }
        else if (!nivelDosCompletado && puntajeNumero == 48600)
        {
            nivelNumero++;
            nivel.text = nivelNumero.ToString ();
            nivelDosCompletado = true;
            SceneManager.LoadScene (4);
        }
        else if (!nivelTresCompletado && puntajeNumero == 77600)
        {
            nivelNumero++;
            nivel.text = nivelNumero.ToString ();
            nivelTresCompletado = true;
            SceneManager.LoadScene (5);
        }
    }
    public void SumaVidas ()
    {
        vidasNumero++;
        vidas.text = vidasNumero.ToString ();
        ganaVida = false;

    }

    public void RestaVida ()
    {
        vidasNumero--;
        vidas.text = vidasNumero.ToString ();
    }

    public void SumaPuntos ( int valorBloque )
    {

        puntajeNumero += valorBloque; ;
        puntaje.text = puntajeNumero.ToString ();

    }
}
