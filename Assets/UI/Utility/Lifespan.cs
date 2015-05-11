using UnityEngine;
using System.Collections;

public class Lifespan : MonoBehaviour 
{
    [SerializeField]
    private float timeAlive;

	// Use this for initialization
	void Start () 
    {
        StartCoroutine(selfDestroyCoroutine());
	}

    IEnumerator selfDestroyCoroutine()
    {
        yield return new WaitForSeconds(timeAlive);
        Destroy(gameObject);
    }
}
