using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlatform : MonoBehaviour
{
    bool _active;

    [SerializeField] private bool rotate_left, rotate_right;

    private void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("Character"))
        {
            print("поворот");
            if (_active)
                return;

            _active = true;
            TouchControll setTouch = TouchControll.instance;
            var setRotate = (rotate_right == true) ? true : false; // true - right, left - false

            Character character = colider.GetComponent<Character>();

            setTouch._currentAxis = (rotate_right == true)? 'x':'z';
            character.Rotate(setRotate);
        }
    }
}
