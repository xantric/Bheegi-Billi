using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{

    public UnityEngine.Rendering.Volume globalPostProcessingVolume;
    public float changeSpeed = 1.0f;

    private UnityEngine.Rendering.Universal.Bloom bloom;
    private UnityEngine.Rendering.Universal.Vignette vignette;
    private UnityEngine.Rendering.Universal.MotionBlur motionBlur;

    private void Start()
    {
        // Check if a global volume is assigned
        if (globalPostProcessingVolume == null)
        {
            Debug.LogError("Global Post Processing Volume is not assigned!");
            return;
        }

        // Get the specific effects you want to control
        if (!globalPostProcessingVolume.profile.TryGetSettings(out bloom))
        {
            Debug.LogError("Bloom effect not found in the Global Post Processing Volume!");
        }

        if (!globalPostProcessingVolume.profile.TryGetSettings(out vignette))
        {
            Debug.LogError("Vignette effect not found in the Global Post Processing Volume!");
        }

        if (!globalPostProcessingVolume.profile.TryGetSettings(out motionBlur))
        {
            Debug.LogError("Motion Blur effect not found in the Global Post Processing Volume!");
        }
    }

    private void Update()
    {
        // Check if the effects are available
        if (bloom == null || vignette == null || motionBlur == null)
        {
            Debug.LogError("One or more post-processing effects not found in the Global Post Processing Volume!");
            return;
        }

        // Adjust the intensities over time
        float time = Time.time * changeSpeed;

        bloom.intensity.value = Mathf.PingPong(time, 5.0f);
        vignette.intensity.value = Mathf.PingPong(time, 1.0f);
        // Remove Contrast by setting its intensity to 0 (assuming it has an intensity property)
        // contrast.intensity.value = 0.0f;
        motionBlur.shutterAngle.value = Mathf.PingPong(time, 360.0f);
    }
}

