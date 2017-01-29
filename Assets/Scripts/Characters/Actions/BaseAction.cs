using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    protected Character Character;
    public int ActivateOn;

    public void SetCharacter(Character character)
    {
        this.Character = character;
    }

    public abstract void DoAction();
    public abstract void StopAction();
}
