using UnityEngine;
using UnityEngine.UI;

public class DayNightSpriteSwitcher : MonoBehaviour
{
	public delegate void OnSwitchDayNightHandler();
	public static event OnSwitchDayNightHandler onSwitchDayNight;
	static bool _isDay = false;
	public static bool isDay
	{
		get
		{
			return _isDay;
		}
		set
		{
			_isDay = value;
			onSwitchDayNight.Invoke();
		}
	}
	public Sprite daySprite;
	public Sprite nightSprite;
	public Image image;


	private void OnEnable()
	{
		onSwitchDayNight += UpdateSprite;
		UpdateSprite();
	}
	private void OnDisable()
	{
		onSwitchDayNight -= UpdateSprite;
	}

	void UpdateSprite()
	{
		if (isDay)
		{
			image.sprite = daySprite;
		}
		else
		{
			image.sprite = nightSprite;
		}
	}
}