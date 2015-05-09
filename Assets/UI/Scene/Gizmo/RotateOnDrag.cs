using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class RotateOnDrag : GizmoFunction
{	
	private Quaternion initialRotation;
	public override void OnDrag(PointerEventData data)
	{
		base.OnDrag(data);
		float rotation = data.delta.x + data.delta.y;
		gizmo.notifyRotation(rotation);
	}
	
	public override void OnBeginDrag(PointerEventData data)
	{
		base.OnBeginDrag(data);
		initialRotation = gizmo.CurrentTarget.transform.rotation;
	}
	
	public override void OnEndDrag(PointerEventData data)
	{
		base.OnEndDrag(data);
		UndoSystem.registerRotateAction(initialRotation, gizmo.CurrentTarget);
	}
}
