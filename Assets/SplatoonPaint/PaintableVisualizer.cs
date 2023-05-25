using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintableVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject paintablesParent;
    bool isDisplay = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Toggle() {
        isDisplay = !isDisplay;
        Paintable[] paintables = paintablesParent.transform.GetComponentsInChildren<Paintable>();
        for (int i = 0; i <paintables.Length; i++) {
            paintables[i].GetComponent<Renderer>().material.SetColor("_Color", new Color(1f, 1f, 1f, isDisplay? 1f : 0f));
        }
    }
}
