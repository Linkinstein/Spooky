using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    [SerializeField] private PostProcessProfile pp;
    [SerializeField] private MovementControls mc;

    private AutoExposure aE;

    private void OnEnable()
    {
        pp.TryGetSettings(out aE);
    }

    public void ChangeMSensitivity(float i)
    {
        mc.lookSpeed = i / 10f;
    }

    public void ChangeBrightness(float i)
    {
        float brightness = 0.5f + (i/10f);
        aE.keyValue.value = brightness;
    }
}
