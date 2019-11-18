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

        ContactButton.SetActive(false);
        InformationObject.SetActive(false);

        ContactAnim = ContactButton.GetComponent<Animator>();
        InformationAnim = InformationObject.GetComponent<Animator>();
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "Introduction")
        {
            InformationObject.SetActive(true);
            InformationAnim.SetTrigger("OPEN INFO");

            ContactAnim.SetTrigger("CLOSE");
            StartCoroutine(MakeFalseObject(ContactButton));

        }
        else if (vb.VirtualButtonName == "Contact")
        {
            ContactButton.SetActive(true);
            ContactAnim.SetTrigger("OPEN");

            InformationAnim.SetTrigger("CLOSE INFO");
            StartCoroutine(MakeFalseObject(InformationObject));
        }
        else if (vb.VirtualButtonName == "Video") {

        }
    }


    IEnumerator MakeFalseObject(GameObject x)
    {
        
        yield return new WaitForSeconds(2.5f);

        x.SetActive(false);
       

    }


    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
