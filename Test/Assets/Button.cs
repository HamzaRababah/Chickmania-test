using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour,IInteractable
{
    public ParticleSystem Explosion;

    public void Interact()
    {
        StartCoroutine(Explode());
    }
    public IEnumerator Explode()
    {
        yield return new WaitForSeconds(5);
        Explosion.Play();

    }
}
