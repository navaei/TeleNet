using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL133
{
	[TLObject(1735736008)]
    public class TLGroupCallParticipantVideo : TLObject
    {
        public override int Constructor
        {
            get
            {
                return 1735736008;
            }
        }

             public int Flags {get;set;}
     public bool Paused {get;set;}
     public string Endpoint {get;set;}
     public TLVector<TLGroupCallParticipantVideoSourceGroup> SourceGroups {get;set;}
     public int? AudioSource {get;set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Paused ? (Flags | 1) : (Flags & ~1);
Flags = AudioSource != null ? (Flags | 2) : (Flags & ~2);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
Paused = (Flags & 1) != 0;
Endpoint = StringUtil.Deserialize(br);
SourceGroups = (TLVector<TLGroupCallParticipantVideoSourceGroup>)ObjectUtils.DeserializeVector<TLGroupCallParticipantVideoSourceGroup>(br);
if ((Flags & 2) != 0)
AudioSource = br.ReadInt32();
else
AudioSource = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);

StringUtil.Serialize(Endpoint,bw);
ObjectUtils.SerializeObject(SourceGroups,bw);
if ((Flags & 2) != 0)
bw.Write(AudioSource.Value);

        }
    }
}
