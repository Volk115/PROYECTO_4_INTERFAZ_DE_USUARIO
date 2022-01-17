using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIFICULTY_BUTTON : MonoBehaviour
{
    private Button button;
    private GameManager gameManagerScriot;
    [SerializesField] private int difficulty;

    void Start()
    {
        button = GetComponent<Button>();
        button.oneClick.AddLisener(SetDifficulty);
    }
    
    private void SetDifficulty()
    {
        
    }
}
