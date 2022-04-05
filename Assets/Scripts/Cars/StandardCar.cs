using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardCar : DrivingEngine
{
    
    public StandardCar() : base(new AnimationCurve(), new AnimationCurve(), "StandardCar", 30)
    {
        
    }
}
