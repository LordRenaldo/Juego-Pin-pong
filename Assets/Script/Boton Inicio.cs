using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    private const KeyCode StartKey = KeyCode.Return;

    private void Update ()
    {
        if (Input.GetKeyDown (StartKey))
        {
            SceneManager.LoadScene ("Juego");
        }
    }

    public void CambioDeEscena ( int escenaID )
    {
        SceneManager.LoadScene (escenaID);
        Debug.Log ("boton presionado");
    }
}
