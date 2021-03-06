﻿using AntShares.IO;
using System.IO;
using System.Linq;

namespace AntShares.Network.Payloads
{
    internal class AddrPayload : ISerializable
    {
        public NetworkAddressWithTime[] AddressList;

        public int Size => AddressList.Length.GetVarSize() + AddressList.Sum(p => p.Size);

        public static AddrPayload Create(params NetworkAddressWithTime[] addresses)
        {
            return new AddrPayload
            {
                AddressList = addresses
            };
        }

        void ISerializable.Deserialize(BinaryReader reader)
        {
            this.AddressList = reader.ReadSerializableArray<NetworkAddressWithTime>();
        }

        void ISerializable.Serialize(BinaryWriter writer)
        {
            writer.Write(AddressList);
        }
    }
}
