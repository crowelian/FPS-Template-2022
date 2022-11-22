using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    // TODO not gonna work fix this
    public KeyCode toggleAttachment1 = KeyCode.K;

    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
