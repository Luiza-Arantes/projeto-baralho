using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    public void Switch()
    {
        DayNightSpriteSwitcher.isDay = !DayNightSpriteSwitcher.isDay;
    }
}
