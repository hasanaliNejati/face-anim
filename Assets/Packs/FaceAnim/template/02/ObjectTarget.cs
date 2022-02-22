using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTarget : MonoBehaviour
{
    public FaceAnim[] faceAnims;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        foreach(FaceAnim f in faceAnims)
        {
            if (target)
            {
                f.target = target.position;
            }
            else
            {
                f.target = f.transform.position;
            }
        }
        
    }
}
