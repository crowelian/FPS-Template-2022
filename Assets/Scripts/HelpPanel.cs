using UnityEngine;
using TMPro;

public class HelpPanel : MonoBehaviour
{

    [SerializeField] TMP_Text keyCodesText;

    void Start()
    {
        if (keyCodesText && InputManager.Instance.KeycodesList.Count > 0)
        {
            keyCodesText.text = "Commands: \n WASD + mouse you know and \n";
            foreach (KeyCodeValuePair keyCode in InputManager.Instance.KeycodesList)
            {
                keyCodesText.text += keyCode.key + " - " + keyCode.value.ToString() + " \n";
            }
        }
    }


}
