using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private DrivingEngine drivableCar;

    [SerializeField]
    private float pressedTime = 0;

    [SerializeField]
    private Text displaySpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.W].isPressed)
        {
            pressedTime += Time.deltaTime;
            drivableCar.Accelerate(pressedTime);
        } else if (Keyboard.current[Key.S].isPressed)
        {
            pressedTime += Time.deltaTime;
            drivableCar.Brake(pressedTime);
        }
        else
        {
            pressedTime = 0;
        }

        displaySpeed.text = drivableCar.Rb.velocity.z.ToString();

    }
}
