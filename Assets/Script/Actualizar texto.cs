using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actualizartexto : MonoBehaviour
{
    float contadorDePuntosParaVida = 0;
    bool ganaVida = false;
    bool [] nivelesCompletados = new bool [3];
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
        int [] puntajesParaNiveles = { 22800, 48600, 77600 };
        for (int i = 0; i < puntajesParaNiveles.Length; i++)
        {
            if (!nivelesCompletados [i] && puntajeNumero == puntajesParaNiveles [i])
            {
                nivelNumero++;
                nivel.text = nivelNumero.ToString ();
                nivelesCompletados [i] = true;
                SceneManager.LoadScene (i + 3);
                break;
            }
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
        puntajeNumero += valorBloque;
        puntaje.text = puntajeNumero.ToString ();
    }
}
