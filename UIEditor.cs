using UnityEngine;
using System.Collections;
using UnityEditor;

public class UIEditor{

	[MenuItem("CONTEXT/RectTransform/SetAnchors")]
	private static void SetAnchors(MenuCommand mc)
	{
		RectTransform trans = mc.context as RectTransform;
		RectTransform parent = null;
		try {
			parent = trans.parent.GetComponent<RectTransform> ();
		} catch (System.Exception ex) {
			Debug.Log ("不能在Canvas上操作！");
			return;
		}
		float w = parent.rect.width;
		float h = parent.rect.height;
		float minX = trans.anchoredPosition.x - trans.rect.width / 2f;
		float minY = trans.anchoredPosition.y - trans.rect.height / 2f;
		float maxX = trans.anchoredPosition.x + trans.rect.width / 2f;
		float maxY = trans.anchoredPosition.y + trans.rect.height / 2f;
		minX /= w;
		minX += 0.5f;
		minY /= h;
		minY += 0.5f;
		maxX /= w;
		maxX += 0.5f;
		maxY /= h;
		maxY += 0.5f;

		trans.anchorMax = new Vector2 (maxX,maxY);
		trans.anchorMin = new Vector2 (minX,minY);
		trans.anchorMax = new Vector2 (maxX,maxY);

		trans.offsetMin = Vector2.zero;
		trans.offsetMax = Vector2.zero;
	}
	public static Vector2 GetMainGameViewSize()
	{
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetSizeOfMainGameView.Invoke(null,null);
		return (Vector2)Res;
	}
} 
