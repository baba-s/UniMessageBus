using System;
using System.Collections.Generic;

namespace Kogane
{
	/// <summary>
	/// メッセージバスを管理するクラス
	/// </summary>
	public abstract partial class MessageBus
	{
		//================================================================================
		// 変数(static)
		//================================================================================
		private static Dictionary<Type, IMessageBus> m_table;
		
		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// メッセージバスを返します
		/// </summary>
		public static T Get<T>() where T : IMessageBus
		{
			// 初めてメッセージバスを使う時にテーブルを作成します
			if ( m_table == null )
			{
				m_table = new Dictionary<Type, IMessageBus>();
			}

			var type = typeof( T );

			// テーブルにバスが登録されている場合は登録されているバスを返します
			if ( m_table.TryGetValue( type, out var messageBus ) )
			{
				return ( T ) messageBus;
			}

			// 登録されていない場合はバスを作成してテーブルに登録してから返します
			messageBus = ( IMessageBus ) Activator.CreateInstance( type );

			m_table.Add( type, messageBus );

			return ( T ) messageBus;
		}
	}

	/// <summary>
	/// メッセージバスで送受信するメッセージのインターフェイス
	/// </summary>
	public interface IMessageBus
	{
	}

	/// <summary>
	/// メッセージバスで送受信する引数なしのメッセージの基底クラス
	/// </summary>
	public abstract partial class MessageBus : IMessageBus
	{
		//================================================================================
		// 変数
		//================================================================================
		private Action m_callback;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを登録します
		/// </summary>
		public void Add( Action callback )
		{
			m_callback += callback;
		}

		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを解除します
		/// </summary>
		public void Remove( Action callback )
		{
			m_callback -= callback;
		}

		/// <summary>
		/// メッセージを送信します
		/// </summary>
		public void Send()
		{
			m_callback?.Invoke();
		}
	}

	/// <summary>
	/// メッセージバスで送受信する引数が 1 つのメッセージの基底クラス
	/// </summary>
	public abstract class MessageBus<T> : IMessageBus
	{
		//================================================================================
		// 変数
		//================================================================================
		private Action<T> m_callback;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを登録します
		/// </summary>
		public void Add( Action<T> callback )
		{
			m_callback += callback;
		}

		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを解除します
		/// </summary>
		public void Remove( Action<T> callback )
		{
			m_callback -= callback;
		}

		/// <summary>
		/// メッセージを送信します
		/// </summary>
		public void Send( T arg1 )
		{
			m_callback?.Invoke( arg1 );
		}
	}

	/// <summary>
	/// メッセージバスで送受信する引数が 2 つのメッセージの基底クラス
	/// </summary>
	public abstract class MessageBus<T1, T2> : IMessageBus
	{
		//================================================================================
		// 変数
		//================================================================================
		private Action<T1, T2> m_callback;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを登録します
		/// </summary>
		public void Add( Action<T1, T2> callback )
		{
			m_callback += callback;
		}

		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを解除します
		/// </summary>
		public void Remove( Action<T1, T2> callback )
		{
			m_callback -= callback;
		}

		/// <summary>
		/// メッセージを送信します
		/// </summary>
		public void Send( T1 arg1, T2 arg2 )
		{
			m_callback?.Invoke( arg1, arg2 );
		}
	}

	/// <summary>
	/// メッセージバスで送受信する引数が 3 つのメッセージの基底クラス
	/// </summary>
	public abstract class MessageBus<T1, T2, T3> : IMessageBus
	{
		//================================================================================
		// 変数
		//================================================================================
		private Action<T1, T2, T3> m_callback;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを登録します
		/// </summary>
		public void Add( Action<T1, T2, T3> callback )
		{
			m_callback += callback;
		}

		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを解除します
		/// </summary>
		public void Remove( Action<T1, T2, T3> callback )
		{
			m_callback -= callback;
		}

		/// <summary>
		/// メッセージを送信します
		/// </summary>
		public void Send( T1 arg1, T2 arg2, T3 arg3 )
		{
			m_callback?.Invoke( arg1, arg2, arg3 );
		}
	}

	/// <summary>
	/// メッセージバスで送受信する引数が 4 つのメッセージの基底クラス
	/// </summary>
	public abstract class MessageBus<T1, T2, T3, T4> : IMessageBus
	{
		//================================================================================
		// 変数
		//================================================================================
		private Action<T1, T2, T3, T4> m_callback;
		
		//================================================================================
		// 関数
		//================================================================================
		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを登録します
		/// </summary>
		public void Add( Action<T1, T2, T3, T4> callback )
		{
			m_callback += callback;
		}

		/// <summary>
		/// メッセージを受信した時に呼び出されるコールバックを解除します
		/// </summary>
		public void Remove( Action<T1, T2, T3, T4> callback )
		{
			m_callback -= callback;
		}

		/// <summary>
		/// メッセージを送信します
		/// </summary>
		public void Send( T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			m_callback?.Invoke( arg1, arg2, arg3, arg4 );
		}
	}
}