using UnityEngine;

public abstract class InterectBoost : MonoBehaviour
{
    protected abstract void Interect(Character character);

    void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("Character"))
        {
            Character character = colider.GetComponent<Character>();
            Interect(character);
        }
    }
}
