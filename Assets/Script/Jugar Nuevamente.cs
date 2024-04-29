using UnityEngine;
using UnityEngine.SceneManagement;

public class JugarOtraVez : MonoBehaviour
{
    void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyUp (KeyCode.Space))
        {
            Debug.Log ("entro");
            SceneManager.LoadScene (1);
        }
    }

}
