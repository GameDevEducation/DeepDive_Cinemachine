using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MixerCameraController : MonoBehaviour
{
    [SerializeField] AnimationCurve OverviewCameraPriority;
    [SerializeField] AnimationCurve StoryboardAlpha;
    [SerializeField] float CameraBlendTime = 10f;

    CinemachineMixingCamera MixingCamera;
    CinemachineStoryboard MixingCameraStoryboard;
    float CurrentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        MixingCamera = GetComponent<CinemachineMixingCamera>();    
        MixingCameraStoryboard = GetComponent<CinemachineStoryboard>();
    }

    // Update is called once per frame
    void Update()
    {
        // Updating the current time and handle wrap around
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= CameraBlendTime)
            CurrentTime -= CameraBlendTime;

        // update camera weights
        MixingCamera.SetWeight(0, OverviewCameraPriority.Evaluate(CurrentTime / CameraBlendTime));
        MixingCamera.SetWeight(1, 1f - MixingCamera.GetWeight(0));

        // control the storyboard alpha
        MixingCameraStoryboard.m_Alpha = StoryboardAlpha.Evaluate(CurrentTime / CameraBlendTime);
    }
}
