using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float MaxHealth, _Health, Width, Height = 20;
    [SerializeField] private RectTransform HealthBar;
    // Update is called once per frame
    public void SetMaxHealt(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetHealth(float health) 
    {
        _Health = health;
        float newWith = (health / MaxHealth) * Width;

        HealthBar.sizeDelta = new Vector2(newWith, Height);
    }

    public void Start()
    {
        Width = HealthBar .rect.width;
        Height = HealthBar .rect.height;
    }

}
