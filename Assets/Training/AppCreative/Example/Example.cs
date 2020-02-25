using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using AppCreate.Localisation;

public class Example : MonoBehaviour
{
    private bool on = false;

    private void Start()
    {
        Click();
    }

    public void Click()
    {
        Text comp = transform.GetChild(0).GetComponent<Text>();

        if (on)
        {
            on = false;
            comp.text = LocalisationManager.instance.GetLocalisedValue("1_MainMenu_SwitchOff");
        }
        else
        {
            on = true;
            comp.text = LocalisationManager.instance.GetLocalisedValue("1_MainMenu_SwitchON");
        }
    }
}
