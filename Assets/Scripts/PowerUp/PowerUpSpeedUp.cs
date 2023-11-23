using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("Power Up Speed Up")]
    public float amountToSpeed;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeeUp(amountToSpeed);
        PlayerController.Instance.SetPowerUpText("Speed Up");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("Slow Down");
    }

}
