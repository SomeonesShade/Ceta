using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_InstanceCounter : MonoBehaviour
{
    public int PlayerAmount,
        YellowAmount,
        SquareAmount,
        PentagonAmount,
        BossAmount;
    public ref int IntToAmount(int type)
    {
        switch (type)
        {
            case 0:
                return ref this.PlayerAmount;
            case 1:
                return ref this.YellowAmount;
            case 2:
                return ref this.SquareAmount;
            case 3:
                return ref this.PentagonAmount;
            case 4:
                return ref this.BossAmount;
            default:
                return ref this.PlayerAmount;
        }
    }
}
