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
    [SerializeField]
    private bool IsShoot = false;
    private List<InputDevice> inputDevices = new List<InputDevice>();
    private XRGrabInteractable interactable;
    [SerializeField]
    private GameObject point;
    [SerializeField]
    private AudioSource audioSource;
    public void Shoot(){
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Instantiate(point, hit.point, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation);
            audioSource.Play();
        }
        else

        Debug.Log("buh");
    }
    void Start()
    {
        animator = this.gameObject.transform.GetComponent<Animator>();
        interactable = this.gameObject.GetComponentInParent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        var inputDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            bool triggerValue;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue && interactable.isSelected)
            {
                animator.SetBool("shoot", true);
            }
            else
            {
                animator.SetBool("shoot", false);
            }
        }
    }
}
