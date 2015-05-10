using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FolderNameTemplate : MonoBehaviour 
{
	[SerializeField]
	private Text text;
	public string Name
	{
		get { return text.text;}
		set { text.text = value;}
	}

	[HideInInspector]
	public LateralPanelLoader lateralPanelLoader;

	public void requestDisplayContent()
	{
		lateralPanelLoader.displayerFolderContent(Name);
	}
}
