using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ButtonsAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem hubParticles;
    [SerializeField] private Light2D spotLight;
    [SerializeField] private Image colorImage;
    [SerializeField] private Image innerVortexImage;
    [SerializeField] private Image outerParticleImage;
    [SerializeField] private Image outLineImage;
    [SerializeField] private Image innerParticleImage;

    [SerializeField] private float colorImageRotationDuration = 2f;
    [SerializeField] private float innerVortexRotationDuration = 2.5f;
    [SerializeField] private float outerParticleRotationDuration = 3.25f;
    [SerializeField] private float outLineImageRotationDuration = 3.75f;
    [SerializeField] private float innerParticleRotationDuration = 4.25f;

    [SerializeField] private  float minIntensity = 0.5f;
    [SerializeField] private  float maxIntensity = 1.5f;
    [SerializeField] private  float animationDuration = 2f;

    private float _currentIntensity;
    private bool _isAnimating = true;
    private float _timer;
    

    private void Awake()
    {
        colorImage.transform.DORotate(new Vector3(0f, 0f, 360f),
                colorImageRotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1);
        innerVortexImage.transform
            .DORotate(new Vector3(0f, 0f, 360f), innerVortexRotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1);
        outerParticleImage.transform
            .DORotate(new Vector3(0f, 0f, 360f), outerParticleRotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1);
        innerParticleImage.transform
            .DORotate(new Vector3(0f, 0f, 360f), innerParticleRotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1);
        outLineImage.transform
            .DORotate(new Vector3(0f, 0f, 360f), outLineImageRotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1);

        _currentIntensity = maxIntensity;
    }

    private void Update()
    {
        if (_isAnimating)
        {
            // Increment the timer based on the elapsed time since the animation started
            _timer += Time.deltaTime;

            // Calculate the interpolation value between the minimum and maximum intensities
            float t = Mathf.PingPong(_timer / animationDuration, 1f);
            _currentIntensity = Mathf.Lerp(minIntensity, maxIntensity, t);

            // Update the light intensity
            spotLight.intensity = _currentIntensity;
        }
    }
    public void ToggleAnimation()
    {
        _isAnimating = !_isAnimating;

        if (_isAnimating)
        {
            // Reset the timer when starting the animation
            _timer = 0f;
        }
    }
}