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
    [SerializeField] private GameObject atcPoint;
    [SerializeField] private GameObject atcPs;
    [SerializeField] private float damage = 25f;
    private bool isShoot = false;

    [SerializeField] private ParticleSystem ps;
    [SerializeField] private ParticleSystem postAtcps;
    [SerializeField] private ParticleSystem atcWall;

    void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponentInParent<XRGrabInteractable>();
    }

    void Update()
    {/*
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue && interactable.isSelected)
            {
                Shoot();
                animator.SetBool("shoot", true);
                isShoot = true;
            }
            else
            {
                animator.SetBool("shoot", false);
                isShoot = false;
            }
        }*/
    }

    public void OnShoot()
    {
        Debug.Log("shoot");
        animator.SetBool("shoot", true);
    }

    private void endShoot()
    {
        animator.SetBool("shoot", false);
        postAtcps.Play();
    }
    private void Shoot()
    {
        ps.Play();
        postAtcps.Stop();
        RaycastHit hit;
        if (Physics.Raycast(atcPoint.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Instantiate(atcPs, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(atcWall, hit.point, Quaternion.LookRotation(hit.normal));
            }
            audioSource.Play();
        }
    }
}
