using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolShoot : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private bool IsShoot = false;
    // Start is called before the first frame update
    public void Shoot(){
        Debug.Log("buh");
    }
    void Start()
    {
        animator = this.gameObject.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("shoot", IsShoot);
    }
}
