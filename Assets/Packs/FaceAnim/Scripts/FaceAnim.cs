using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
public class FaceAnim : MonoBehaviour
{

    public Transform faceItem;

    public float ratio = 1;

    [Header("Constraint")]
    public bool activeConstraints;
    public float radius = 1;

    [Header("smooth")]
    public bool Lerp = true;
    [FormerlySerializedAs("speed")]
    public float smoothSpeed = 10;

    [Header("use target")]
    public float useTarget_ratio = 0.1f;


    [Header("other")]
    public bool reverce = true;
    public FaceAnim[] subFaces;


    Vector2 beforePos;
    private void FixedUpdate()
    {
        Vector2 direction;
        if (useTarget)
        {
            direction = (Vector2)transform.position - target;
            direction *= -1;
            //add ratio
            direction *= useTarget_ratio;
        }
        else
        {
            direction = (Vector2)transform.position - beforePos;
            //add ratio
            direction *= ratio;

        }
        beforePos = transform.position;



        //normalize
        float size = direction.magnitude;
        direction = direction.normalized;
        //set constraints
        if (activeConstraints)
        {
            size = Mathf.Clamp(size, 0, radius);
        }
        direction *= size;



        Vector3 newPos = transform.position - ((Vector3)direction * (reverce ? -1 : 1));
        faceItem.position = Lerp ? Vector3.Lerp(faceItem.position, newPos, smoothSpeed * Time.deltaTime) : newPos;



    }

    bool _useTarget;
    public bool useTarget
    {
        get { return _useTarget; }
        set
        {
            _useTarget = value;
            foreach (FaceAnim f in subFaces)
                f.useTarget = value;
        }
    }
    Vector2 _target;
    public Vector2 target
    {
        get
        {
            return _target;
        }
        set
        {
            useTarget = true;
            _target = value;
            foreach (FaceAnim f in subFaces)
                f.target = value;
        }
    }


}
