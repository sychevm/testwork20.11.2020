using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;



    public float speedMultuplier = 1f;
    public float finishTapMultuplier = 0.25f;
    private float _powerSliderFinish;

    [SerializeField] private Character character;

    private TouchControll _touch;

     bool _start ;
     bool _finish;
     bool _end;

    private int _coin = 0;

    private float _currentDist = 0;
    private float _summDist = 0;
    private float lastDist = 0;
    private float _distance = 0;


    public static System.Action<int> ScoreEventHandler;
    public static System.Action<float> PowerEventHandler;
    public static System.Action<float> DistanceEventHandler;

    [SerializeField]
    private List<Transform> checkPoints;

    public float PowerSliderFinish
    {
        get => _powerSliderFinish;
        private set
        {
            _powerSliderFinish = value;
            PowerEventHandler(_powerSliderFinish);
        }
    }
    private int Coin
    {
        get => _coin;
        set
        {
            _coin = value;
            ScoreEventHandler?.Invoke(_coin);
        }
    }

    private void Awake()
    {
        instance = this;
        _touch = GetComponent<TouchControll>();

        global::Coin.interect += PickDiamond;
    }
    void Start()
    {
        GetDistance();
    }


    private void OnDestroy()
    {
        global::Coin.interect -= PickDiamond;
    }

    void Update()
    {
        if (_end) return;

        if (!_start) return;

        if (_finish)
        {
            PowerSliderFinish -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PowerSliderFinish += finishTapMultuplier;
            }
            PowerSliderFinish = Mathf.Clamp(PowerSliderFinish, 0, 2.5f);
            return;
        }
        UpdateDistance();
    }

    private void GetDistance()
    {
        _distance = 0;
        Vector3 firstPoint = character.transform.position;
        Vector3 secondPoint;

        for (int i = 0; i < checkPoints.Count; i++)
        {
            secondPoint = checkPoints[i].position;
            _distance += Vector3.Distance(firstPoint, secondPoint);
            if (i == 0)
                _currentDist = _distance;
            firstPoint = secondPoint;
        }
        lastDist = _currentDist;
    }

    private void UpdateDistance()
    {
        Vector3 playerPosition = character.transform.position;
        _currentDist = Vector3.Distance(playerPosition, checkPoints.First().position);
        float sliderValue = (lastDist - _currentDist) + _summDist;
        DistanceEventHandler(sliderValue / _distance);
    }

    public Transform GetNewDistance()
    {
        Vector3 firstPoint = checkPoints.First().position;
        checkPoints.Remove(checkPoints.First());
        _currentDist = Vector3.Distance(firstPoint, checkPoints.First().position);
        _summDist += lastDist;
        lastDist = _currentDist;

        return checkPoints.First();
    }

    private void PickDiamond()
    {
        Coin++;
    }

    public void FinishGame()
    {
        _touch.enabled = false;
        _finish = true;
    }
    public void StartGame()
    {
        Coin = 0;

        _start = true;
        _touch.StartGame();
        character.StartRace();
          
    }

    public void EndGame()
    {
        _end = true;
        character.FinalJump(PowerSliderFinish);
    }
}
