using UnityEngine;
using TMPro;

public class HelpPanel : MonoBehaviour
{

    [SerializeField] TMP_Text keyCodesText;
    [SerializeField] string infoText;
    [SerializeField] string basicControlsText = "Commands: \nWASD + mouse you know and";

    void Start()
    {
        keyCodesText.text = "";
        if (keyCodesText && InputManager.Instance.KeycodesList.Count > 0)
        {
            keyCodesText.text += infoText + " \n\n";
            keyCodesText.text += basicControlsText + "\n";
            foreach (KeyCodeValuePair keyCode in InputManager.Instance.KeycodesList)
            {
                keyCodesText.text += keyCode.key + " - " + keyCode.value.ToString() + " \n";
            }
        }
    }


}
