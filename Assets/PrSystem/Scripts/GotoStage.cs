using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoStage : MonoBehaviour
    {
        public void GoButtonClick()
        {
            GameManager.instance.GameStart1();
        }
    }