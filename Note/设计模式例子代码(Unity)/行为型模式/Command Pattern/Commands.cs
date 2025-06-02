using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected float executeTime;
    public float ExecuteTime
    {
        get { return executeTime; }
    }

    public virtual void Execute(Actor actor)
    {

    }

    public virtual void Undo(Actor actor)
    {

    }
}

public class MoveCommand : Command
{
    private Vector3 movementDelta;

    public MoveCommand(Vector3 movementDelta, float time)
    {
        this.movementDelta = movementDelta;
        this.executeTime = time;
    }
    public override void Execute(Actor actor)
    {
        actor.Move(movementDelta);
    }
    public override void Undo(Actor actor)
    {
        actor.Move(-movementDelta);
    }
}
