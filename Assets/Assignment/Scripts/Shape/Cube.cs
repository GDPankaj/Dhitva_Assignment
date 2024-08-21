using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IShape
{
    [SerializeField] int _points;
    public int points { get; set; }

    private void Start()
    {
        points = _points; // Example value
        GameManager.Instance.RegisterShape(this);
    }

    public void OnCollected()
    { 
        GameManager.Instance.ShapeCollected?.Invoke(points);
        GameManager.Instance.UnregisterShape(this);
        Destroy(gameObject); // Destroy the shape after collection
        
    }

}
