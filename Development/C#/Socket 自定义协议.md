<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
using System.Net.Sockets;using System.Net;using System;using System.IO;using System.Text;public class SocketHelper {    //|---------------------------------------------------|    //|validate 16byte | command 1byte | message 1024byte |    //|---------------------------------------------------|    private const int[] VALIDATE = { 0x13, 0x5F, 0x02, 0x10 };    private const byte NAVIGATE = 100;    private const byte FORWARD = 101;    private const byte BACKWARD = 102;    private const byte CLOSE = 200;    private const string IP_ADDRESS = "127.0.0.1";    private const int PORT = 9999;    private const int BUFFER_SIZE = 2048;    private byte[] buffer = new byte[BUFFER_SIZE];    public void Create()    {        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(IP_ADDRESS), PORT);        socket.Bind(ipEndPoint);        Receive();    }    public void Receive()    {        socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);    }    private void ReceiveCallback(IAsyncResult ar)    {        Receive();        Socket socket = ar.AsyncState as Socket;        int readBytes = socket.EndReceive(ar);        if (readBytes > 0)        {            if (CheckValidate(buffer))            {                switch (buffer[16])                {                    case NAVIGATE:                        string url = Encoding.ASCII.GetString(buffer, 17, 1024);                        break;                    case FORWARD:                        break;                    case BACKWARD:                        break;                    case CLOSE:                        break;                    default:                        break;                }            }        }    }    private bool CheckValidate(byte[] data)    {        for (int i = 0; i < VALIDATE.Length; i++)        {            int num = BitConverter.ToInt32(data, i * 4);            if (num != VALIDATE[i])            {                return false;            }        }        return true;    }}
```

</div>

<div>

\

</div>

</div>

<div>

<span
style="font-size:9pt;color:#569cd6;background-color:#1e1e1e;font-family:'NSimSun';"></span>

</div>

<div>

<span
style="font-size:9pt;color:#dcdcdc;background-color:#1e1e1e;font-family:'NSimSun';"></span>

</div>
