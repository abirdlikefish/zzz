using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerCommand : ICommand
{
    Enums.EPlayerCommand ePlayerCommand { get; set; }
    Vector3 direction{ get; set; }
}
