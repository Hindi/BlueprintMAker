using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gizmo : MonoBehaviour 
{	
	private RectTransform rectTransform;
	[SerializeField]
	private RectTransform currentTarget;
	public GameObject CurrentTarget
	{ get { return currentTarget.gameObject; } }

	[SerializeField]
	private GameObject translationTool;
	[SerializeField]
	private GameObject rotationTool;
	[SerializeField]
	private GameObject scaleTool;

	[SerializeField]
	private ToggleButton translationButton;
	[SerializeField]
	private ToggleButton rotationButton;
	[SerializeField]
	private ToggleButton scaleButton;
	
	// Use this for initialization
	void Start () 
	{
		rectTransform = GetComponent<RectTransform> ();
		setTranslationMode ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Delete))
			destroySelection();
	}

	public void notifyTranslation(Vector2 nextPosition)
	{
		currentTarget.position = (nextPosition);
		transform.position = nextPosition;
	}

	public void notifyRotation(float rot)
	{
		currentTarget.Rotate (Vector3.forward * rot);
	}
	
	public void notifyScale(Vector3 scale)
	{
		currentTarget.localScale += scale;
	}
	
	public void setOnObject(RectTransform target)
	{
		currentTarget = target;
		UndoSystem.registerChangeGizmoTargetAction (CurrentTarget, this);
		rectTransform.anchoredPosition = target.anchoredPosition;
	}

	public void hide()
	{
		transform.Translate (Vector3.up * 1000);
	}

	private void destroySelection()
	{
		if (currentTarget != null) 
		{
			currentTarget.GetComponent<Selectable>().destroySelf();
			hide();
		}
	}

	public void setTranslationMode()
	{
		setButtonActive (translationButton, translationTool, true);
		setButtonActive (rotationButton, rotationTool, false);
		setButtonActive (scaleButton, scaleTool, false);
	}

	public void setRotationMode()
	{
		setButtonActive (translationButton, translationTool, false);
		setButtonActive (rotationButton, rotationTool, true);
		setButtonActive (scaleButton, scaleTool, false);
	}
	
	public void setScaleMode()
	{
		setButtonActive (translationButton, translationTool, false);
		setButtonActive (rotationButton, rotationTool, false);
		setButtonActive (scaleButton, scaleTool, true);
	}

	private void setButtonActive(ToggleButton button, GameObject tool, bool b)
	{
		tool.SetActive(b);
		button.setPressed (b);
	}
}
