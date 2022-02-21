using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCoin : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().Score++;

            Destroy(gameObject);
        }
    }
}
