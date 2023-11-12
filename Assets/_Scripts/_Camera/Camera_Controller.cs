using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Data.Common;
using Unity.VisualScripting;
using System;

public class Camera_Controller : MonoBehaviour
{
    public Camera_Controller Instance;
    [SerializeField] public CinemachineVirtualCamera cinemachineVirtualCamera;
    private const float MIN_FOLLOW_Y_OFFSET = 2f;
    private const float MAX_FOLLOW_Y_OFFSET = 500f;
    public bool follow_Unit;
    public Transform UnitToFollow;
    public int anyKeyTimer;
    float moveSpeed = 10f;
    private float zoomAmount = 10f;


    private void Awake()
    {
        Instance = GetComponent<Camera_Controller>();

    }


    void Update()
    {

        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }


        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
        Vector3 rotationVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = +1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = -1f;
        }
        float rotationSpeed = 100f;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;




        CinemachineTransposer cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        Vector3 followOffset = cinemachineTransposer.m_FollowOffset;
        if (Input.mouseScrollDelta.y > 0)
        {
            followOffset.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            followOffset.y += zoomAmount;
        }
        followOffset.y = Mathf.Clamp(followOffset.y, MIN_FOLLOW_Y_OFFSET, MAX_FOLLOW_Y_OFFSET);
        cinemachineTransposer.m_FollowOffset = followOffset;

        if (follow_Unit)
        {
            FollowUnit(UnitToFollow);
        }

    }


    public void FollowUnit(Transform _followUnit)
    {
        UnitToFollow = _followUnit;
        follow_Unit = true;
        Instance.transform.position = _followUnit.position;
        cinemachineVirtualCamera.Follow = UnitToFollow;
        cinemachineVirtualCamera.LookAt = UnitToFollow;


        if (Input.anyKey)
        {

            anyKeyTimer++;
            if (anyKeyTimer >= 5)
            {
                anyKeyTimer = 0;
                follow_Unit = false;
                cinemachineVirtualCamera.Follow = Instance.transform;
                cinemachineVirtualCamera.LookAt = Instance.transform;
            }

        }
        else
        {
            anyKeyTimer = 0;
        }
    }
}



