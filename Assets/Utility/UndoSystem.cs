using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action
{
	public delegate void callback();
	
	public callback undo;
	public callback redo;
}

public static class UndoSystem 
{
	private static LimitedStack<Action> stack= new LimitedStack<Action>(100);
	private static LimitedStack<Action> undoedStack= new LimitedStack<Action>(10);

	public static void registerAction(Action action)
	{
		stack.Push(action);
		undoedStack.Clear();
	}

	public static void undo()
	{
		if (stack.Count == 0)
			return;
		Action lastAction = stack.Pop();
		lastAction.undo();
		undoedStack.Push(lastAction);
	}

	public static void redo()
	{
		if (undoedStack.Count == 0)
			return;
		Action lastAction = undoedStack.Pop();
		lastAction.redo();
		stack.Push(lastAction);
	}

	public static void registerMoveTransformAction(Vector3 intialPosition, params GameObject[] obj)
	{
		Action a = new Action ();
		a.undo = delegate () {
			foreach(GameObject g in obj)
				g.transform.position = intialPosition;
		};
		
		Vector3[] posList = new Vector3[obj.Length];
		for (int i = 0; i < obj.Length; ++i)
			posList[i] = obj[i].transform.position;
		a.redo = delegate () {
			for (int i = 0; i < obj.Length; ++i)
			obj[i].transform.position = posList[i] ;
		};
		registerAction (a);
	}
	
	public static void registerRotateAction(Quaternion initialRotation, GameObject obj)
	{
		Action a = new Action ();
		a.undo = delegate () {
			obj.transform.rotation = initialRotation;
		};
		
		Quaternion rot = obj.transform.rotation;
		a.redo = delegate () {
			obj.transform.rotation = rot;
		};
		registerAction (a);
	}
	
	public static void registerScaleAction(Vector3 initialScale, GameObject obj)
	{
		Action a = new Action ();
		a.undo = delegate () {
			obj.transform.localScale = initialScale;
		};
		
		Vector3 scale = obj.transform.localScale;
		a.redo = delegate () {
			obj.transform.localScale = scale ;
		};
		registerAction (a);
	}

    public static void registerChangeGizmoTargetAction(RectTransform initialTarget, RectTransform newTarget, Gizmo gizmo)
	{
		Action a = new Action ();
		a.undo = delegate () {
            if(initialTarget != null)
                gizmo.moveTo(initialTarget);
		};

        a.redo = delegate()
        {
            if (newTarget != null)
                gizmo.moveTo(newTarget );
		};
		registerAction (a);
	}
	
	public static void registerMoveRectTransformAction(Vector3 initialPosition, RectTransform rt)
	{
		Action a = new Action ();
		a.undo = delegate () {
			rt.anchoredPosition = initialPosition;
		};
		
		Vector3 rectPos = rt.anchoredPosition;
		a.redo = delegate () {
			rt.anchoredPosition = rectPos;
		};
		registerAction (a);
	}
}
