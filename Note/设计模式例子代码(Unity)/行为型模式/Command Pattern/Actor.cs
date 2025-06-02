using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    private Transform actorTransform;

    private void Start()
    {
        actorTransform = GetComponent<Transform>();
    }

    public void Move(Vector3 movementDelta)
    {
        actorTransform.Translate(movementDelta);
    } 
}
