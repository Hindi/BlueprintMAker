using UnityEngine;
using System.Collections;

public class LateralPanelLoader : MonoBehaviour 
{
	[SerializeField]
	private DataLoader dataLoader;

	[SerializeField]
	private GameObject sceneTemplatePrefab;
	[SerializeField]
	private GameObject folderNamePrefab;

	[SerializeField]
	private Transform imageContainer;
	[SerializeField]
	private Transform folderNameContainer;
	[SerializeField]
	private RectTransform canvasRect;

	// Use this for initialization
	void Start () {
	
	}

	public void addFolder(string name)
	{
		GameObject obj = (GameObject)Instantiate (folderNamePrefab);
		obj.transform.SetParent (folderNameContainer);
		obj.GetComponent<FolderNameTemplate> ().Name = name;
		obj.GetComponent<FolderNameTemplate> ().lateralPanelLoader = this;

		obj.GetComponent<RectTransform>().localScale *= canvasRect.localScale.x;
	}

	public void addImage(string name, Sprite sprite)
	{
		GameObject obj = (GameObject)Instantiate (sceneTemplatePrefab);
		obj.transform.SetParent (imageContainer);
		obj.GetComponent<SceneElementTemplate> ().ElementName = name;
		obj.GetComponent<SceneElementTemplate> ().ElementSprite = sprite;
		obj.GetComponent<RectTransform>().localScale *= canvasRect.localScale.x;
	}

	public void displayerFolderContent(string name)
	{
		foreach (Transform t in imageContainer)
			Destroy (t.gameObject);

		Folder f = dataLoader.Folders[name];
		StartCoroutine(f.foreachSprite(delegate(string key, Sprite s) { 
			addImage(key, s);
		}));
	}
}
