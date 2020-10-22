using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControll : MonoBehaviour
{

    public static TouchControll instance;

    public float multiplier = 3f;
    private float m_deltaX;

    [SerializeField]
    private Transform _character;

    public char _currentAxis; //true - x, false -z
    private float _AxisX, _AxisZ;


    private bool m_isStarted = true;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _currentAxis = 'x';
        instance = GetComponent<TouchControll>();
    }

    public void StartGame()
    {
        m_isStarted = true;
    }

    void Update()
    {
        Vector2 touchPos = Camera.main.ScreenToViewportPoint(Input.mousePosition) * 15f;

        if (Input.GetMouseButtonDown(0))
        {
            if (!m_isStarted)
            {
                m_isStarted = true;
                //_character.StartGame();
            }

            if (_currentAxis == 'z')
            {
                m_deltaX = touchPos.x - _character.localPosition.z;
            }
            else if (_currentAxis == 'x')
            {
                m_deltaX = touchPos.x - _character.localPosition.x;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            MovementAlongTheAxis(_currentAxis, touchPos);
        }


    }
    private void MovementAlongTheAxis(char Axis, Vector2 touchPos)
    {
        if (Axis == 'x') 
            {
            _AxisX = touchPos.x - m_deltaX;
            _AxisZ = _character.localPosition.z;
            }
        else if (Axis == 'z')
        {
            _AxisZ = touchPos.x - m_deltaX;
            _AxisX = _character.localPosition.x;
        }
        else return;

        _character.localPosition = new Vector3(_AxisX, _character.localPosition.y, _AxisZ);
    }
}