using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.ARFoundation.Samples{
public class Hittable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hit() {
        Destroy(gameObject);
    }
}
}