using CommandSystem;
using Exiled.API.Features;
using System;
using UnityEngine;

namespace MediumPlugin.Command.Admin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public sealed class Jail : ICommand
    {
        public string Command => "jail";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Переводит в туториал и обратно";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var admin = Player.Get((sender as CommandSender)?.SenderId);

            var target = GetPlayerLookingAt(admin);

            if (target is null)
            {
                response = "Игрок не обнаружен!";
                return false;
            }

            if (MPlugin.JailController.IsJailed(target))
            {
                MPlugin.JailController.Release(target);

                response = "Игрок освобожен";
                return true;
            }

            MPlugin.JailController.Arrest(target);

            response = "Игрок в тюрьме";
            return true;
        }

        private Player GetPlayerLookingAt(Player player, float maxDistance = 10f)
        {
            RaycastHit hit;

            if (Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out hit, maxDistance))
            {
                var referenceHub = hit.transform.GetComponentInParent<ReferenceHub>();

                if (referenceHub is null) return null;

                return Player.Get(referenceHub.gameObject);
            }

            return null;
        }
    }
}
