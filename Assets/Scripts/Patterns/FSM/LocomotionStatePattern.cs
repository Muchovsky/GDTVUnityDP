using UnityEngine;

public interface ILocomotionContext
{
    void SetState(ILocomotionState newState);
}

public interface ILocomotionState
{
    void Jump(ILocomotionContext context);
    void Fall(ILocomotionContext context);
    void Land(ILocomotionContext context);
    void Crouch(ILocomotionContext context);
}

public class LocomotionStatePattern : MonoBehaviour, ILocomotionContext
{
    ILocomotionState currentState = new GroundedState();

    public void Crouch() => currentState.Crouch(this);

    public void Fall() => currentState.Fall(this);

    public void Jump() => currentState.Jump(this);

    public void Land() => currentState.Land(this);

    void ILocomotionContext.SetState(ILocomotionState newState)
    {
        currentState = newState;
    }
}

public class GroundedState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }

    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Jump(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Land(ILocomotionContext context)
    {
    }
}

public class InAirState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
    }

    public void Fall(ILocomotionContext context)
    {
    }

    public void Jump(ILocomotionContext context)
    {
    }

    public void Land(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
}

public class CrouchingState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    public void Jump(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    public void Land(ILocomotionContext context)
    {
    }
}