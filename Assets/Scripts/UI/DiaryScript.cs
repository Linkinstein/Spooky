using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryScript : MonoBehaviour
{
    private void OnEnable()
    {
        if (GameManager.Instance.objectives != null)
        {
            string objText = GameManager.Instance.objectives[GameManager.Instance.objectivesIndex];
            objText = objText.Replace("\\n", "\n");
            GetComponent<TextMeshProUGUI>().SetText(objText);
        }
    }
}
