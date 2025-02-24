using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using static Unity.Burst.Intrinsics.Arm;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private int AmmoCountMax = 30;
    [SerializeField] private int AmmoCountActual = 30;
    [SerializeField] public GameObject AmmoStaker;
    [SerializeField] private XRGrabInteractable interactable;

    public bool IsCanShoot()
    {
        if (AmmoCountActual > 0)
        {
            AmmoCountActual -= 1;
            return true;
        }
        return false;
    }
    public void UnConnect()
    {
        GetComponent<Rigidbody>().useGravity = true;
        //transform.SetParent(AmmoStaker.transform);
        gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    public void Connect(GameObject obj)
    {
        GetComponent<Rigidbody>().useGravity = false;
        //transform.SetParent(obj.transform);
        gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
    private void Start()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
