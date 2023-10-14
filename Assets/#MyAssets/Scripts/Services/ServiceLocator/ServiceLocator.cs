using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : GenericSingleton<ServiceLocator>
{
    private Dictionary<TypesOfServices, IGameService> servises = new Dictionary<TypesOfServices, IGameService>();

    public void RegisterService<T>(TypesOfServices typesOfService, T serviceToRegister) where T : IGameService
    {
        if(!servises.ContainsKey(typesOfService))
        {
            servises.Add(typesOfService, serviceToRegister);
        }
    }

    public T GetService<T>(TypesOfServices typesOfService) where T : class, IGameService
    {
        if(servises.ContainsKey(typesOfService))
        {
            return (T)servises[typesOfService];
        }

        return null;
    }
}
