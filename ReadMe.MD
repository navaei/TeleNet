TeleNet(Telegram + .Net)
-------------------------------

A simple _Unofficial_ Telegram (http://telegram.org) MTProto client implemented in C#.
The Api client library that implements the MtProto 2.0 protocol is supported by .Net >= 6


# Starter Guide


## Telegram API and MTPROTO:
If you want more information about Telegram API, you can go [here](https://core.telegram.org/api#telegram-api). And [here](https://core.telegram.org/mtproto) you will find extra information about mtproto.

## Quick Configuration
You need to do some configuration first.

1. Create a [developer account](https://my.telegram.org/) in Telegram. 
1. Goto [API development tools](https://my.telegram.org/apps) and copy **API_ID** and **API_HASH** from your account. You'll need it later.


## First requests

To start work, create an instance of TelegramClient and establish connection:

```csharp 
    var client = new TelegramClient(apiId, apiHash);
    await client.ConnectAsync();
```

Now you can work with Telegram API, but ->

> Only a small portion of the API methods are available to unauthorized users. ([full description](https://core.telegram.org/api/auth)) 

For authentication you need to run following code:

```csharp
    var hash = await client.SendCodeRequestAsync("<user_number>");
    var code = "<code_from_telegram>"; // you can change code in debugger

    var user = await client.MakeAuthAsync("<user_number>", hash, code);
``` 

When the user is authenticated, TeleNet creates special file called _session.dat_. In this file TeleNet stores all information needed for the user's session. So you need to authenticate user every time the _session.dat_ file is corrupted or removed.

You can call any method on authenticated users. For example, let's send message to a friend by his phone number:

```csharp
    //get available contacts
    var result = await client.GetContactsAsync();

    //find recipient in contacts
    var user = result.Users
                     .OfType<TLUser>()
                     .FirstOrDefault(x => x.Phone == "<recipient_phone>");

    //send message
    await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, "OUR_MESSAGE");
```

To send a message to a channel you could use the following code:

```csharp
    //get user dialogs
    var dialogs = (TLDialogsSlice) await client.GetUserDialogsAsync();

    //find channel by title
    var chat = dialogs.Chats
                      .OfType<TLChannel>()
                      .FirstOrDefault(c => c.Title == "<channel_title>");

    //send message
    await client.SendMessageAsync(new TLInputPeerChannel() { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, "OUR_MESSAGE");
```


## Working with files

Telegram separate files to two categories -> big file and small file. File is Big if its size more than 10 Mb. TeleNet tries to hide this complexity from you, thats why we provide one method to upload files **UploadFile**.

```csharp
    var fileResult = await client.UploadFile("cat.jpg", new StreamReader("data/cat.jpg"));
```

TeleNet provides two wrappers for sending photo and document:

```csharp
    await client.SendUploadedPhoto(new TLInputPeerUser() { UserId = user.Id }, fileResult, "kitty");
    await client.SendUploadedDocument(new TLInputPeerUser() { UserId = user.Id },
                                      fileResult,
                                      "application/zip", //mime-type

                                      //document attributes, such as file name
                                      new TLVector<TLAbsDocumentAttribute>());
```


To download a file you should call the **GetFile** method:

```csharp
    await client.GetFile(new TLInputDocumentFileLocation()
                         {
                             AccessHash = document.AccessHash,
                             Id = document.Id,
                             FileReference = document.FileReference,
                             ThumbSize = "250x250"
                         },

                         //size of fileChunk you want to retrieve
                         document.Size);
```


# Available Methods

For your convenience TeleNet have wrappers for several Telegram API methods. You could add your own, see details below.

1. SendCodeRequestAsync
1. MakeAuthAsync
1. GetContactsAsync
1. SendMessageAsync
1. SendTypingAsync
1. GetUserDialogsAsync
1. SendUploadedPhoto
1. SendUploadedDocument
1. GetFile
1. UploadFile
1. SendPingAsync
1. GetHistoryAsync
1. UpdateStatusAsync
1. SearchUserAsync
1. SignUpAsync


**What if you can't find needed method at the list?**

Don't panic. You can call any method with help of `SendRequestAsync` function. For example, send user typing method:

```csharp
    //Create request
    var req = new TLRequestSetTyping()
    {
        Action = new TLSendMessageTypingAction(),
        Peer = new TLInputPeerUser() { UserId = user.Id }
    };

    //run request, and deserialize response to Boolean
    return await client.SendRequestAsync<Boolean>(req);
``` 


**Where can you find a list of requests and its parameters?**

The only way is [Telegram API docs](https://core.telegram.org/methods). Yes, it's no longer outdated.
Latest scheme in JSON format you can find [here](https://core.telegram.org/schema/json)


# Special Thanks

* [sochix](https://github.com/sochix) - Original TLSharp author
* [Afshin Arani](http://aarani.ir) - TLGenerator, and a lot of other usefull things


## License
Please, provide link to the original authors when using library

The project is released under the [Mit License](./LICENSE)

Copyright (c) 2015 Ilya Pirozhenko ([sochix](https://github.com/sochix))

Copyright (c) 2015-2020 TLSharp/TgSharp contributors
