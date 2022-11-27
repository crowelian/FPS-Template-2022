using UnityEngine;

public class GraphicalSettings : MonoBehaviour
{

    public static GraphicalSettings Instance;
    string[] graphicQualityNames;

    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
    }

    void Start()
    {
        graphicQualityNames = QualitySettings.names;
    }

    public void EnableFog()
    {
        RenderSettings.fog = true;
    }
    public void DisableFog()
    {
        RenderSettings.fog = false;
    }

    public void SetGraphicsQuality(string name)
    {

        for (int i = 0; i < graphicQualityNames.Length; i++)
        {
            if (graphicQualityNames[i] == name)
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }
    }

}
