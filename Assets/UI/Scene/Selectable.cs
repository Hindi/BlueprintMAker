using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;

public class Selectable : MonoBehaviour, IPointerClickHandler
{
	private Scene scene;
	private RectTransform rectTransform;

	// Use this for initialization
	void Start () 
	{
		rectTransform = GetComponent<RectTransform> ();
		scene = GameObject.FindGameObjectWithTag ("Scene").GetComponent<Scene>();
		if (scene == null)
			Debug.LogError ("[SELECTABLE] Scene pointer is null");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void OnPointerClick(PointerEventData eventData)
    {
        scene.notifySelection(rectTransform);
	}

	public void destroySelf()
	{
		Destroy (gameObject);
	}
}
