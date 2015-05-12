using UnityEngine;
using System.Collections;

public class MyDebug : MonoBehaviour 
{

    [SerializeField]
    private SceneLoader scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            scene.saveScene("pouet");
        }
	}
}
