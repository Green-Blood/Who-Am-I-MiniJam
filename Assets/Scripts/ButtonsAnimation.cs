using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem hubParticles;
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

      
    }

   
    }