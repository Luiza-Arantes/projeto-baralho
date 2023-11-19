using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressionSpriteSwitcher : MonoBehaviour
{
	public string eventId;
	public List<Sprite> sprites;
	public Sprite defaultSprite;
	public Image image;

	void OnEnable()
	{
		UpdateSprite();
	}

	public void UpdateSprite()
	{
		int value = Progression.GetEventCounter(eventId);
		if(value < sprites.Count)
		{
			image.sprite = sprites[value];
		}
		else
		{
			image.sprite = defaultSprite;
		}
	}
}