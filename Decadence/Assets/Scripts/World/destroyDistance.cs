using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDistance : MonoBehaviour
{
    //destroys the distance joint when bullet hits
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Projectile>())
        {
            Destroy(GetComponent<DistanceJoint2D>());
        }
    }
}
