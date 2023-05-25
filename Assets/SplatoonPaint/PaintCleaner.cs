using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintCleaner : MonoBehaviour
{
    public GameObject paintablesParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clean() {
        Paintable[] paintables = paintablesParent.transform.GetComponentsInChildren<Paintable>();
        for (int i = 0; i <paintables.Length; i++) {
            paintables[i].Init();
        }
    }
}
