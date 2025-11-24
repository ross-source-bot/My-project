
using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;

using TMPro;

///doesnt display on screen, state on GDD
public class PlayerHUD : CharacterStats

{

    [SerializeField] private TMP_Text currentHealthText;

    [SerializeField] private TMP_Text maxHealthText;



    public void UpdateHealth(int currentHealth, int maxHealth)

    {

        currentHealthText.text = currentHealth.ToString();

        maxHealthText.text = maxHealth.ToString();

    }

}