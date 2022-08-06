using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
    [TLObject(1667228533)]
    public class TLPhoneConnectionWebrtc : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1667228533;
            }
        }

        public int Flags { get; set; }
        public bool Turn { get; set; }
        public bool Stun { get; set; }
        public long Id { get; set; }
        public string Ip { get; set; }
        public string Ipv6 { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = Turn ? (Flags | 1) : (Flags & ~1);
            Flags = Stun ? (Flags | 2) : (Flags & ~2);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            Turn = (Flags & 1) != 0;
            Stun = (Flags & 2) != 0;
            Id = br.ReadInt64();
            Ip = StringUtil.Deserialize(br);
            Ipv6 = StringUtil.Deserialize(br);
            Port = br.ReadInt32();
            Username = StringUtil.Deserialize(br);
            Password = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            bw.Write(Id);
            StringUtil.Serialize(Ip, bw);
            StringUtil.Serialize(Ipv6, bw);
            bw.Write(Port);
            StringUtil.Serialize(Username, bw);
            StringUtil.Serialize(Password, bw);

        }
    }
}
