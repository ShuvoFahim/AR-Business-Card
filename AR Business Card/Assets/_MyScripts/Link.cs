using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    public void Facebook() {

        Application.OpenURL("tel:+8801876597531");


    }



    public void SendEmail()
    {
        string email = "fahim.shuvo09@gmail.com";
        string subject = MyEscapeURL(" ");
        string body = MyEscapeURL(" ");
        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }
    string MyEscapeURL(string url)
    {
        return WWW.EscapeURL(url).Replace("+", "%20");
    }
}
