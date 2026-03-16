using UnityEngine;

public class AbilityRunner : MonoBehaviour
{
    [SerializeField] IAbility currentAbility =
        new SequenceComposite(new IAbility[]
        {
            new HealingAbility(),
            new RageAbility(),
            new DelayDecorator(new RageAbility())
        });


    public void UseAbility()
    {
        currentAbility.Use(gameObject);
    }
}

public interface IAbility
{
    void Use(GameObject currentGameObject);
}

public class SequenceComposite : IAbility
{
    IAbility[] abilities;

    public SequenceComposite(IAbility[] abilities)
    {
        this.abilities = abilities;
    }


    public void Use(GameObject currentGameObject)
    {
        foreach (var ability in abilities)
        {
            ability.Use(currentGameObject);
        }
    }
}

public class DelayDecorator : IAbility
{
    private IAbility decoratedAbility;

    public DelayDecorator(IAbility decoratedAbility)
    {
        this.decoratedAbility = decoratedAbility;
    }

    public void Use(GameObject currentGameObject)
    {
        //to do some delay logic
        decoratedAbility.Use(currentGameObject);
    }
}

public class RageAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("I'm always angry");
    }
}

public class FireballAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Launch Fireball");
    }
}

public class HealingAbility : IAbility
{
    public void Use(GameObject currentGameObject)
    {
        Debug.Log("Here eat this!");
    }
}