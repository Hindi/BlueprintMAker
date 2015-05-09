using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class GizmoFunction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	[SerializeField]
	protected RectTransform canvasRect;
	
	[SerializeField]
	protected Gizmo gizmo;

	protected Vector3 deltaOnClick;

	// Use this for initialization
	void Start () 
	{
		if (gizmo == null)
			Debug.LogError ("[GIZMOFUNCTION] gizmo pointer is null");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void OnDrag(PointerEventData data)
	{

	}
	
	public virtual void OnBeginDrag(PointerEventData data)
	{
		RectTransformUtility.ScreenPointToWorldPointInRectangle (canvasRect, data.pressPosition, data.pressEventCamera, out deltaOnClick);
		deltaOnClick = gizmo.transform.position - deltaOnClick;
	}
	
	public virtual void OnEndDrag(PointerEventData data)
	{
		
	}
}
