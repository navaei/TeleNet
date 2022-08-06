using System;
using System.IO;
using TeleNet.Models.TL;

namespace TeleNet.Models.Requests
{
    //public class DownloadFileRequest : MTProtoRequest
    //{
    //    private GetFileArgs args = new GetFileArgs();
    //    public TeleNet.Models.TL.File file;

    //    public DownloadFileRequest(TLInputFileLocation loc, int offset = 0, int limit = 0)
    //    {
    //        args.location = loc;
    //        args.offset = offset;
    //        args.limit = limit;
    //    }

    //    public override void OnSend(BinaryWriter writer)
    //    {
    //        Serializer.Serialize(args, typeof(InputFileLocation), writer);
    //    }

    //    public override void OnResponse(BinaryReader reader)
    //    {
    //        file = (TeleNet.Models.TL.File)Deserializer.Deserialize(typeof(TeleNet.Models.TL.File), reader);
    //    }

    //    public override void OnException(Exception exception)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool Confirmed => true;
    //    public override bool Responded { get; }
    //}
}
