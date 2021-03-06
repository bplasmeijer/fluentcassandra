﻿using System;

namespace FluentCassandra.Connections
{
	public abstract class ConnectionProvider : IConnectionProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="builder"></param>
		protected ConnectionProvider(ConnectionBuilder builder)
		{
			Builder = builder;
			Servers = new RoundRobinServerManager(builder);
		}

		/// <summary>
		/// 
		/// </summary>
		public ConnectionBuilder Builder { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		public IServerManager Servers { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public abstract IConnection CreateConnection();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual IConnection Open()
		{
			var conn = CreateConnection();
			conn.Open();

			return conn;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="connection"></param>
		/// <returns></returns>
		public virtual bool Close(IConnection connection)
		{
			if (connection.IsOpen)
				connection.Dispose();

			return true;
		}
	}
}
