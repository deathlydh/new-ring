using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem.XR;
using System.Linq;
using UnityEngine.XR.OpenXR.Input;
using Unity.VisualScripting;

public class PistolShoot : MonoBehaviour
{
    private Animator animator;
    private XRGrabInteractable interactable;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float damage = 25f;

    void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponentInParent<XRGrabInteractable>();
    }

    void Update()
    {
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue && interactable.isSelected)
            {
                Shoot();
                animator.SetBool("shoot", true);
            }
            else
            {
                animator.SetBool("shoot", false);
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }
            audioSource.Play();
        }
    }
}
