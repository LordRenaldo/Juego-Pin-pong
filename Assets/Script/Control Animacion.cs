using System.Collections;
using UnityEngine;

public class ControlAnimacion : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AnimationClip final;

    private void Start ()
    {
        animator = GetComponent<Animator> ();
    }
    private void Update ()
    {

    }
    IEnumerator CambioEscena ()
    {
        animator.SetTrigger ("Iniciar");
        yield return new WaitForSeconds (final.length);
    }
}
