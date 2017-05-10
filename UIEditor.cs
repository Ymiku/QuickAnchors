using System.Collections;
using UnityEditor;

public class UIEditor{

	[MenuItem("CONTEXT/RectTransform/SetAnchors")]
	private static void SetAnchors(MenuCommand mc)
	{
		Vector2 res = GetMainGameViewSize ();
		float w = res.x;
		float h = res.y;
		float minX = 0f;
		float minY = 0f;
		float maxX = 0f;
		float maxY = 0f;
		RectTransform trans = mc.context as RectTransform;
		RectTransform parent = trans.parent.GetComponent<RectTransform> ();
		if (parent != null) {
			w = parent.rect.width;
			h = parent.rect.height;
		}
		minX = trans.anchoredPosition.x - trans.rect.width / 2f;
		minY = trans.anchoredPosition.y - trans.rect.height / 2f;
		maxX = trans.anchoredPosition.x + trans.rect.width / 2f;
		maxY = trans.anchoredPosition.y + trans.rect.height / 2f;
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
