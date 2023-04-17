using System.Collections.Generic;
using System.Linq;
using InventorySystem;
using Exiled.API.Features;

namespace MediumPlugin.Extensions
{
    public static class Extensions
    {
        public static Inventory GetInventory(this Player player)
        {
            return player.ReferenceHub.inventory;
        }

        public static InventoryInfo GetCurrentInventory(this Player player)
        {
            return player.ReferenceHub.inventory.UserInventory;
        }

        public static IEnumerable<ItemType> EnumerateItemList(this Player player)
        {
            return GetCurrentInventory(player).Items.Values.Select(item => item.ItemTypeId);
        }

        public static ItemType[] GetItemList(this Player player)
        {
            return EnumerateItemList(player).ToArray();
        }

        public static Dictionary<ItemType, ushort> GetAmmoList(this Player player)
        {
            return new Dictionary<ItemType, ushort>(GetCurrentInventory(player).ReserveAmmo);
        }
    }
}
