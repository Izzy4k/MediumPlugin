using Exiled.API.Features;
using PlayerRoles;
using System.Collections.Generic;

namespace MediumPlugin.Features
{
    public class JailController
    {

        public Dictionary<Player, PlayerSnapshot> Snapshots { get; } = new Dictionary<Player, PlayerSnapshot>();

        public bool IsJailed(Player player)
        {
            return Snapshots.ContainsKey(player);
        }

        public void Arrest(Player player)
        {
            if (IsJailed(player)) return;

            Snapshots[player] = new PlayerSnapshot(player);

            player.ReferenceHub.roleManager.ServerSetRole(RoleTypeId.ClassD, RoleChangeReason.None);

            player.Broadcast(6, "Поздравляю вы в тюрьме!", shouldClearPrevious: true);
        }

        public void Release(Player player)
        {
            if(!Snapshots.TryGetValue(player, out PlayerSnapshot snapshot)) return;

            RestoreSnapshot(player, snapshot);

            Snapshots.Remove(player);
        }

        private void RestoreSnapshot(Player player,PlayerSnapshot snapshot)
        {

            player.ReferenceHub.roleManager.ServerSetRole(snapshot.Role, RoleChangeReason.None);

            player.Position = snapshot.Position;
            player.Rotation = snapshot.Rotation;
            player.Health = snapshot.Health;
        }
    }
}
