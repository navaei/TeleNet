using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
	[TLObject(617508334)]
    public class TLRequestTranslateText : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 617508334;
            }
        }

                public int Flags {get;set;}
        public TLAbsInputPeer Peer {get;set;}
        public int? MsgId {get;set;}
        public string Text {get;set;}
        public string FromLang {get;set;}
        public string ToLang {get;set;}
public Messages.TLAbsTranslatedText Response { get; set;}


		public void ComputeFlags()
		{
			Flags = 0;
Flags = Peer != null ? (Flags | 1) : (Flags & ~1);
Flags = MsgId != null ? (Flags | 1) : (Flags & ~1);
Flags = Text != null ? (Flags | 2) : (Flags & ~2);
Flags = FromLang != null ? (Flags | 4) : (Flags & ~4);

		}

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
if ((Flags & 1) != 0)
Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
else
Peer = null;

if ((Flags & 1) != 0)
MsgId = br.ReadInt32();
else
MsgId = null;

if ((Flags & 2) != 0)
Text = StringUtil.Deserialize(br);
else
Text = null;

if ((Flags & 4) != 0)
FromLang = StringUtil.Deserialize(br);
else
FromLang = null;

ToLang = StringUtil.Deserialize(br);

        }

        public override void SerializeBody(BinaryWriter bw)
        {
			bw.Write(Constructor);
            ComputeFlags();
bw.Write(Flags);
if ((Flags & 1) != 0)
ObjectUtils.SerializeObject(Peer,bw);
if ((Flags & 1) != 0)
bw.Write(MsgId.Value);
if ((Flags & 2) != 0)
StringUtil.Serialize(Text,bw);
if ((Flags & 4) != 0)
StringUtil.Serialize(FromLang,bw);
StringUtil.Serialize(ToLang,bw);

        }

		public override void DeserializeResponse(BinaryReader br)
		{
			Response = (Messages.TLAbsTranslatedText)ObjectUtils.DeserializeObject(br);

		}
    }
}
