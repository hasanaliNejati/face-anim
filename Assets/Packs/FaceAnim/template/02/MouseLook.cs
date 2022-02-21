using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public FaceAnim face;
    

    // Update is called once per frame
    void Update()
    {
        face.target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
