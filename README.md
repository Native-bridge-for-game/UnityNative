# UnityNative
Helps comunication between unity and native(Android, iOS)

## How to use

### Container
Data storing unit.

Currently storess the following types:
- bool
- int
- float
- string
- byte[]
- other Container object

### Message
Data deliver unit.
- key : string value, identifier of message. notified messages ar deliverd to handler registerd with key.
- container : Container object

### Tag
Filters message
- MessageHandler sets Tags. It only receives message containing all set tags.
- Notifies message with Tags. messages are arrived messageHandlers which have tags all.

### MessageHandler
Notify and subscribe messages.
- Notifies message to other unity or native MessageHandler object. 
- Subscribes message from other unity or native MessageHandler object.

### Usage
Code opens native alert. Need Android/iOS implementation comunicate with this code.
```cs
using PJ.Native.Messenger

public class NativeComunicator
{
    private MessageHandler messageHandler;

    public NativeComunicator()
    {
        // Create messageHandler
        messageHandler = new MessageHandler(Tag.Game);
        
        // set handler with key.
        messageHandler.SetHandler("ALERT_RESULT", OnReceive); 
    }   

    private void OnReceive(MessageHolder messageHolder)
    {
        if(messageHoler.Message.Container.TryGetValue("pressOk", out bool pressOk))
        {
            Debug.Log("user press? " + pressOk);
        }
    }

    public void OpenNativeAlert(string alertMessage)
    {
        // Create Container object and set data
        Container container = new Container();
        container.Add("alertMessage", alertMessage);
        Message message = new Message("OPEN_ALERT", container);
        // NotifyMessage 
        messageHandler.Notify(container, Tag.Native);
    }
}
```