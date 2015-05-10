using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;

public class SceneElementTemplate : MonoBehaviour, IPointerClickHandler
{	[SerializeField]
	private Image image;
	
	[SerializeField]
	private Text nameLabel;

	[HideInInspector]
	public Sprite ElementSprite
	{ 
		get { return image.sprite; } 
		set { image.sprite  = value; }
	}

	[HideInInspector]
	public string ElementName
	{ 
		get { return nameLabel.text; } 
		set { nameLabel.text = value; } 
	}

	private Scene scene;

	public void initialize(string name, Sprite sprite)
	{
		nameLabel.text = name;
		image.sprite = sprite;
	}

	// Use this for initialization
	void Start () 
	{
		scene = GameObject.FindGameObjectWithTag ("Scene").GetComponent<Scene>();
		if (scene == null)
			Debug.LogError ("[SCENE ELEMENT TEMPLATE] Scene pointer is null");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		scene.createSceneElement (ElementSprite);
	}
}
