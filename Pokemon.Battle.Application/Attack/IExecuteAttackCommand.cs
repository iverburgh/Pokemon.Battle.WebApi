namespace Pokemon.Battle.Application.Attack;

public interface IExecuteAttackCommand
{
    AttackResultModel Execute(ExecuteAttackModel executeAttackModel);
}