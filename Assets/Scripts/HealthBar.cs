using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);


        // Find the game manager, and call game over if our health is < 0
        if (slider.value <= 0)
        {

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            RigidbodyFirstPersonController.mouseLook.lockCursor = false;


            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
