using Unity.Cinemachine;
using UnityEngine;


public class ZoomCam : MonoBehaviour
{
    private float targetOrthoSize;
    
    public CinemachineCamera cam;
    GameObject ballTarget;
    Manager manager;
    private Transform[] ballCloneTransform;

    private void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
    }
    void Start()
    {

        if (cam != null)
        {
            cam.Follow = GameObject.FindGameObjectWithTag("Ball").transform;
            Debug.Log("CameraSTARTFOLLOW");
        }
    }

    private void FixedUpdate()
    {
        if (cam != null)
        {
            cam.Follow = GameObject.FindGameObjectWithTag("Ball").transform;
            //Debug.Log("CameraSTARTFOLLOW");
            //targetOrthoSize = CinemachineCamera.m_Lens.OrthographicSize;
        }
    }

    public void CameraFollow()
    {
        cam.LookAt = GameObject.FindGameObjectWithTag("Ball").transform;
        cam.Follow = GameObject.FindGameObjectWithTag("Ball").transform;
        Debug.Log("CameraFOLLOW");
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
