using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShoot : MonoBehaviour
{
    public Camera cam;
    public Transform muzzle;
    public ParticleSystem paintParticles;
    public bool mouseSingleClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool click;
        click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);
        if (click){
            Vector3 position = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(position);
            
            paintParticles.transform.position = muzzle.position;
            paintParticles.transform.LookAt(muzzle.position + ray.direction);
            Debug.DrawRay(muzzle.position, ray.direction, Color.red);
            // RaycastHit hit;
            // if (Physics.Raycast(ray, out hit, 100.0f)){
            //     Debug.DrawRay(muzzle.position, hit.point - muzzle.position, Color.red);
                
            // }
            if (!paintParticles.isEmitting)
                paintParticles.Play();
        }
        else {
            paintParticles.Stop();
        }
    }
}
