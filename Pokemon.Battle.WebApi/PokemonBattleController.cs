using Microsoft.AspNetCore.Mvc;
using Pokemon.Battle.Application.Attack;

namespace Pokemon.Battle.WebApi
{
    [ApiController]
    [Route("")]
    public class PokemonBattleController : ControllerBase
    {
        private readonly IExecuteAttackCommand _executeAttackCommand;

        public PokemonBattleController(IExecuteAttackCommand executeAttackCommand)
        {
            _executeAttackCommand = executeAttackCommand;
        }

        [HttpPost(Name = "Attack")]
        public AttackResultModel Attack(ExecuteAttackModel executeAttackModel)
        {
            return _executeAttackCommand.Execute(executeAttackModel);
        }
    }
}