using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightAnimation : MonoBehaviour
{
    [SerializeField] private  float minIntensity = 0.5f;
    [SerializeField] private  float maxIntensity = 1.5f;
    [SerializeField] private  float animationDuration = 2f;
    [SerializeField] private Light2D spotLight;
    private float _currentIntensity;
    private bool _isAnimating = true;
    private float _timer;

    private void Awake()
    {
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