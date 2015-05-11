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
        if (Input.GetKeyDown(KeyCode.E))
#else
			if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Z))
#endif
        {
            redo();
        }
#if UNITY_EDITOR
		else if(Input.GetKeyDown(KeyCode.Z))
#else
		else if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Z))
#endif
		{
			undo();
		}
	}

    public void undo()
    {
        UndoSystem.undo();
    }

    public void redo()
    {
        UndoSystem.redo();
    }
}
