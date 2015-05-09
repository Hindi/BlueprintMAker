using UnityEngine;
using System.Collections;

public class DisplayTopMenuFunctionList : MonoBehaviour 
{
	[SerializeField]
	private GameObject functionList;

	private bool menuDisplayed;

	// Use this for initialization
	void Start () 
	{
		menuDisplayed = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (menuDisplayed) {
			if(Input.GetMouseButtonUp(0))
				StartCoroutine(closeMenu());
		}
	}

	IEnumerator closeMenu()
	{
		yield return new WaitForEndOfFrame ();
		toggleDisplayList();
	}

	public void toggleDisplayList()
	{
		StartCoroutine (applyToggle ());
	}

	IEnumerator applyToggle()
	{
		yield return new WaitForEndOfFrame ();
		menuDisplayed = !menuDisplayed;
		functionList.SetActive(menuDisplayed);
	}
}
