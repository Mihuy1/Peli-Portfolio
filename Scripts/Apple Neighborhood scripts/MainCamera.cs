using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform target;

    float tLX, tLY, bRX, bRY;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, tLX, bRX),
            Mathf.Clamp(target.position.y, bRY, tLY),
            transform.position.z
            );
    }
    public void SetBound(GameObject map)
    {
        SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();

        float cameraSize = Camera.main.orthographicSize;

        float aspectRatio = Camera.main.aspect * cameraSize;


        tLX = map.transform.position.x + aspectRatio;
        tLY = map.transform.position.y + cameraSize;


        bRX = map.transform.position.x + config.m_Width - aspectRatio;
        bRY = map.transform.position.y - config.m_Height + cameraSize;
    }
        
}
