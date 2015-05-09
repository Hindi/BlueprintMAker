using UnityEngine;
using System.Collections;

public class UndoListener : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Z))
#else
		if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
#endif
		{
			UndoSystem.undo();
		}
		
#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.E))
#else
			if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
#endif
		{
			UndoSystem.redo();
		}
	}
}
