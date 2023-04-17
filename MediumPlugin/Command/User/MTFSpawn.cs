using CommandSystem;
using System;
using Exiled.API.Features;
namespace MediumPlugin.Command.User
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class MTFSpawn : ICommand
    {
        public string Command => "mtfSpawn";

        public string[] Aliases => Array.Empty<string>();

        public string Description => "Вызывает группу МОГ, если Ученные находятся в интеркоме";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var target = Player.Get((sender as CommandSender)?.SenderId);

            if (target is null)
            {
                response = "Игрок не найден!";
                return false;
            }

            if (!MPlugin.IntercomController.IsScientist(target))
            {
                response = "Вы не можете воспользоваться командой!";
                return false;
            }

            if (!MPlugin.IntercomController.IsRoomIntercom(target))
            {
                response = "Вы находитесь не в интеркоме! Команда отклонена!";
                return false;
            }

            if (!MPlugin.IntercomController.IsScientistLast())
            {
                response = "Есть и другие люди в Комплексе. Воспользуйтесь командой, когда останетесь одни с монстрами";
                return false;
            }

            if (!MPlugin.IntercomController.IsHaveCountSpawn())
            {
                response = "Все попытки были утрачены! Больше вызвать не получится";
                return false;
            }

            MPlugin.IntercomController.StartSpawn();

            response = "Вы вызвали группу МОГ";
            return true;
        }
    }
}
