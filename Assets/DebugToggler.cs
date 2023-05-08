using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugToggler : MonoBehaviour
{
    GameObject trackables = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trackables == null) {
            trackables = GameObject.Find("Trackables");
        }
    }

    public void toggle() {
        if (trackables != null) {
            trackables.SetActive(!trackables.activeSelf);
        }
    }
}
