using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableGenerator : MonoBehaviour
{
    public GameObject hittableObject;
    public float xRange = 5f;
    public float yRange = 5f;
    public float zDistance = 5f;
    public float frequency = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateOverTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator GenerateOverTime() {
        while(true) {
            Instantiate(hittableObject, new Vector3(Random.RandomRange(-xRange, xRange), Random.RandomRange(-yRange, yRange), zDistance), Quaternion.identity);
            yield return new WaitForSeconds(1f / frequency);
        }
    }
}
