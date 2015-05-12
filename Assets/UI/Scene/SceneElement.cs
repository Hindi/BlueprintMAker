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

        rectTransform = transform as RectTransform;
        rectTransform.sizeDelta = new Vector2(image.sprite.texture.width, image.sprite.texture.height) * displayFactor;
        getSave();
	}

    public string getSave()
    {
        Vector2 position = rectTransform.position;
        Quaternion rot = transform.rotation;
        string json = "{\n\t\t image : " + image.sprite.name;
        json += ",\n\t\t rect : { x : " + position.x + ", y : " + position.y;
        json += ", w : " + rectTransform.localScale.x + ", h : " + rectTransform.localScale.y + "}";
        json += ",\n\t\t rotation : { w : " + rot.w + ", x :  " + rot.x + ", y : " + rot.y + " , z : " + rot.z + " }" + "\n}";
        return json;
    }
}
