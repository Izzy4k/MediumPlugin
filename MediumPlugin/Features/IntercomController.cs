using Exiled.API.Features;
using PlayerRoles;
using Exiled.API.Enums;
using Respawning;
using System.Linq;

namespace MediumPlugin.Features
{
    public class IntercomController
    {
        public void StartSpawn()
        {
            RespawnManager.Singleton.ForceSpawnTeam(SpawnableTeamType.NineTailedFox);
            --MPlugin.Instance.Config.CountSpawnMFT;
        }

        public bool IsRoomIntercom(Player player) => player.CurrentRoom.Type == RoomType.EzIntercom;

        public bool IsScientist(Player player) => player.Role.Type == RoleTypeId.Scientist;

        public bool IsHaveCountSpawn() => MPlugin.Instance.Config.CountSpawnMFT > 0;

        public bool IsScientistLast()
        {
            var survivors = Player.List.Where(player => player.Role.Team != Team.Dead && player.Role.Team != Team.Scientists && player.Role.Team != Team.SCPs).ToList();

            if(survivors.Count > 0) return false;

            return true;
        }
    }
}
