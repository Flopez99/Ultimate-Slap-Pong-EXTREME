using Unity.Cinemachine;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    public float parallaxEffectX;
    public float parallaxEffectY;
    public CinemachineCamera cam;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        float distanceX = cam.transform.position.x * parallaxEffectX;
        float distanceY = cam.transform.position.y * parallaxEffectY;

        transform.position = new Vector3(startPosX + distanceX, startPosY + distanceY, transform.position.z);
    }
}
