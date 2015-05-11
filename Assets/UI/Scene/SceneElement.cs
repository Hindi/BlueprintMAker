using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneElement : MonoBehaviour 
{
	[SerializeField]
    private Image image;
    [SerializeField]
    private float displayFactor;
    private RectTransform rectTransform;

	public void initialize(Sprite sprite)
	{
        image.sprite = sprite;

        rectTransform = image.transform as RectTransform;
        rectTransform.sizeDelta = new Vector2(image.sprite.texture.width, image.sprite.texture.height) * displayFactor;
	}
}
