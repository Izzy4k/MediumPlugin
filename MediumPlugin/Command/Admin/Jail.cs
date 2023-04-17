using CommandSystem;
using Exiled.API.Features;
using Exiled.API.Features.Items;
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

                var target = Player.Get(admin.CameraTransform.gameObject);

                if(target is null)
                {
                    response = "Игрок не обнаружен!";
                    return false;
                }
               
                if(MPlugin.JailController.IsJailed(target))
                {
                    MPlugin.JailController.Release(target);

                    response = "Игрок освобожен";
                    return true;
                }

                MPlugin.JailController.Arrest(target);

                response = "Игрок в тюрьме";
                return true;
        }
    }
}
