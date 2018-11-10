using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    int cameraPosition;
    Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
    }


    public void NextCamera(){
        cameraPosition = cameraPosition < 2 ? cameraPosition + 1 : 0;
        UpdateCamera();
    }

    public void PrevCamera(){
        cameraPosition = cameraPosition > 0 ? cameraPosition - 1 : 2;
        UpdateCamera();
    }

    void UpdateCamera(){
        anim.SetInteger("Position", cameraPosition);
    }

}
