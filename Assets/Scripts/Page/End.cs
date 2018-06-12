using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour {

	// Use this for initialization
	void Start () {
        #region 返回主菜单
        Button btnReturn = GameObject.Find("CanvasEnd/BtnReturn").GetComponent<Button>();
        btnReturn.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene("Start");
        });
        #endregion
    }

    // Update is called once per frame
    void Update () {
		
	}

}
