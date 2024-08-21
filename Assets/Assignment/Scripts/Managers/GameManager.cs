using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent<int> ShapeCollected;
    public UnityEvent AllShapesCollected;

    List<IShape> ShapesPresent = new List<IShape>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (ShapeCollected == null)
        {
            ShapeCollected = new UnityEvent<int>();
        }
        
        if (AllShapesCollected == null)
        {
            AllShapesCollected = new UnityEvent();
        }
    }

    public void RegisterShape(IShape shape)
    {
        ShapesPresent.Add(shape);
    }

    public void UnregisterShape(IShape shape)
    {
        ShapesPresent.Remove(shape);

        if(ShapesPresent.Count == 0)
        {
            AllShapesCollected?.Invoke();
        }
    }


    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
