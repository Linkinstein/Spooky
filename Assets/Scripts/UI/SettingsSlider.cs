using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    [SerializeField] private PostProcessVolume v;
    [SerializeField] private MovementControls mc;

    private AutoExposure aE;

    private void OnEnable()
    {
        v.profile.TryGetSettings(out aE);
    }

    public void ChangeMSensitivity(float i)
    {
        mc.lookSpeed = i / 10f;
    }

    public void ChangeBrightness(float i)
    {
        float lumiChange = 3f - ((i*2)/10f);
        aE.minLuminance.value = lumiChange;
    }
}
