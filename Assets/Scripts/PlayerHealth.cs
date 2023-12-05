using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        //The following line is just used to allow the health bar to be properly filled in proportion to how high or low the health value is.
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        //The following puts the player back to the level select screen if their health hits zero.
        if (health <= 0)
        {
            OpenScene();
        }
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
