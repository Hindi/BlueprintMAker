using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class Folder {

	private Dictionary<string, Sprite> images;
	private string name;
	public string Name { get { return name; } }
	public int Count {get { return images.Count; } }

	public Folder()
	{
		images = new Dictionary<string, Sprite> ();
	}
	
	public Folder(string name)
	{
		images = new Dictionary<string, Sprite> ();
		this.name = name;
	}

	public IEnumerator foreachSprite(Action<string, Sprite> action)
	{
		foreach (KeyValuePair<string, Sprite> p in images) {
			action (p.Key, p.Value);
			yield return null;
		}
	}

	public void addSprite(string name, Sprite s)
	{
		images.Add (name, s);
	}
}

public class ImageLoader : MonoBehaviour 
{
	[SerializeField]
	private LateralPanelLoader lateralPanelLoader;

	private Dictionary<string, Folder> folders;
	public Dictionary<string, Folder> Folders { get { return folders; }}

	// Use this for initialization
	void Start () {
		folders = new Dictionary<string, Folder>();
        StartCoroutine(loadImages());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator loadImages()
	{
		DirectoryInfo dInfo = new DirectoryInfo("Assets/Resources/Images");
		DirectoryInfo[] subdirs = dInfo.GetDirectories();
		foreach (DirectoryInfo d in subdirs) {
			Folder f = new Folder(d.Name);
			folders.Add(d.Name, f);

			foreach (FileInfo img in d.GetFiles(@"*.png", SearchOption.TopDirectoryOnly))
			{
				string name = Path.GetFileNameWithoutExtension(img.Name);
				Sprite s = Resources.Load <Sprite> ("Images/" + d.Name + "/" + name);
				f.addSprite(name, s);
				yield return null;
			}
			lateralPanelLoader.addFolder(d.Name);
		}
	}
}
