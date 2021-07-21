using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject pig;

    [SerializeField]
    GameObject grenadePool;
    [SerializeField]
    GameObject touchControl;
    [SerializeField]
    List<Dogs> dogs;
    [SerializeField]
    GameObject bombBtn;
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject soundMgr;

    public int countDogs;

    private void Update()
    {
        if(pig.activeSelf == false)
        {
            Invoke("GameOver", 1.5f);
        }

        if(countDogs == dogs.Count)
        {
            Invoke("GameOver", 1.5f);
        }
    }
    void GameOver()
    {
        grenadePool.gameObject.SetActive(false);
        touchControl.gameObject.SetActive(false);
        bombBtn.gameObject.SetActive(false);

        foreach (var item in dogs)
        {
            item.gameObject.SetActive(false);
        }
        panel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
