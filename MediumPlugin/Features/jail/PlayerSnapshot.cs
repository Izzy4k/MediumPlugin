using PlayerRoles;
using UnityEngine;
using Exiled.API.Features;

namespace MediumPlugin.Features
{
    public class PlayerSnapshot
    {
        public Player Player { get; set; }

        public float Health { get; set; }

        public RoleTypeId Role { get; set; }

        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }

        public PlayerSnapshot(Player player)
        {
            Player = player;
            Health = player.Health;
            Role = player.Role;
            Position = player.Position;
            Rotation = player.Rotation;
        }
    }
}
