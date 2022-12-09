using System;
using System.Globalization;
using UnityEngine;

public class DebugCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var culture = new CultureInfo("fi-FI");

        NotificationManager
        notificationManager = GameObject.Find("Notification Manager").GetComponent<NotificationManager>();
        notificationManager.ShowNotification("DEBUG notification: Welcome to FPS Template 2022 (" + DateTime.Now.ToString(culture) + ")");
    }


}
