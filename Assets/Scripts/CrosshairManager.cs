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
            crosshairImage.material.color = colorDefault;
        }

    }
    public void SetAim()
    {
        if (crosshairActive)
        {
            crosshairImage.material.color = colorAim;
        }

    }


}
