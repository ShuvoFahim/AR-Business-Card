using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class ARButtonController : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject ContactButton;
    public GameObject InformationObject;
    public GameObject VideoPlayObject;
    public GameObject BGAudio;
    public GameObject BGcontact;

    public GameObject BioAudio;

    public GameObject NSULogo;

    private Animator ContactAnim;
    private Animator InformationAnim;
    private AudioSource BGAudioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        VirtualButtonBehaviour[] ARButton = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < ARButton.Length; i++) {

            ARButton[i].RegisterEventHandler(this);

        }

        ContactButton.SetActive(false);
        InformationObject.SetActive(false);
        VideoPlayObject.SetActive(false);
        BioAudio.SetActive(false);
        BGcontact.SetActive(false);


        BGAudioSource = BGAudio.GetComponent<AudioSource>();
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

            VideoPlayObject.SetActive(false);

            NSULogo.SetActive(true);

            BGAudio.SetActive(false);

            BGcontact.SetActive(false);
            StartCoroutine(DelayBiosoound());
        }
        else if (vb.VirtualButtonName == "Contact")
        {
            ContactButton.SetActive(true);
            ContactAnim.SetTrigger("OPEN");

            InformationAnim.SetTrigger("CLOSE INFO");
            StartCoroutine(MakeFalseObject(InformationObject));

            VideoPlayObject.SetActive(false);

            NSULogo.SetActive(true);

            BGAudio.SetActive(false);
            BioAudio.SetActive(false);

            StartCoroutine(Delaycontactsound());
        }
        else if (vb.VirtualButtonName == "Video") {

            VideoPlayObject.SetActive(true);

            ContactAnim.SetTrigger("CLOSE");
            StartCoroutine(MakeFalseObject(ContactButton));

            InformationAnim.SetTrigger("CLOSE INFO");
            StartCoroutine(MakeFalseObject(InformationObject));

            NSULogo.SetActive(false);
            BGAudio.SetActive(false);
            BioAudio.SetActive(false);
            BGcontact.SetActive(false);
        }
    }


    IEnumerator MakeFalseObject(GameObject x)
    {
        
        yield return new WaitForSeconds(2.5f);

        x.SetActive(false);
       

    }

    IEnumerator DelayBiosoound()
    {

        yield return new WaitForSeconds(2.5f);
        BioAudio.SetActive(true);



    }

    IEnumerator Delaycontactsound()
    {

        yield return new WaitForSeconds(2.5f);
        BGcontact.SetActive(true);



    }



    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
