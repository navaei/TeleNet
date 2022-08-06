using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleNet.Models.TL;

namespace TeleNet.Models.TL140.Messages
{
    [TLObject(262163967)]
    public class TLRequestRequestWebView : TLMethod
    {
        public override int Constructor
        {
            get
            {
                return 262163967;
            }
        }

        public int Flags { get; set; }
        public bool FromBotMenu { get; set; }
        public bool Silent { get; set; }
        public TLAbsInputPeer Peer { get; set; }
        public TLAbsInputUser Bot { get; set; }
        public string Url { get; set; }
        public string StartParam { get; set; }
        public TLDataJSON ThemeParams { get; set; }
        public int? ReplyToMsgId { get; set; }
        public TLAbsWebViewResult Response { get; set; }


        public void ComputeFlags()
        {
            Flags = 0;
            Flags = FromBotMenu ? (Flags | 16) : (Flags & ~16);
            Flags = Silent ? (Flags | 32) : (Flags & ~32);
            Flags = Url != null ? (Flags | 2) : (Flags & ~2);
            Flags = StartParam != null ? (Flags | 8) : (Flags & ~8);
            Flags = ThemeParams != null ? (Flags | 4) : (Flags & ~4);
            Flags = ReplyToMsgId != null ? (Flags | 1) : (Flags & ~1);

        }

        public override void DeserializeBody(BinaryReader br)
        {
            Flags = br.ReadInt32();
            FromBotMenu = (Flags & 16) != 0;
            Silent = (Flags & 32) != 0;
            Peer = (TLAbsInputPeer)ObjectUtils.DeserializeObject(br);
            Bot = (TLAbsInputUser)ObjectUtils.DeserializeObject(br);
            if ((Flags & 2) != 0)
                Url = StringUtil.Deserialize(br);
            else
                Url = null;

            if ((Flags & 8) != 0)
                StartParam = StringUtil.Deserialize(br);
            else
                StartParam = null;

            if ((Flags & 4) != 0)
                ThemeParams = (TLDataJSON)ObjectUtils.DeserializeObject(br);
            else
                ThemeParams = null;

            if ((Flags & 1) != 0)
                ReplyToMsgId = br.ReadInt32();
            else
                ReplyToMsgId = null;


        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ComputeFlags();
            bw.Write(Flags);


            ObjectUtils.SerializeObject(Peer, bw);
            ObjectUtils.SerializeObject(Bot, bw);
            if ((Flags & 2) != 0)
                StringUtil.Serialize(Url, bw);
            if ((Flags & 8) != 0)
                StringUtil.Serialize(StartParam, bw);
            if ((Flags & 4) != 0)
                ObjectUtils.SerializeObject(ThemeParams, bw);
            if ((Flags & 1) != 0)
                bw.Write(ReplyToMsgId.Value);

        }

        public override void DeserializeResponse(BinaryReader br)
        {
            Response = (TLAbsWebViewResult)ObjectUtils.DeserializeObject(br);
        }
    }
}
