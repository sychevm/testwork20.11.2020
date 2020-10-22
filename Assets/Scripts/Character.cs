using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float Speed => _speed;
    [SerializeField] private float _speed;
    private float _lastSpeed;

    Rigidbody _rigidbody;
    Animator _animator;

     private float rotate_direction; // true - поворот вправо, false - влево
     private int rotate_specified;

    bool _start;
    bool _rotating;
    bool _rotate;
    bool _end;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (_end) return;
        if (!_start) return;

        transform.position += transform.forward * Speed * Time.deltaTime;

        if (_rotate) return;
        else
        {
            if ((int)UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y != rotate_direction)
            {
                transform.Rotate(Vector3.up * 100f * Time.deltaTime * rotate_specified);
            }
            else _rotate = false;
        }
    }

    public void SetSpeed(float value)
    {
        if (_rotating) return;

        _speed = value;
    }

    public void FinalJump(float power)
    {
        _end = true;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce((transform.forward * 400f + transform.up * 200f) * power);
    }

    [ContextMenu("Start")]
    public void StartRace()
    {
        _animator.SetTrigger("Run");
        _start = true;
    }

    [ContextMenu("Rotate")]
    public void Rotate(bool direction)
    {
        _rotate = true;
        rotate_direction += (direction == true) ? 90 : -90;
        rotate_specified = (direction == true) ? 1 : -1;
        _animator.SetTrigger("Rotate");

        _rotating = false;
        _rotate = !_rotate;
        _lastSpeed = Speed;
        //Speed =15;
    }

    [ContextMenu("RotateByAnimation")]
    public void RotateByAnimation()
    {
        _speed = _lastSpeed;
        _rotating = false;
    }

    IEnumerator Wait(float delay, System.Action OnComplete = null)
    {
        float waitTime = delay;
        while (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
            yield return null;
        }
        OnComplete?.Invoke();
    }
}
