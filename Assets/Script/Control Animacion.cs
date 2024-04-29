using System.Collections;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip final;

    private void Awake ()
    {
        animator = GetComponent<Animator> ();
    }

    public void IniciarAnimacion ()
    {
        StartCoroutine (CambioEscena ());
    }

    private IEnumerator CambioEscena ()
    {
        animator.SetTrigger ("Iniciar");
        yield return new WaitForSeconds (final.length);
    }
}
