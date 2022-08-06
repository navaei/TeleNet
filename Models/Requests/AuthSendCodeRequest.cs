using System;
using System.IO;
using TeleNet.Models.MTProto;
using TeleNet.Models.TL;
using TeleNet.Models.TL.Auth;

namespace TeleNet.Models.Requests
{
    //public class AuthSendCodeRequest : MTProtoRequest
    //{
    //    public bool _phoneRegistered;
    //    public string _phoneCodeHash;
    //    public SendCodeArgs args = new SendCodeArgs();
    //    public AuthSendCodeRequest(string phoneNumber, int smsType, int apiId, string apiHash, string langCode)
    //    {

    //        args.phone_number = phoneNumber;
    //        args.api_id = apiId;
    //        args.api_hash = apiHash;
    //        args.allow_flashcall = false;
    //        args.current_number = true;
    //    }

    //    public override void OnSend(BinaryWriter writer)
    //    {
    //        writer.Write(0x86AEF0EC);
    //        writer.Write(0);
    //        Serializers.String.write(writer, args.phone_number);
    //        writer.Write(args.api_id.Value);
    //        Serializers.String.write(writer, args.api_hash);
    //    }

    //    public override void OnResponse(BinaryReader reader)
    //    {

    //        var s = Deserializer.Deserialize(typeof(TLSentCode), reader);
    //        _phoneRegistered = ((TLSentCode)s).phone_registered;
    //        _phoneCodeHash = ((TLSentCode)s).phone_code_hash;
    //    }

    //    public override void OnException(Exception exception)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool Confirmed => true;
    //    public override bool Responded { get; }
    //}
}
