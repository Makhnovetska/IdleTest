using UnityEngine;

namespace Contracts.Interfaces
{
    public interface IPlayerTarget
    {
        GameObject gameObject { get; }
        Transform transform { get; }
    }
}