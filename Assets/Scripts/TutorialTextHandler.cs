using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextHandler : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y > GameMaster.instance.screenTopEdge
            || transform.position.y < GameMaster.instance.screenBottomEdge
            || transform.position.x < GameMaster.instance.screenLeftEdge
            || transform.position.x > GameMaster.instance.screenRightEdge)
            Destroy(gameObject);
    }
}