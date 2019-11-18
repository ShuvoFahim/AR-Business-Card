using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ARButtonController : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject ContactButton;
    public GameObject InformationObject;

    private Animator ContactAnim;
    private Animator InformationAnim;

    
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] ARButton = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < ARButton.Length; i++) {

            ARButton[i].RegisterEventHandler(this);

        }
        ContactAnim = ContactButton.GetComponent<Animator>();
        InformationAnim = InformationObject.GetComponent<Animator>();
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "Introduction")
        {
            InformationAnim.SetTrigger("OPEN INFO");

        }
        else if (vb.VirtualButtonName == "Contact")
        {

            ContactAnim.SetTrigger("OPEN");

        }
        else if (vb.VirtualButtonName == "Video") {

        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
