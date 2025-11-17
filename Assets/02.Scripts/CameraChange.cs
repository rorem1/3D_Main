using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;

    private bool isCamera = true;

    
    void Start()
    {       
        camera2.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            isCamera = !isCamera;

            camera1.SetActive(isCamera);
            camera2.SetActive(!isCamera);
        }
    }
}
