using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FihishPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("Character"))
        {
            GameController.instance.FinishGame();
        }
    }

    private void OnTriggerExit(Collider colider)
    {
        if (colider.CompareTag("Character"))
        {
            GameController.instance.EndGame();
        }
    }
}
 