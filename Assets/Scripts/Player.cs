using Managers;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        //Singleton Debug
        GameManager.Instance.Test();
        LevelManager.Instance.Test();
        InputManager.Instance.Test();
        UIManager.Instance.Test();
        AudioManager.Instance.Test();
    }
    
}
