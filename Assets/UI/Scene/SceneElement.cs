using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneElement : MonoBehaviour 
{
	[SerializeField]
	private Image image;

	public void initialize(Sprite sprite)
	{
		image.sprite = sprite;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
