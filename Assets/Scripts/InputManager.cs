using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyCodeValuePair
{

    public string key;
    public KeyCode value;
    public KeyCodeValuePair(string name, KeyCode keyCode)
    {
        this.key = name;
        this.value = keyCode;
    }
}

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;

    // TODO not gonna work fix this
    public List<KeyCodeValuePair> KeycodesList = new List<KeyCodeValuePair>();

    // TODO fix this!
    public KeyCode toggleAttachmentLeftFront = KeyCode.K;
    public KeyCode toggleAttachmentScope = KeyCode.O;
    public KeyCode toggleAttachmentZoom = KeyCode.Q; // fix this... attachment will have a secondary function or something... 

    public KeyCode use = KeyCode.E;


    void Awake()
    {
        if (Instance != null) { Destroy(this); }
        else Instance = this;

        KeycodesList.Add(new KeyCodeValuePair("toggleAttachmentLeftFront", toggleAttachmentLeftFront));
        KeycodesList.Add(new KeyCodeValuePair("toggleAttachmentScope", toggleAttachmentScope));
        KeycodesList.Add(new KeyCodeValuePair("toggleAttachmentZoom", toggleAttachmentZoom));
        KeycodesList.Add(new KeyCodeValuePair("use", use));
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
