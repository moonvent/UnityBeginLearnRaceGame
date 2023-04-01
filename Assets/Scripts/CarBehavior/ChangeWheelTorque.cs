using System;
using UnityEngine;

namespace CarBehavior
{
    public abstract class ChangeWheelTorque: CarParams
    {
        protected int CurrentGear = 1;

        private const float UsualBrakesPower = 2500f;
        protected void ChangeMotorTorque(float inputPower, Wheel wheel)
        {
            // wheel.collider.motorTorque = inputPower * GearsTorque[CurrentGear];
            
            // wheel.collider.motorTorque = (float)(inputPower * ((enginePower * 2000) 
            //                                                    / (engineRpm * (CurrentGear > -1 ? gearsPower[CurrentGear] : -gearsPower[1]) * 0.95 * 0.5) 
            //                                                    / 2));

            // Debug.Log(Rb.velocity.sqrMagnitude);
            wheel.collider.motorTorque = inputPower != 0 ? GearsSwitch.GetMotorTorqueByCurrentData(Rb.velocity.sqrMagnitude, CurrentGear) : 0f;
        }

        protected void ChangeBrakeTorque(Wheel wheel, float inputPower = UsualBrakesPower) => wheel.collider.brakeTorque = inputPower;
    }
}