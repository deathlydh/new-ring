using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VisibilityTeleportController : MonoBehaviour
{
    [SerializeField]
    private GameObject lController, rController;
    [SerializeField]
    private InputActionProperty left, right;
    [SerializeField]
    private Animator lAnimator;
    [SerializeField]
    private InputActionProperty ltrigger, lcuroc;
    [SerializeField]
    private Animator rAnimator;
    [SerializeField]
    private InputActionProperty rtrigger, rcuroc;
    [SerializeField]
    private XRRayInteractor XRright, XRleft;

    public bool GetIsTeleport()
    {
        return isTeleport;
    }
    public void SetIsTeleport(bool value)
    {
        isTeleport = value;
    }
    public bool isTeleport;

    void Update()
    {
        if (isTeleport)
        {
            lController.SetActive(left.action.ReadValue<Vector2>().y > .1f);
            rController.SetActive(right.action.ReadValue<Vector2>().y > .1f);
        }
        
        float l1 = ltrigger.action.ReadValue<float>();
        float l2 = lcuroc.action.ReadValue<float>();
        lAnimator.SetFloat("triger", l1);
        lAnimator.SetFloat("curoc", l2);

        float r1 = rtrigger.action.ReadValue<float>();
        float r2 = rcuroc.action.ReadValue<float>();
        rAnimator.SetFloat("triger", r1);
        rAnimator.SetFloat("curoc", r2);
        
        lController.SetActive(!(XRleft.selectTarget!=null));
    }
}
