using UnityEngine;
using System.Collections;

public class PopupLateralPanel : MonoBehaviour 
{
	[SerializeField]
	private GameObject inImage;
	[SerializeField]
	private GameObject outImage;
	[SerializeField]
	private RectTransform buttonRect;
	[SerializeField]
	private Canvas canvas;

	private RectTransform panelRect;
	
	private Vector2 outPosition;
	private Vector2 inPosition;
	private bool poppingOut;
	private bool poppedOut;
	
	// Use this for initialization
	void Start()
	{
		panelRect = GetComponent<RectTransform> ();
		inPosition = panelRect.position;
		outPosition = panelRect.position;
		outPosition.x += ((panelRect.rect.width - buttonRect.rect.width) * canvas.GetComponent<RectTransform>().localScale.x);
	}
	
	public void fromUiPopup(bool popIn)
	{
		if (!popIn && !poppedOut)
			return;
		popUp();
	}

	private void toggleIcon()
	{
		if (inImage != null && outImage != null) {
			inImage.SetActive((poppingOut));
			outImage.SetActive((!poppingOut));
		}
	}
	
	public void popUp()
	{
		if (poppingOut)
		{
			poppingOut = !poppingOut;
			StartCoroutine(slideInCoroutine());
		}
		else
		{
			poppingOut = !poppingOut;
			StartCoroutine(slideOutCoroutine());
		}
		toggleIcon();
	}
	
	IEnumerator slideInCoroutine()
	{
		while (!poppingOut && Vector2.Distance(panelRect.anchoredPosition, inPosition) > 0.1f)
		{
			panelRect.position = Vector3.Lerp(panelRect.position, inPosition, 10 * Time.deltaTime);
			yield return null;
		}
	}
	
	IEnumerator slideOutCoroutine()
	{
		while (poppingOut)
		{
			panelRect.position = Vector3.Lerp(panelRect.position, outPosition, 10 * Time.deltaTime);
			if (Vector2.Distance(panelRect.position, outPosition) < 0.1f)
			{
				poppedOut = true;
				break;
			}
			yield return null;
		}
	}
}
