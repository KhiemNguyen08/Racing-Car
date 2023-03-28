using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottomlimit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(COnst.OBSTACLE_TAG))
        {
            Destroy(col.gameObject);
        }
    }
}
