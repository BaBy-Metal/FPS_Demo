public interface IState
{
    void OnEnter();

    void OnExit();

    
}

public enum IStateType
{
    MIN=0,

    IDLE=1,
    RUN=2,

}