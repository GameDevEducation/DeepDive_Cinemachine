using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class OrbitCameraController : MonoBehaviour
{
    [SerializeField] float Speed = 1f;

    CinemachineVirtualCamera OrbitCamera;
    CinemachineTrackedDolly OrbitCameraDolly;

    void Awake()
    {
        OrbitCamera = GetComponent<CinemachineVirtualCamera>();
        OrbitCameraDolly = OrbitCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitCameraDolly.m_PathPosition += Speed * Time.deltaTime;
    }
}
