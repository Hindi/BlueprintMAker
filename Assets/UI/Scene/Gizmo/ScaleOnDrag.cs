using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ScaleOnDrag : GizmoFunction
{
	[SerializeField]
	private bool horizontal;
	[SerializeField]
	private bool vertical;

	private Vector3 initialScale;

	public override void OnDrag(PointerEventData data)
	{
		base.OnDrag(data);
		float scale = (data.delta.x + data.delta.y) / 100;
		
		Vector3 scaleModifier = transform.position;
		scaleModifier.x = (horizontal ? scale : 0);
		scaleModifier.y = (vertical ? scale : 0);

		gizmo.notifyScale(scaleModifier);
	}
	
	public override void OnBeginDrag(PointerEventData data)
	{
		base.OnBeginDrag(data);
		initialScale = gizmo.CurrentTarget.transform.localScale;
	}
	
	public override void OnEndDrag(PointerEventData data)
	{
		base.OnEndDrag(data);
		UndoSystem.registerScaleAction(initialScale, gizmo.CurrentTarget);
	}
}
