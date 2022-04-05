using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update

    private int state;
    private Color colorOfTrafficLight;

    private float timeBeforeSwitch;
    private float timer;


    private static Dictionary<int, Color> _colors = new Dictionary<int, Color>();
    private static Dictionary<int, float> _timeForPhase = new Dictionary<int, float>();

    void Start()
    {
        InitColors();
        InitPhases();

        _timeForPhase.TryGetValue(state, out timeBeforeSwitch);
        _colors.TryGetValue(state, out colorOfTrafficLight);

        ColorThisObject(colorOfTrafficLight);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > timeBeforeSwitch)
        {
            timer = 0;
            SwitchState();
            ColorThisObject(colorOfTrafficLight);

        }
    }

    private void SwitchState()
    {
        state++;

        if (state > _colors.Count)
        {
            state = 0;
        }

        colorOfTrafficLight = _colors[state];
        timeBeforeSwitch = _timeForPhase[state];
    }



    private void ColorThisObject(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    private void InitPhases()
    {
        _timeForPhase.Add(0, 5);
        _timeForPhase.Add(1, 1);
        _timeForPhase.Add(2, 5);
        _timeForPhase.Add(3, 2);
    }

    private void InitColors()
    {
        _colors.Add(0, new Color(255, 0, 0));
        _colors.Add(1, new Color(255, 255 / 2, 0));
        _colors.Add(2, new Color(0, 255, 0));
        _colors.Add(3, new Color(255, 255, 0));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (state == 0)
        {
            Debug.Log("Not allowed!");
        }
        else if (state == 2)
        {
            Debug.Log("No problem!");
        }
    }

}
