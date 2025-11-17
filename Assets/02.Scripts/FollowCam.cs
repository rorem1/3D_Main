using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;


    void Update()
    {
        
        Camera1(camera1);
        Camera2(camera2);

    }
    private void Camera1(GameObject cam)
    {
        
        transform.position = target.position + offset;
        
    }
    private void Camera2(GameObject cam)
    {
        transform.position = target.position + offset;
        //transform.LookAt(target);
    }

}
