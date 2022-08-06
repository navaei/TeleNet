using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL123
{
	[TLObject(1690708501)]
    public class TLGroupCallParticipant : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1690708501;
            }
        }

             public int Flags {get;set;}
     public bool Muted {get;set;}
     public bool Left {get;set;}
     public bool CanSelfUnmute {get;set;}
     public bool JustJoined {get;set;}
     public bool Versioned {get;set;}
     public bool Min {get;set;}
     public bool MutedByYou {get;set;}
     public bool VolumeByAdmin {get;set;}
     public int UserId {get;set;}
     public int Date {get;set;}
     public int? ActiveDate {get;set;}
     public int Source {get;set;}
     public int? Volume {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Muted ? (Flags | 1) : (Flags & ~1);
Flags = Left ? (Flags | 2) : (Flags & ~2);
Flags = CanSelfUnmute ? (Flags | 4) : (Flags & ~4);
Flags = JustJoined ? (Flags | 16) : (Flags & ~16);
Flags = Versioned ? (Flags | 32) : (Flags & ~32);
Flags = Min ? (Flags | 256) : (Flags & ~256);
Flags = MutedByYou ? (Flags | 512) : (Flags & ~512);
Flags = VolumeByAdmin ? (Flags | 1024) : (Flags & ~1024);
Flags = ActiveDate != null ? (Flags | 8) : (Flags & ~8);
Flags = Volume != null ? (Flags | 128) : (Flags & ~128);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Muted = (Flags & 1) != 0;
Left = (Flags & 2) != 0;
CanSelfUnmute = (Flags & 4) != 0;
JustJoined = (Flags & 16) != 0;
Versioned = (Flags & 32) != 0;
Min = (Flags & 256) != 0;
MutedByYou = (Flags & 512) != 0;
VolumeByAdmin = (Flags & 1024) != 0;
UserId = br.ReadInt32();
Date = br.ReadInt32();
if ((Flags & 8) != 0)
ActiveDate = br.ReadInt32();
else
ActiveDate = null;

Source = br.ReadInt32();
if ((Flags & 128) != 0)
Volume = br.ReadInt32();
else
Volume = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);








bw.Write(UserId);
bw.Write(Date);
if ((Flags & 8) != 0)
bw.Write(ActiveDate.Value);
bw.Write(Source);
if ((Flags & 128) != 0)
bw.Write(Volume.Value);

        }
    }
}
