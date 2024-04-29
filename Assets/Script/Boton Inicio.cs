using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    private void Start ()
    {

    }
    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Return))
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
