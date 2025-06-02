using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public Actor actor;

    private Stack<Command> commandStack;
    private float callbackTime;
    public bool isRun = true;

    private void Start()
    {
        commandStack = new Stack<Command>();
        callbackTime = 0;
    }

    private void Update()
    {
        if (isRun == true)
        {
            Control();
        }
        else
        {
            RunCallBack();
        }
    }

    private void RunCallBack()
    {
        callbackTime -= Time.deltaTime;
        if (commandStack.Count > 0 && callbackTime < commandStack.Peek().ExecuteTime)
        {
            commandStack.Pop().Undo(actor);
        }
    }

    private Command InputHandler()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) movement.y += Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) movement.y -= Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) movement.x -= Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) movement.x += Time.deltaTime;

        if (movement != Vector3.zero)
        {
            movement = movement.normalized * Time.deltaTime;
            return new MoveCommand(movement, callbackTime);
        }

        return null;
    }

    private void Control()
    {
        callbackTime += Time.deltaTime;
        Command cmd = InputHandler();
        if (cmd != null)
        {
            commandStack.Push(cmd);
            cmd.Execute(actor);
        }
    }
}
