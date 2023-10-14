using UnityEngine;

public interface IGameService
{
    public void RegisterService(TypesOfServices typesOfService, IGameService gameService);
}
