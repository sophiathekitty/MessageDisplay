# MessageDisplay
 a way to display text messages on the screen in useful ways
 
can display simple messages with text, title, and icon. messages can be queued so it only displays a max number at once. messages have timeouts. if message object has an animator will attempt to setTrigger("Hide") to hide message. death_time sets the timeout for Destroying message instance.

MessageContent can also store data (Dictionary<string,object>) for custom display scripts to display more complex messages.

requires TextMeshPro and https://github.com/sophiathekitty/InGameCommandConsole because the sample scene includes that.
