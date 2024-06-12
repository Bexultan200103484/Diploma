using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChangerTutorial : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera[] VirtualCameras;
    public int currentCameraIndex;
    public bool flyMode = false;
    private GameEntryMenu gameEntryMenu;

    void Start()
    {

    }

    void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.E) && currentCameraIndex == 0)
            {
                flyMode = !flyMode;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                flyMode = false;
            }
            if (Input.GetButtonDown("Jump") && !flyMode)
            {
                SwitchCamera();
            }
        
    }

    public void SwitchCamera()
    {
        
            if (currentCameraIndex == 0 || currentCameraIndex == 1)
            {
                VirtualCameras[currentCameraIndex].Priority = 0;
                currentCameraIndex = (currentCameraIndex == 0) ? 1 : 0;
                VirtualCameras[currentCameraIndex].Priority = 1;
            }
            else
            {

                VirtualCameras[currentCameraIndex].Priority = 0;
                currentCameraIndex = 0;
                VirtualCameras[0].Priority = 1;
            }
        
    }
}