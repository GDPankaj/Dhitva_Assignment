using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShape
{
    public int points { get; set; }

    public void OnCollected();
}
