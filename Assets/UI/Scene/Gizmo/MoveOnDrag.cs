using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MoveOnDrag : GizmoFunction
{
	[SerializeField]
	private bool horizontal;
	[SerializeField]
	private bool vertical;

	private Vector3 initialPosition;

	public override void OnDrag(PointerEventData data)
	{
		base.OnDrag(data);
		Vector3 globalMousePos;
		Vector2 nextPos = transform.position;
		Vector2 posAfterDelta = data.position;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle (canvasRect, posAfterDelta, data.pressEventCamera, out globalMousePos)) {
			nextPos.x = (horizontal ? globalMousePos.x + deltaOnClick.x : nextPos.x);
			nextPos.y = (vertical ? globalMousePos.y + deltaOnClick.y : nextPos.y);
		}

		gizmo.notifyTranslation(nextPos);
	}

	public override void OnBeginDrag(PointerEventData data)
	{
		base.OnBeginDrag(data);
		initialPosition = transform.position;
	}

	public override void OnEndDrag(PointerEventData data)
	{
		base.OnEndDrag(data);
		UndoSystem.registerMoveTransformAction (initialPosition, gizmo.CurrentTarget, gizmo.gameObject);
	}
}
