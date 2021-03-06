﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scene : MonoBehaviour 
{
	[SerializeField]
	private Gizmo gizmo;
	[SerializeField]
	private GameObject sceneElementPrefab;
	[SerializeField]
	private GameObject sceneElementContainer;

	[SerializeField]
	private Sprite sprite;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

    public string save()
    {
        string json = "{ \n\t scenes : [";
        foreach(Transform t in sceneElementContainer.transform)
        {
            SceneElement se = t.GetComponent<SceneElement>();
            if(se != null)
            {
                json += se.getSave();
                json += ", \n";
            }
        }
        json += "\n\t]}";
        return json;
    }

	public void createSceneElement(Sprite sprite)
	{
		GameObject obj = Instantiate(sceneElementPrefab);
		obj.transform.SetParent (sceneElementContainer.transform);
		obj.GetComponent<SceneElement>().initialize(sprite);
		obj.transform.position = new Vector3 (1, 0, 0);
		notifySelection (obj.GetComponent<RectTransform> ());
	}

	public void notifySelection(RectTransform selected)
	{
		gizmo.setOnObject(selected);
	}
}
