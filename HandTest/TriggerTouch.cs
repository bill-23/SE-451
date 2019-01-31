using UnityEngine;
using System.Collections;

public class TriggerTouch : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (other.gameObject.tag == "thumb")       
            Debug.Log("Thumb Touched");

        if (other.gameObject.tag == "index")
            Debug.Log("Index Touched");
    }
}