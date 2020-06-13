# UniMessageBus

メッセージバス

## 使用例

### 引数なし

```cs
using Kogane;
using UnityEngine;

// 送受信するデータ
public class Data : MessageBus
{
}

// データを送信する側
public class Dispatcher : MonoBehaviour
{
    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            MessageBus.Get<Data>().Send();
        }
    }
}
```

```cs
using Kogane;
using UnityEngine;

// データを受信する側
public class Receiver : MonoBehaviour
{
    private void OnEnable()
    {
        MessageBus.Get<Data>().Add( OnReceive );
    }
    
    private void OnDisable()
    {
        MessageBus.Get<Data>().Remove( OnReceive );
    }

    private void OnReceive()
    {
        Debug.Log( "ピカチュウ" );
    }
}
```

### 引数1つ

```cs
using Kogane;
using UnityEngine;

// 送受信するデータ
public class Data : MessageBus<string>
{
}

// データを送信する側
public class Dispatcher : MonoBehaviour
{
    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            MessageBus.Get<Data>().Send( "ピカチュウ" );
        }
    }
}
```

```cs
using Kogane;
using UnityEngine;

// データを受信する側
public class Receiver : MonoBehaviour
{
    private void OnEnable()
    {
        MessageBus.Get<Data>().Add( OnReceive );
    }
    
    private void OnDisable()
    {
        MessageBus.Get<Data>().Remove( OnReceive );
    }

    private void OnReceive( string name )
    {
        Debug.Log( name );
    }
}
```

### 引数2つ

```cs
using Kogane;
using UnityEngine;

// 送受信するデータ
public class Data : MessageBus<int, string>
{
}

// データを送信する側
public class Dispatcher : MonoBehaviour
{
    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            MessageBus.Get<Data>().Send( 25, "ピカチュウ" );
        }
    }
}
```

```cs
using Kogane;
using UnityEngine;

// データを受信する側
public class Receiver : MonoBehaviour
{
    private void OnEnable()
    {
        MessageBus.Get<Data>().Add( OnReceive );
    }
    
    private void OnDisable()
    {
        MessageBus.Get<Data>().Remove( OnReceive );
    }

    private void OnReceive( int id, string name )
    {
        Debug.Log( id + ": " + name );
    }
}
```
