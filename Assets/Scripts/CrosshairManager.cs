using UnityEngine;
using UnityEngine.UI;

public class CrosshairManager : MonoBehaviour
{

    private static CrosshairManager _instance;
    public static CrosshairManager Instance;
    [SerializeField] Image crosshairImage;

    bool crosshairActive = true;

    [SerializeField] Color colorDefault;
    [SerializeField] Color colorAim;

    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
    }

    void Start()
    {
        if (crosshairImage == null) crosshairActive = false;
        SetDefault();
    }

    public void SetDefault()
    {
        if (crosshairActive)
        {
            SetCrosshairColor(colorDefault);
        }

    }
    public void SetAim()
    {
        if (crosshairActive)
        {
            SetCrosshairColor(colorAim);
        }

    }

    public void SetCrosshairVisibility(bool set)
    {
        crosshairActive = set;
        if (crosshairImage) crosshairImage.enabled = set;
    }

    void SetCrosshairColor(Color color)
    {
        if (!crosshairImage)
        {
            return;
        }
        // var crosshairRenderer = crosshairImage.gameObject.GetComponent<Renderer>();
        // crosshairRenderer.material.SetColor("_Color", color);
        crosshairImage.color = color;
    }


}
