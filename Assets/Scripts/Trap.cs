using UnityEditor;
using UnityEngine;

public class Trap : MonoBehaviour
{

    //[SerializeField] Animation anim;
    void Start()
    {
        //if (!anim)
        //    return;
        //anim[anim.GetComponent<Animation>()].speed= Random.Range(0, 10);
    }
    private void OnTriggerStay(Collider colider)
    {
        if (colider.CompareTag("Character"))
        {
            //var character = colider.GetComponent<Character>();
        }
    }
}
